﻿
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Module.BusinessObjects.DoDung;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Ten))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Chi tiết nhật ký")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [ImageName("writing")]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomRootListView(AllowEdit = true,AllowNew =false)]
    [Appearance("NgayLamViec", AppearanceItemType = "ViewItem", TargetItems = "NgayLamViec",
     Context = "ListView", FontColor = "Black", BackColor = "Gold", Priority = 3)]
    [Appearance("TongGioLamViec", AppearanceItemType = "ViewItem", TargetItems = "TongGioLamViec",
     Context = "ListView", BackColor = "DeepSkyBlue", Priority = 3)]
    [CustomRootListView(FieldsToSum = new[] { "TongGioLamViec:Sum" })]
    public class ChiTietNhatKy : BaseObject, IListViewPopup
    {
        public ChiTietNhatKy(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ngayLamViec=DateTime.Now.Date;
            thoiGianKetThuc = ngayLamViec;
            thoiGianBatDau = ngayLamViec;
        }

        string luongSuDung1;
        string luongSuDung;
        ThuocBVTV thuocBVTV;
        string nongDoPhaLoang;
        string ghiChu;
        string nhieuLieuTieuThu;
        ThieuBiMayMoc thieuBiMayMoc;
        string sanLuong;
        string tacNhanGayHai;
        double tongGioLamViec;
        DateTime? thoiGianKetThuc;
        DateTime? thoiGianBatDau;
        PhanBon phanBon;
        CongViec_TinhTrang congViec_TinhTrang;
        DateTime? ngayLamViec;
        NhatKyCanhTac nhatKyCanhTac;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public string Ten
        {
            get
            {
                string a = $"{NhatKyCanhTac.VungTrong.LoaiCayTrong} - {NhatKyCanhTac}";
                return a;
            }
        }
        [XafDisplayName("Nhật ký canh tác")]
        [Association("NhatKyCanhTac-ChiTietNhatKys")]
        [ModelDefault("AllowEdit","False")]
        [VisibleInDetailView(true)]
        [VisibleInLookupListView(true)]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
        [PersistentAlias("[NhatKyCanhTac.VungTrong]")]
        [VisibleInDetailView(true)]
        [XafDisplayName("Vùng trồng")]
        public VungTrong VungTrong
        {
            get
            {
                var tmp = EvaluateAlias(nameof(VungTrong));
                if (tmp != null)
                {
                    return tmp as VungTrong;
                }
                else
                {
                    return null;
                }
            }
        }
        [XafDisplayName("Ngày làm việc")]
        [RuleRequiredField("Bắt buộc phải có ChiTietNhatKy.NgayLamViec", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime? NgayLamViec
        {
            get => ngayLamViec;
            set => SetPropertyValue(nameof(NgayLamViec), ref ngayLamViec, value);
        }
        [XafDisplayName("Công việc -Tình trạng")]
        [RuleRequiredField("Bắt buộc phải có ChiTietNhatKy.CongViec_TinhTrang", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public CongViec_TinhTrang CongViec_TinhTrang
        {
            get => congViec_TinhTrang;
            set => SetPropertyValue(nameof(CongViec_TinhTrang), ref congViec_TinhTrang, value);
        }

        //2
        [XafDisplayName("Bón phân")]
        public PhanBon PhanBon
        {
            get => phanBon;
            set => SetPropertyValue(nameof(PhanBon), ref phanBon, value);
        }
        [XafDisplayName("Lượng sử dụng")]
        [ModelDefault("AllowEdit", "false")]
        public string LuongSuDung1
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (PhanBon != null)
                    {
                        luongSuDung1 = PhanBon.LieuLuongSuDung;
                        return luongSuDung1;
                    }
                }
                return luongSuDung1;
            }
            set => SetPropertyValue(nameof(LuongSuDung1), ref luongSuDung1, value);
        }

        [XafDisplayName("Thuốc BTVT")]
        public ThuocBVTV ThuocBVTV
        {
            get => thuocBVTV;
            set => SetPropertyValue(nameof(ThuocBVTV), ref thuocBVTV, value);
        }
        [XafDisplayName("Nồng độ pha loãng")]
        [ModelDefault("AllowEdit", "false")]
        public string NongDoPhaLoang
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (ThuocBVTV != null)
                    {
                        nongDoPhaLoang= ThuocBVTV.NongDoPhaLoang;
                        return nongDoPhaLoang;
                    }
                }
                return nongDoPhaLoang;
            }
            set => SetPropertyValue(nameof(NongDoPhaLoang), ref nongDoPhaLoang, value);
        }
        [XafDisplayName("Lượng sử dụng")]
        [ModelDefault("AllowEdit","false")]
        public string LuongSuDung
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (ThuocBVTV != null)
                    {
                        luongSuDung= ThuocBVTV.LieuLuongSuDung;
                        return luongSuDung;
                    }
                }
                return luongSuDung;
            }
            set => SetPropertyValue(nameof(LuongSuDung), ref luongSuDung, value);
        }
   
        //3
        [XafDisplayName("Thời gian bắt đầu")]
        [ModelDefault("DisplayFormat", "t")]
        public DateTime? ThoiGianBatDau
        {
            get => thoiGianBatDau;
            set => SetPropertyValue(nameof(ThoiGianBatDau), ref thoiGianBatDau, value);
        }
        [XafDisplayName("Thời gian kết thúc")]
        [ModelDefault("DisplayFormat", "t")]
        public DateTime? ThoiGianKetThuc
        {
            get => thoiGianKetThuc;
            set => SetPropertyValue(nameof(ThoiGianKetThuc), ref thoiGianKetThuc, value);
        }
        [XafDisplayName("Tổng giờ làm việc")]
        [ModelDefault("AllowEdit", "False")]
        public double TongGioLamViec
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(ThoiGianBatDau != null && ThoiGianKetThuc != null)
                    {
                        TimeSpan time = (TimeSpan)(thoiGianKetThuc - thoiGianBatDau);
                        tongGioLamViec = time.TotalHours;
                        return tongGioLamViec;
                    }
                }
                return tongGioLamViec;
            }
            set => SetPropertyValue(nameof(TongGioLamViec), ref tongGioLamViec, value);
        }
        //5:Thiếtbij máy móc
        [XafDisplayName("Thiết bị máy móc")]
        public ThieuBiMayMoc ThieuBiMayMoc
        {
            get => thieuBiMayMoc;
            set => SetPropertyValue(nameof(ThieuBiMayMoc), ref thieuBiMayMoc, value);
        }
        [XafDisplayName("Nhiên liệu tiêu thụ (L)")]
        public string NhieuLieuTieuThu
        {
            get => nhieuLieuTieuThu;
            set => SetPropertyValue(nameof(NhieuLieuTieuThu), ref nhieuLieuTieuThu, value);
        }
        //4: thông tin khác
        [XafDisplayName("Sản lượng (Kg)")]
        public string SanLuong
        {
            get => sanLuong;
            set => SetPropertyValue(nameof(SanLuong), ref sanLuong, value);
        }
        [XafDisplayName("Tác nhân gây hại")]
        public string TacNhanGayHai
        {
            get => tacNhanGayHai;
            set => SetPropertyValue(nameof(TacNhanGayHai), ref tacNhanGayHai, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}
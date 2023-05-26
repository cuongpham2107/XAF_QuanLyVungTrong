
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
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenVungTrong))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Vùng Trồng")]
    [ImageName("planting")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomDetailView(Tabbed =true)]
    [CustomNestedListView(nameof(Dat_CoSos), AllowLink = false, AllowUnlink = false)]
    [CustomNestedListView(nameof(NhatKyCanhTacs), AllowUnlink = false, AllowLink = false)]
    [Appearance("DienTichCanhTac", AppearanceItemType = "ViewItem", TargetItems = "DienTichCanhTac",
     Context = "ListView", BackColor = "204,255,204", FontStyle = System.Drawing.FontStyle.Bold, Priority = 1)]
   
    public class VungTrong : BaseObject
    {
        public VungTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            namCap = DateTime.Now.Year;
        }

        string ghiChu;
        string thongTinThoNhuong;
        LoaiCayTrong loaiCayTrong;
        string hinhThucCanhTac;
        string sanLuongDuKien;
        bool hoatDong;
        int dienTichCanhTac;
        string tieuChuan;
        int namCap;
        string diaChi;
        string maSo;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [XafDisplayName("Tên Vùng Trồng")]
        public string TenVungTrong
        {
            get
            {
                if (!IsSaving && !IsLoading)
                {
                    string a = $"{LoaiCayTrong} - {MaSo}";
                    return a;
                }
                return null;
            }
        }
        [XafDisplayName("Mã số vùng trồng")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.MaSo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaSo
        {
            get => maSo;
            set => SetPropertyValue(nameof(MaSo), ref maSo, value);
        }
        [XafDisplayName("Địa chỉ")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Năm cấp")]
        [ModelDefault("DisplayFormat", "D")]
        public int NamCap
        {
            get => namCap;
            set => SetPropertyValue(nameof(NamCap), ref namCap, value);
        }
        [XafDisplayName("Tiêu chuẩn")]
        public string TieuChuan
        {
            get => tieuChuan;
            set => SetPropertyValue(nameof(TieuChuan), ref tieuChuan, value);
        }
        [XafDisplayName("Diện tích")]
        public int DienTichCanhTac
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(Dat_CoSos.Count > 0)
                    {
                        return Dat_CoSos.Sum(x => x.DienTich);
                    }
                }
                return 0;
            }
            set => SetPropertyValue(nameof(DienTichCanhTac), ref dienTichCanhTac, value);
        }
        [XafDisplayName("Thông tin thổ nhưỡng")]
        public string ThongTinThoNhuong
        {
            get => thongTinThoNhuong;
            set => SetPropertyValue(nameof(ThongTinThoNhuong), ref thongTinThoNhuong, value);
        }
        [XafDisplayName("Tình trạng")]
        [CaptionsForBoolValues("Đang hoạt động", "Ngừng hoạt động")]
        public bool HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Sản lượng dự kiến")]
        public string SanLuongDuKien
        {
            get => sanLuongDuKien;
            set => SetPropertyValue(nameof(SanLuongDuKien), ref sanLuongDuKien, value);
        }
        [XafDisplayName("Hình thức canh tác")]
        public string HinhThucCanhTac
        {
            get => hinhThucCanhTac;
            set => SetPropertyValue(nameof(HinhThucCanhTac), ref hinhThucCanhTac, value);
        }
        //Start Maps 
        private string toaDo;
        [XafDisplayName("Toạ độ")]
        [VisibleInDetailView(true)]
        [VisibleInListView(true)]
        [Size(SizeAttribute.Unlimited)]
        public string ToaDo
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (LatLong != null)
                    {
                        return LatLong;
                    }
                }
                return null;
            }
            set { SetPropertyValue(nameof(ToaDo), ref toaDo, value); }
        }


        string latLong;
        [XafDisplayName("Vị trí")]
        [VisibleInListView(true)]
        [ModelDefault("PropertyEditorType", "DXApplication.Blazor.Server.Editors.CustomStringPropertyEditor")]
        [Size(SizeAttribute.Unlimited)]
        public string LatLong
        {
            get => latLong;
            set => SetPropertyValue(nameof(LatLong), ref latLong, value);
        }
        //End Maps 
        [XafDisplayName("Đất cơ sở")]
        [Association("VungTrong-Dat_CoSos")]
        public XPCollection<Dat_CoSo> Dat_CoSos
        {
            get
            {
                return GetCollection<Dat_CoSo>(nameof(Dat_CoSos));
            }
        }
        [XafDisplayName("Nhật ký canh tác")]
        [Association("VungTrong-NhatKyCanhTacs")]
        public XPCollection<NhatKyCanhTac> NhatKyCanhTacs
        {
            get
            {
                return GetCollection<NhatKyCanhTac>(nameof(NhatKyCanhTacs));
            }
        }
        [XafDisplayName("Tài liệu đi kèm")]
        [Association("VungTrong-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }

        [RuleRequiredField("Bắt buộc phải có VungTrong.LoaiCayTrong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Loại cây trồng")] 
        [Association("LoaiCayTrong-VungTrongs")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }
    }
}
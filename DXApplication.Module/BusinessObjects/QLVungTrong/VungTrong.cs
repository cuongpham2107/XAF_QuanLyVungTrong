using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(LoaiCayTrong))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Vùng Trồng")]
    [ImageName("planting")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomDetailView(Tabbed =true)]
    public class VungTrong : BaseObject
    {
        public VungTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string hinhThucCanhTac;
        string sanLuongDuKien;
        bool hoatDong;
        string loaiDat;
        double dienTichCanhTac;
        double dienTichCoSo;
        string quyMo;
        string tieuChuan;
        int namCap;
        string soCoSoCap;
        string diaChi;
        string maSo;
        [XafDisplayName("Mã số vùng trồng")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.MaSo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaSo
        {
            get => maSo;
            set => SetPropertyValue(nameof(MaSo), ref maSo, value);
        }
        [XafDisplayName("Địa chỉ")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [RuleRequiredField("Bắt buộc phải có VungTrong.SoCoSoCap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Số cơ sở cấp")]
        public string SoCoSoCap
        {
            get => soCoSoCap;
            set => SetPropertyValue(nameof(SoCoSoCap), ref soCoSoCap, value);
        }
        [XafDisplayName("Năm cấp")]
        public int NamCap
        {
            get => namCap;
            set => SetPropertyValue(nameof(NamCap), ref namCap, value);
        }
        [XafDisplayName("Tiêu chuẩn")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string TieuChuan
        {
            get => tieuChuan;
            set => SetPropertyValue(nameof(TieuChuan), ref tieuChuan, value);
        }
        [XafDisplayName("Quy mô")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string QuyMo
        {
            get => quyMo;
            set => SetPropertyValue(nameof(QuyMo), ref quyMo, value);
        }
        [XafDisplayName("Diện tích cơ sở")]
        public double DienTichCoSo
        {
            get => dienTichCoSo;
            set => SetPropertyValue(nameof(DienTichCoSo), ref dienTichCoSo, value);
        }
        [XafDisplayName("Diện tích canh tác")]
        public double DienTichCanhTac
        {
            get => dienTichCanhTac;
            set => SetPropertyValue(nameof(DienTichCanhTac), ref dienTichCanhTac, value);
        }
        [XafDisplayName("Loại đất")]
        public string LoaiDat
        {
            get => loaiDat;
            set => SetPropertyValue(nameof(LoaiDat), ref loaiDat, value);
        }
        [XafDisplayName("Tình trạng hoạt động")]
        [CaptionsForBoolValues("Đang hoạt động", "Ngừng hoạt động")]
        public bool HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }
        [XafDisplayName("Sản lượng dự kiến")]
        public string SanLuongDuKien
        {
            get => sanLuongDuKien;
            set => SetPropertyValue(nameof(SanLuongDuKien), ref sanLuongDuKien, value);
        }
        [XafDisplayName("Hình thức canh tác")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string HinhThucCanhTac
        {
            get => hinhThucCanhTac;
            set => SetPropertyValue(nameof(HinhThucCanhTac), ref hinhThucCanhTac, value);
        }
        [XafDisplayName("Nhật ký canh tác")]
        [Association("VungTrong-NhatKyCanhTacs"), DevExpress.Xpo.Aggregated]
        public XPCollection<NhatKyCanhTac> NhatKyCanhTacs
        {
            get
            {
                return GetCollection<NhatKyCanhTac>(nameof(NhatKyCanhTacs));
            }
        }
        [XafDisplayName("Thuốc BVTV")]
        [Association("VungTrong-ThuocBVTVs")]
        public XPCollection<ThuocBVTV> ThuocBVTVs
        {
            get
            {
                return GetCollection<ThuocBVTV>(nameof(ThuocBVTVs));
            }
        }
        [XafDisplayName("Phân bón")]
        [Association("VungTrong-PhanBons")]
        public XPCollection<PhanBon> PhanBons
        {
            get
            {
                return GetCollection<PhanBon>(nameof(PhanBons));
            }
        }
        [XafDisplayName("Sinh vật gây hại")]
        [Association("VungTrong-SinhVatGayHais")]
        public XPCollection<SinhVatGayHai> SinhVatGayHais
        {
            get
            {
                return GetCollection<SinhVatGayHai>(nameof(SinhVatGayHais));
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
    
        private LoaiCayTrong loaiCayTrong;
        [XafDisplayName("Loại cây trồng")]
        public LoaiCayTrong LoaiCayTrong
        {
            get { return loaiCayTrong; }
            set
            {
                if (loaiCayTrong == value) return;
                LoaiCayTrong prevLoaiCayTrong = loaiCayTrong;
                loaiCayTrong = value;
                if (IsLoading) return;
                if (prevLoaiCayTrong != null && prevLoaiCayTrong.VungTrong == this)
                    prevLoaiCayTrong.VungTrong = null;
                if (loaiCayTrong != null)
                    loaiCayTrong.VungTrong = this;
                OnChanged(nameof(LoaiCayTrong));
            }
        }
    }
}
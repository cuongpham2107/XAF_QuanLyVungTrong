using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System.ComponentModel;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenThuoc))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Thuốc BVTV")]
    [ImageName("medicine")]
    [NavigationItem(Menu.Danhmuc)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class ThuocBVTV : BaseObject, IListViewPopup, IRefreshNavigation
    { 
        public ThuocBVTV(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        string nhaCungCap;
        string lieuLuongSuDung;
        string nongDoPhaLoang;
        byte[] hinhAnh;
        int gia;
        DonGia donGia;
        string ghiChu;
        string tenThuoc;
        [XafDisplayName("Tên thuốc")]
        [RuleRequiredField("Bắt buộc phải có ThuocBVTV.TenThuoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenThuoc
        {
            get => tenThuoc;
            set => SetPropertyValue(nameof(TenThuoc), ref tenThuoc, value);
        }

        [XafDisplayName("Giá")]
        public int Gia
        {
            get => gia;
            set => SetPropertyValue(nameof(Gia), ref gia, value);
        }
        [XafDisplayName("Đơn giá")]
        public DonGia DonGia
        {
            get => donGia;
            set => SetPropertyValue(nameof(DonGia), ref donGia, value);
        }
        [XafDisplayName("Nồng độ pha loãng")]
        public string NongDoPhaLoang
        {
            get => nongDoPhaLoang;
            set => SetPropertyValue(nameof(NongDoPhaLoang), ref nongDoPhaLoang, value);
        }
        [XafDisplayName("Liều lượng sử dụng")]
        public string LieuLuongSuDung
        {
            get => lieuLuongSuDung;
            set => SetPropertyValue(nameof(LieuLuongSuDung), ref lieuLuongSuDung, value);
        }
        [XafDisplayName("Nhà cung cấp")]
        public string NhaCungCap
        {
            get => nhaCungCap;
            set => SetPropertyValue(nameof(NhaCungCap), ref nhaCungCap, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
       
        [XafDisplayName("Ảnh minh họa")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 300)]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
       

    }
}
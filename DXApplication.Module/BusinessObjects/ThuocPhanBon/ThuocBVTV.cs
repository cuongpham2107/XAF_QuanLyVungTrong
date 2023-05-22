using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenThuoc))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Thuốc BVTV")]
    [ImageName("medicine")]
    [NavigationItem(Menu.PhanBon)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class ThuocBVTV : BaseObject
    { 
        public ThuocBVTV(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        NhatKyCanhTac nhatKyCanhTac;
        MediaDataObject hinhAnh;
        string huongDan;
        DanhMucThuoc danhMucThuoc;
        string ghiChu;
        string loaiThuoc;
        string tenThuoc;
        [XafDisplayName("Tên thuốc")]
        [RuleRequiredField("Bắt buộc phải có ThuocBVTV.TenThuoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenThuoc
        {
            get => tenThuoc;
            set => SetPropertyValue(nameof(TenThuoc), ref tenThuoc, value);
        }
        [XafDisplayName("Loại thuốc")]
        [RuleRequiredField("Bắt buộc phải có ThuocBVTV.LoaiThuoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LoaiThuoc
        {
            get => loaiThuoc;
            set => SetPropertyValue(nameof(LoaiThuoc), ref loaiThuoc, value);
        }
        [XafDisplayName("Hướng dẫn sử dụng")]
        [RuleRequiredField("Bắt buộc phải có ThuocBVTV.HuongDan", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string HuongDan
        {
            get => huongDan;
            set => SetPropertyValue(nameof(HuongDan), ref huongDan, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Danh mục thuốc")]
        [Association("DanhMucThuoc-ThuocBVTVs")]
        public DanhMucThuoc DanhMucThuoc
        {
            get => danhMucThuoc;
            set => SetPropertyValue(nameof(DanhMucThuoc), ref danhMucThuoc, value);
        }
        [XafDisplayName("Ảnh minh họa")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 80)]
        public MediaDataObject HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Tài liệu")]
        [Association("ThuocBVTV-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [XafDisplayName("Nhật ký canh tác")]
        [Association("NhatKyCanhTac-ThuocBVTVs")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }

    }
}
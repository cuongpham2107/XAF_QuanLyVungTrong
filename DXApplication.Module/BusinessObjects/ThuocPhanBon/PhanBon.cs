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
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenPhanBon))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Phân bón")]
    [ImageName("fertilizer")]
    [NavigationItem(Menu.PhanBon)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class PhanBon : BaseObject
    { 
        public PhanBon(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        NhatKyCanhTac nhatKyCanhTac;
        MediaDataObject hinhAnh;
        DanhMucPhanBon danhMucPhanBon;
        string ghiChu;
        string kiThuatBon;
        string loaiPhanBon;
        string tenPhanBon;
        [XafDisplayName("Tên phân bón")]
        [RuleRequiredField("Bắt buộc phải có PhanBon.TenPhanBon", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenPhanBon
        {
            get => tenPhanBon;
            set => SetPropertyValue(nameof(TenPhanBon), ref tenPhanBon, value);
        }
        [XafDisplayName("Loại phân bón")]
        [RuleRequiredField("Bắt buộc phải có PhanBon.LoaiPhanBon", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LoaiPhanBon
        {
            get => loaiPhanBon;
            set => SetPropertyValue(nameof(LoaiPhanBon), ref loaiPhanBon, value);
        }
        [XafDisplayName("Kĩ thuật bón phân")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string KiThuatBon
        {
            get => kiThuatBon;
            set => SetPropertyValue(nameof(KiThuatBon), ref kiThuatBon, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Ảnh minh họa")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 80)]
        public MediaDataObject HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Tài liệu")]
        [Association("PhanBon-TaiLieus"), DevExpress.Xpo.Aggregated]
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
        [Association("NhatKyCanhTac-PhanBons")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
        [XafDisplayName("Danh mục phân bón")]
        [Association("DanhMucPhanBon-PhanBons")]
        public DanhMucPhanBon DanhMucPhanBon
        {
            get => danhMucPhanBon;
            set => SetPropertyValue(nameof(DanhMucPhanBon), ref danhMucPhanBon, value);
        }
    }
}
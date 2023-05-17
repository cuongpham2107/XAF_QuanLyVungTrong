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

        DanhMucPhanBon danhMucPhanBon;
        VungTrong vungTrong;
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
        [RuleRequiredField("Bắt buộc phải có PhanBon.KiThuatBon", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
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
        [Association("VungTrong-PhanBons")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("PhanBon-NhatKyBonPhanThuocs")]
        public XPCollection<NhatKyBonPhanThuoc> NhatKyBonPhanThuocs
        {
            get
            {
                return GetCollection<NhatKyBonPhanThuoc>(nameof(NhatKyBonPhanThuocs));
            }
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
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
    [DefaultProperty(nameof(TenDanhMuc))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Danh mục phân bón")]
    [ImageName("Detailed")]
    [NavigationItem(Menu.PhanBon)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class DanhMucPhanBon : BaseObject
    { 
        public DanhMucPhanBon(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();           
        }

        string ghiChu;
        string tenDanhMuc;
        [XafDisplayName("Tên danh mục")]
        [RuleRequiredField("Bắt buộc phải có DanhMucPhanBon.TenDanhMuc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenDanhMuc
        {
            get => tenDanhMuc;
            set => SetPropertyValue(nameof(TenDanhMuc), ref tenDanhMuc, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Phân bón")]
        [Association("DanhMucPhanBon-PhanBons")]
        public XPCollection<PhanBon> PhanBons
        {
            get
            {
                return GetCollection<PhanBon>(nameof(PhanBons));
            }
        }
    }
}
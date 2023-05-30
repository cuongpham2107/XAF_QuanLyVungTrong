using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Ticket
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenDanhMuc))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Danh mục hỏi đáp")]
    [ImageName("topic")]
    [NavigationItem(Menu.HoiDap)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class DanhMuc : BaseObject, IListViewPopup
    {
        public DanhMuc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string moTa;
        string tenDanhMuc;
        [XafDisplayName("Tên danh mục")]
        [RuleRequiredField("Bắt buộc phải có DanhMuc.TenDanhMuc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenDanhMuc
        {
            get => tenDanhMuc;
            set => SetPropertyValue(nameof(TenDanhMuc), ref tenDanhMuc, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(200)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Chủ đề hỏi đáp")]
        [Association("DanhMuc-DanhMucChuDes")]
        public XPCollection<DanhMucChuDe> DanhMucChuDe
        {
            get
            {
                return GetCollection<DanhMucChuDe>(nameof(DanhMucChuDe));
            }
        }
    }
}
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Ticket
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TieuDe))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Hỏi đáp")]
    [ImageName("Actions_Question")]
    [NavigationItem(Menu.HoiDap)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class Ticket : BaseObject
    { 
        public Ticket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string ghiChu;
        MediaDataObject file;
        string noiDung;
        string tieuDe;
        [XafDisplayName("Tiêu đề")]
        [RuleRequiredField("Bắt buộc phải có Ticket.TieuDe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TieuDe
        {
            get => tieuDe;
            set => SetPropertyValue(nameof(TieuDe), ref tieuDe, value);
        }
        [XafDisplayName("Nội dung câu hỏi")]
        [RuleRequiredField("Bắt buộc phải có Ticket.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Hình ảnh/Video đính kèm")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 100)]
        [RuleRequiredField("Bắt buộc phải có Ticket.File", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public MediaDataObject File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Hội thoại")]
        [Association("Ticket-HoiThoais"), DevExpress.Xpo.Aggregated]
        public XPCollection<HoiThoai> HoiThoais
        {
            get
            {
                return GetCollection<HoiThoai>(nameof(HoiThoais));
            }
        }
    }
}
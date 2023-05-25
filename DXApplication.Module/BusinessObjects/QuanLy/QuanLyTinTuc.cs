using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
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

namespace DXApplication.Module.BusinessObjects.QuanLy
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TieuDe))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Tin Tức")]
    [ImageName("newspaper")]
    [NavigationItem(Menu.QuanLy)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class QuanLyTinTuc : BaseObject
    { 
        public QuanLyTinTuc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ngayTao=DateTime.Now;
        }

        string slug;
        string seoContent;
        string metaContent;
        string moTa;
        DateTime ngayTao;
        MediaDataObject hinhAnh;
        string noiDung;
        string tieuDe;
        [XafDisplayName("Tiêu đề")]
        [RuleRequiredField("Bắt buộc phải có QuanLyTinTuc.TieuDe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TieuDe
        {
            get => tieuDe;
            set => SetPropertyValue(nameof(TieuDe), ref tieuDe, value);
        }
        [XafDisplayName("Slug")]
        [ModelDefault("AllowEdit","false")]
        //Tiêu Dề => tieu-de
        public string Slug
        {
            get => slug;
            set => SetPropertyValue(nameof(Slug), ref slug, value);
        }
        [Size(SizeAttribute.Unlimited)]
        [XafDisplayName("Mô Tả")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Nội dung")]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        [Size(SizeAttribute.Unlimited)]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Hình ảnh")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 100)]
        public MediaDataObject HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }

        [XafDisplayName("Ngày tạo")]
        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }
        [XafDisplayName("Meta Content")]
        public string MetaContent
        {
            get => metaContent;
            set => SetPropertyValue(nameof(MetaContent), ref metaContent, value);
        }
        [XafDisplayName("Seo Content")]
        public string SeoContent
        {
            get => seoContent;
            set => SetPropertyValue(nameof(SeoContent), ref seoContent, value);
        }
    }
}
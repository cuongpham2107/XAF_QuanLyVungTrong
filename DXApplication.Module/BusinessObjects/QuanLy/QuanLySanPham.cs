using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.SystemModule;
using DXApplication.Module.Common;

namespace DXApplication.Module.BusinessObjects.QuanLy
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenSanPham))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Sản phẩm")]
    [ImageName("apple")]
    [NavigationItem(Menu.QuanLy)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class QuanLySanPham : BaseObject
    { 
        public QuanLySanPham(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
          
        }

        string tieuChuan;
        string noiSanXuat;
        string donViTinh;
        string seoContent;
        string metaContent;
        int gia;
        MediaDataObject hinhAnh;
        string noiDung;
        string moTa;
        string slug;
        string tenSanPham;
        [XafDisplayName("Tên sản phẩm")]
        [RuleRequiredField("Bắt buộc phải có QuanLySanPham.TenSanPham", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenSanPham
        {
            get => tenSanPham;
            set => SetPropertyValue(nameof(TenSanPham), ref tenSanPham, value);
        }
        [ModelDefault("AllowEdit", "false")]
        [XafDisplayName("Slug")]
        public string Slug
        {
            get
            {
                
                return slug;
            }

            set => SetPropertyValue(nameof(Slug), ref slug, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited)]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Nội dung")]
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
        [XafDisplayName("Giá")]
        public int Gia
        {
            get => gia;
            set => SetPropertyValue(nameof(Gia), ref gia, value);
        }
        [XafDisplayName("Đơn vị tính")]
        public string DonViTinh
        {
            get => donViTinh;
            set => SetPropertyValue(nameof(DonViTinh), ref donViTinh, value);
        }
        [XafDisplayName("Nơi sản xuất")]
        public string NoiSanXuat
        {
            get => noiSanXuat;
            set => SetPropertyValue(nameof(NoiSanXuat), ref noiSanXuat, value);
        }
        [XafDisplayName("Tiêu chuẩn")]
        public string TieuChuan
        {
            get => tieuChuan;
            set => SetPropertyValue(nameof(TieuChuan), ref tieuChuan, value);
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
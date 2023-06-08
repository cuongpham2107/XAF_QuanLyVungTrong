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
using DXApplication.Module.Extension;

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
    public class QuanLyTinTuc : BaseObject, IListViewPopup
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
        DateTime? ngayTao;
        byte[] hinhAnh;
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
            get
            {
                if (!IsSaving && !IsLoading && TieuDe != null)
                {
                    string a = TieuDe.ToLower().Trim().Replace(" ", "-").ToString();
                    string[] VietnameseSigns = new string[]
                     {

                        "aAeEoOuUiIdDyY",

                        "áàạảãâấầậẩẫăắằặẳẵ",

                        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

                        "éèẹẻẽêếềệểễ",

                        "ÉÈẸẺẼÊẾỀỆỂỄ",

                        "óòọỏõôốồộổỗơớờợởỡ",

                        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

                        "úùụủũưứừựửữ",

                        "ÚÙỤỦŨƯỨỪỰỬỮ",

                        "íìịỉĩ",

                        "ÍÌỊỈĨ",

                        "đ",

                        "Đ",

                        "ýỳỵỷỹ",

                        "ÝỲỴỶỸ"

                     };

                    for (int i = 1; i < VietnameseSigns.Length; i++)

                    {

                        for (int j = 0; j < VietnameseSigns[i].Length; j++)

                            a = a.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

                    }
                    slug = a;
                }
                return slug;
            }
            set => SetPropertyValue(nameof(Slug), ref slug, value);
        }
        [XafDisplayName("Mô Tả")]
        [Size(200)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Nội dung")]
        [Size(200)]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Hình ảnh")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 350)]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }

        [XafDisplayName("Ngày tạo")]
        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "false")]
        public DateTime? NgayTao
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
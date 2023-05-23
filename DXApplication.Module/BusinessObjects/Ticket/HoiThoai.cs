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
using DevExpress.ExpressApp.Editors;

namespace DXApplication.Module.BusinessObjects.Ticket
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Ticket))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Hội thoại")]
    [ImageName("book-stack")]
    [NavigationItem(Menu.HoiDap)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class HoiThoai : BaseObject
    {
        public HoiThoai(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ngayTao = DateTime.Now;
            nguoiTao = SecuritySystem.CurrentUserName.ToString();
        }
        MediaDataObject file;
        Ticket ticket;
        MediaDataObject avatar;
        DateTime ngayTao;
        string nguoiTao;
        string noiDung;
        [XafDisplayName("Thời gian")]
        [VisibleInDetailView(false)]
        public string ThoiGian
        {
            get
            {
                if (!IsSaving && !IsLoading)
                {
                    TimeSpan x = DateTime.Now - ngayTao;
                    if (x.Days < 1)
                    {
                        if (x.Hours < 1)
                        {
                            var a = $"{NgayTao} ({x.Minutes} phút trước)";
                            return a;
                        }
                        else
                        {
                            var a = $"{NgayTao} ({x.Hours} giờ trước)";
                            return a;
                        }

                    }
                    else
                    {
                        if (x.Days > 30 && x.Days < 365)
                        {
                            var a = $"{NgayTao} ({x.Days / 30} tháng trước)";
                            return a;
                        }
                        else
                        {
                            if (x.Days < 30)
                            {
                                var a = $"{NgayTao} ({x.Days} ngày trước)";
                                return a;
                            }
                            else
                            {
                                var a = $"{NgayTao} ({x.Days / 365} năm trước)";
                                return a;
                            }
                        }
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Nội dung")]
        [Size(SizeAttribute.Unlimited),VisibleInListView(true)]
        [EditorAlias(EditorAliases.RichTextPropertyEditor)]
        [RuleRequiredField("Bắt buộc phải có HoiThoai.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Tải ảnh lên")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 100)]
        public MediaDataObject File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [XafDisplayName("Người tạo")]
        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "false")]
        public string NguoiTao
        {
            get => nguoiTao;
            set => SetPropertyValue(nameof(NguoiTao), ref nguoiTao, value);
        }
        [XafDisplayName("Ảnh đại diện")]
        [VisibleInDetailView(false)]
        [ImageEditor(ListViewImageEditorCustomHeight = 60, DetailViewImageEditorFixedHeight = 60)]
        public MediaDataObject Avatar
        {
            get => avatar;
            set => SetPropertyValue(nameof(Avatar), ref avatar, value);
        }
        [XafDisplayName("Ngày tạo")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [ModelDefault("DisplayFormat", "MM/dd/yy H:mm:ss")]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("Ticket-HoiThoais")]
        public Ticket Ticket
        {
            get => ticket;
            set => SetPropertyValue(nameof(Ticket), ref ticket, value);
        }
    }
}
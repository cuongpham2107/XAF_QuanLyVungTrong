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

        Ticket ticket;
        byte[] avatar;
        DateTime ngayTao;
        string nguoiTao;
        string noiDung;
        [XafDisplayName("Nội dung")]
        [RuleRequiredField("Bắt buộc phải có HoiThoai.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }

        [XafDisplayName("Người tạo")]
        [ModelDefault("AllowEdit", "false")]
        public string NguoiTao
        {
            get => nguoiTao;
            set => SetPropertyValue(nameof(NguoiTao), ref nguoiTao, value);
        }
        public byte[] Avatar
        {
            get => avatar;
            set => SetPropertyValue(nameof(Avatar), ref avatar, value);
        }
        [XafDisplayName("Ngày tạo")]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }

        [Association("Ticket-HoiThoais")]
        public Ticket Ticket
        {
            get => ticket;
            set => SetPropertyValue(nameof(Ticket), ref ticket, value);
        }
    }
}
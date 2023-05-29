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

namespace DXApplication.Module.BusinessObjects.HDSD
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenTaiLieu))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Hướng dẫn sử dụng")]
    [ImageName("manual")]
    [NavigationItem(Menu.HuongDanSuDung)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class HuongDanSuDung : BaseObject, IListViewPopup
    { 
        public HuongDanSuDung(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        FileData fileTaiLieu;
        string tenTaiLieu;
        [XafDisplayName("Tên Tài liệu")]
        [RuleRequiredField("Bắt buộc phải có HuongDanSuDung.TenTaiLieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenTaiLieu
        {
            get => tenTaiLieu;
            set => SetPropertyValue(nameof(TenTaiLieu), ref tenTaiLieu, value);
        }
        [XafDisplayName("File Tài liệu")]
        [RuleRequiredField("Bắt buộc phải có HuongDanSuDung.FileTaiLieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public FileData FileTaiLieu
        {
            get => fileTaiLieu;
            set => SetPropertyValue(nameof(FileTaiLieu), ref fileTaiLieu, value);
        }
    }
}
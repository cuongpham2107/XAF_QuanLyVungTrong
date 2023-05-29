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
using DXApplication.Module.Extension;

namespace DXApplication.Module.BusinessObjects.QuanLy
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenCay))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Cây trồng")]
    [ImageName("plant-a-tree")]
    [NavigationItem(Menu.QuanLy)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class QuanLyCayTrong : BaseObject, IListViewPopup
    { 
        public QuanLyCayTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        string nguonGoc;
        string giaTriSuDung;
        string ghiChu;
        string moTa;
        string dacDiem;
        string tenCay;
        [XafDisplayName("Tên cây trồng")]
        [RuleRequiredField("Bắt buộc phải có QuanLyCayTrong.TenCay", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCay
        {
            get => tenCay;
            set => SetPropertyValue(nameof(TenCay), ref tenCay, value);
        }
        [XafDisplayName("Đặc điểm")]
        [Size(200)]
        public string DacDiem
        {
            get => dacDiem;
            set => SetPropertyValue(nameof(DacDiem), ref dacDiem, value);
        }
        [XafDisplayName("Nguồn gốc")]
        [Size(200)]
        public string NguonGoc
        {
            get => nguonGoc;
            set => SetPropertyValue(nameof(NguonGoc), ref nguonGoc, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(200)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Giá trị sử dụng")]
        [Size(200)]
        public string GiaTriSuDung
        {
            get => giaTriSuDung;
            set => SetPropertyValue(nameof(GiaTriSuDung), ref giaTriSuDung, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}
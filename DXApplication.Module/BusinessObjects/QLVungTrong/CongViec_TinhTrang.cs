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
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenCongViec))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Công việc - Tình trạng")]
    [ImageName("wip")]
    [NavigationItem(Menu.Danhmuc)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    public class CongViec_TinhTrang : BaseObject
    { 
        public CongViec_TinhTrang(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        DateTime apDungDen;
        DateTime apDungTu;
        CongViec_TT congViec_TT;
        string tenCongViec;
        [XafDisplayName("Tên công việc")]
        [RuleRequiredField("Bắt buộc phải có CongViec_TinhTrang.TenCongViec", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCongViec
        {
            get => tenCongViec;
            set => SetPropertyValue(nameof(TenCongViec), ref tenCongViec, value);
        }
        [XafDisplayName("Loại")]
        public CongViec_TT CongViec_TT
        {
            get => congViec_TT;
            set => SetPropertyValue(nameof(CongViec_TT), ref congViec_TT, value);
        }
        [XafDisplayName("Áp dụng từ")]
        public DateTime ApDungTu
        {
            get => apDungTu;
            set => SetPropertyValue(nameof(ApDungTu), ref apDungTu, value);
        }
        [XafDisplayName("Áp dụng đến")]
        public DateTime ApDungDen
        {
            get => apDungDen;
            set => SetPropertyValue(nameof(ApDungDen), ref apDungDen, value);
        }
        //Sản phẩm
    }
}
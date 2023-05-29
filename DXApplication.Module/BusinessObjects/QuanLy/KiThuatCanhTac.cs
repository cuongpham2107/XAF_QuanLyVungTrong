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
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.QuanLy
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenKiThuat))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Kĩ thuật canh tác")]
    [ImageName("chinampa")]
    [NavigationItem(Menu.QuanLy)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class KiThuatCanhTac : BaseObject, IListViewPopup
    {
        public KiThuatCanhTac(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        LoaiCayTrong loaiCayTrong;
        string noiDung;
        string moTa;
        string tenKiThuat;
        [XafDisplayName("Tên kĩ thuật")]
        [RuleRequiredField("Bắt buộc phải có KiThuatCanhTac.TenKiThuat", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenKiThuat
        {
            get => tenKiThuat;
            set => SetPropertyValue(nameof(TenKiThuat), ref tenKiThuat, value);
        }
        [XafDisplayName("Mô tả")]
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
        [XafDisplayName("Loại cây trồng")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }
    }
}
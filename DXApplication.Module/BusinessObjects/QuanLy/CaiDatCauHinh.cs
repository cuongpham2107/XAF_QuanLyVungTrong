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

namespace DXApplication.Module.BusinessObjects.QuanLy
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TieuDe))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Cài đặt cấu hình")]
    [NavigationItem(Menu.QuanLy)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class CaiDatCauHinh : BaseObject, IListViewPopup
    {
        public CaiDatCauHinh(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string keyGoogleMap;
        string moTa;
        byte[] logo;
        string diaChi;
        string email;
        string sDT;
        string tieuDe;
        [XafDisplayName("Tiêu đề Website")]
        [RuleRequiredField("Bắt buộc phải có CaiDatCauHinh.TieuDe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TieuDe
        {
            get => tieuDe;
            set => SetPropertyValue(nameof(TieuDe), ref tieuDe, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(200)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Key Google Maps")]
        public string KeyGoogleMap
        {
            get => keyGoogleMap;
            set => SetPropertyValue(nameof(KeyGoogleMap), ref keyGoogleMap, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SDT
        {
            get => sDT;
            set => SetPropertyValue(nameof(SDT), ref sDT, value);
        }
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [XafDisplayName("Địa chỉ")]
        [Size(200)]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Logo")]
        [ImageEditor(ListViewImageEditorCustomHeight =100,DetailViewImageEditorFixedWidth =350)]
        public byte[] Logo
        {
            get => logo;
            set => SetPropertyValue(nameof(Logo), ref logo, value);
        }
        

    }
}
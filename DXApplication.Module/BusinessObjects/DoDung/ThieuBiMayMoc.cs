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

namespace DXApplication.Module.BusinessObjects.DoDung
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenThietBi))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Thiết máy móc")]
    [ImageName("service")]
    [NavigationItem(Menu.Danhmuc)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    public class ThieuBiMayMoc : BaseObject, IListViewPopup
    { 
        public ThieuBiMayMoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        string ghiChu;
        DateTime thoiHanSuDung;
        string huongDanSuDung;
        string tenThietBi;
        byte[] hinhAnh;
        [XafDisplayName("Tên thiết bị")]
        [RuleRequiredField("Bắt buộc phải có ThieuBiMayMoc.TenThietBi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenThietBi
        {
            get => tenThietBi;
            set => SetPropertyValue(nameof(TenThietBi), ref tenThietBi, value);
        }

        [XafDisplayName("Hạn sử dụng đến")]
        public DateTime ThoiHanSuDung
        {
            get => thoiHanSuDung;
            set => SetPropertyValue(nameof(ThoiHanSuDung), ref thoiHanSuDung, value);
        }
        [XafDisplayName("Hướng dẫn sử dụng")]
        public string HuongDanSuDung
        {
            get => huongDanSuDung;
            set => SetPropertyValue(nameof(HuongDanSuDung), ref huongDanSuDung, value);
        }
      
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Ảnh minh họa")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 200)]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        //Sản phẩm
       
    }
}
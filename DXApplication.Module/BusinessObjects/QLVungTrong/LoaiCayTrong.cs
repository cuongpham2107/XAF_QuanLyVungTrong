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

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenCay))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Loại Cây trồng")]
    [ImageName("tree")]
    [NavigationItem(Menu.Danhmuc)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomNestedListView(nameof(VungTrongs),AllowLink =false,AllowUnlink =false,AllowDelete =false)]
    public class LoaiCayTrong : BaseObject, IListViewPopup
    { 
        public LoaiCayTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();           
        }

        string nguonGoc;
        string ghiChu;
        string giaTriSuDung;
        string dacDiemSinhThai;
        string tenCay;
        [XafDisplayName("Tên Cây Trồng")]
        [RuleRequiredField("Bắt buộc phải có LoaiCayTrong.TenCay", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCay
        {
            get => tenCay;
            set => SetPropertyValue(nameof(TenCay), ref tenCay, value);
        }
        [XafDisplayName("Nguồn gốc")]
        public string NguonGoc
        {
            get => nguonGoc;
            set => SetPropertyValue(nameof(NguonGoc), ref nguonGoc, value);
        }
        [XafDisplayName("Đặc điểm")]
        public string DacDiemSinhThai
        {
            get => dacDiemSinhThai;
            set => SetPropertyValue(nameof(DacDiemSinhThai), ref dacDiemSinhThai, value);
        }
        [XafDisplayName("Giá trị sử dụng")]
        public string GiaTriSuDung
        {
            get => giaTriSuDung;
            set => SetPropertyValue(nameof(GiaTriSuDung), ref giaTriSuDung, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
                 
        [XafDisplayName("Vùng Trồng")]
        [Association("LoaiCayTrong-VungTrongs")]
        public XPCollection<VungTrong> VungTrongs
        {
            get
            {
                return GetCollection<VungTrong>(nameof(VungTrongs));
            }
        }

        [XafDisplayName("Quy trình sản xuất")]
        [Association("LoaiCayTrong-QuyTrinhSanXuats")]
        public XPCollection<QuyTrinhSanXuat> QuyTrinhSanXuats
        {
            get
            {
                return GetCollection<QuyTrinhSanXuat>(nameof(QuyTrinhSanXuats));
            }
        }
    }
}
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
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomNestedListView(nameof(VungTrongs),AllowLink =false,AllowUnlink =false,AllowDelete =false)]
    [CustomDetailView(Tabbed = true)]
    public class LoaiCayTrong : BaseObject
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
        string quyTrinhSanXuat;
        string giaTriSuDung;
        string dacDiemSinhThai;
        string tenKhac;
        string tenCay;
        [XafDisplayName("Tên Cây Trồng")]
        [RuleRequiredField("Bắt buộc phải có LoaiCayTrong.TenCay", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCay
        {
            get => tenCay;
            set => SetPropertyValue(nameof(TenCay), ref tenCay, value);
        }
        [XafDisplayName("Nguồn gốc")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string NguonGoc
        {
            get => nguonGoc;
            set => SetPropertyValue(nameof(NguonGoc), ref nguonGoc, value);
        }
        [XafDisplayName("Tên khác")]
        public string TenKhac
        {
            get => tenKhac;
            set => SetPropertyValue(nameof(TenKhac), ref tenKhac, value);
        }
        [XafDisplayName("Đặc điểm")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string DacDiemSinhThai
        {
            get => dacDiemSinhThai;
            set => SetPropertyValue(nameof(DacDiemSinhThai), ref dacDiemSinhThai, value);
        }
        [XafDisplayName("Giá trị sử dụng")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GiaTriSuDung
        {
            get => giaTriSuDung;
            set => SetPropertyValue(nameof(GiaTriSuDung), ref giaTriSuDung, value);
        }
        [XafDisplayName("Quy trình sản xuất")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string QuyTrinhSanXuat
        {
            get => quyTrinhSanXuat;
            set => SetPropertyValue(nameof(QuyTrinhSanXuat), ref quyTrinhSanXuat, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Tài liệu đính kèm")]
        [Association("LoaiCayTrong-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
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
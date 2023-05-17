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

        string ghiChu;
        string quyTrinhSanXuat;
        string giaTriSuDung;
        string phamViApDung;
        string phanBo;
        string dacDiemSinhVatHoc;
        string dacDiemSinhThai;
        string tenKhac;
        string loai;
        string boCay;
        string hoCay;
        string tenKhoaHoc;
        string tenCay;
        [XafDisplayName("Tên Cây Trồng")]
        [RuleRequiredField("Bắt buộc phải có LoaiCayTrong.TenCay", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenCay
        {
            get => tenCay;
            set => SetPropertyValue(nameof(TenCay), ref tenCay, value);
        }
        [XafDisplayName("Tên Khoa học")]
        public string TenKhoaHoc
        {
            get => tenKhoaHoc;
            set => SetPropertyValue(nameof(TenKhoaHoc), ref tenKhoaHoc, value);
        }
        [XafDisplayName("Họ cây")]
        public string HoCay
        {
            get => hoCay;
            set => SetPropertyValue(nameof(HoCay), ref hoCay, value);
        }
        [XafDisplayName("Bộ cây")]
        public string BoCay
        {
            get => boCay;
            set => SetPropertyValue(nameof(BoCay), ref boCay, value);
        }
        [XafDisplayName("Loài cây")]
        public string Loai
        {
            get => loai;
            set => SetPropertyValue(nameof(Loai), ref loai, value);
        }
        [XafDisplayName("Tên khác")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string TenKhac
        {
            get => tenKhac;
            set => SetPropertyValue(nameof(TenKhac), ref tenKhac, value);
        }
        [XafDisplayName("Đặc điểm sinh thái")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string DacDiemSinhThai
        {
            get => dacDiemSinhThai;
            set => SetPropertyValue(nameof(DacDiemSinhThai), ref dacDiemSinhThai, value);
        }
        [XafDisplayName("Đặc điểm sinh vật học")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string DacDiemSinhVatHoc
        {
            get => dacDiemSinhVatHoc;
            set => SetPropertyValue(nameof(DacDiemSinhVatHoc), ref dacDiemSinhVatHoc, value);
        }
        [XafDisplayName("Phân bố")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string PhanBo
        {
            get => phanBo;
            set => SetPropertyValue(nameof(PhanBo), ref phanBo, value);
        }
        [XafDisplayName("Phạm vi áp dụng")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string PhamViApDung
        {
            get => phamViApDung;
            set => SetPropertyValue(nameof(PhamViApDung), ref phamViApDung, value);
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
      
       
        private VungTrong vungTrong;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [XafDisplayName("Vùng Trồng")]
        public VungTrong VungTrong
        {
            get { return vungTrong; }
            set
            {
                if (vungTrong == value) return;
                VungTrong prevVungTrong = vungTrong;
                vungTrong = value;
                if (IsLoading) return;
                if (prevVungTrong != null && prevVungTrong.LoaiCayTrong == this)
                    prevVungTrong.LoaiCayTrong = null;
                if (vungTrong != null)
                    vungTrong.LoaiCayTrong = this;
                OnChanged(nameof(VungTrong));
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
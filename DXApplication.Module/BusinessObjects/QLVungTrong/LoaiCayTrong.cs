using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
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

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class LoaiCayTrong : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public LoaiCayTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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

        public string TenCay
        {
            get => tenCay;
            set => SetPropertyValue(nameof(TenCay), ref tenCay, value);
        }

        public string TenKhoaHoc
        {
            get => tenKhoaHoc;
            set => SetPropertyValue(nameof(TenKhoaHoc), ref tenKhoaHoc, value);
        }

        public string HoCay
        {
            get => hoCay;
            set => SetPropertyValue(nameof(HoCay), ref hoCay, value);
        }

        public string BoCay
        {
            get => boCay;
            set => SetPropertyValue(nameof(BoCay), ref boCay, value);
        }

        public string Loai
        {
            get => loai;
            set => SetPropertyValue(nameof(Loai), ref loai, value);
        }

        public string TenKhac
        {
            get => tenKhac;
            set => SetPropertyValue(nameof(TenKhac), ref tenKhac, value);
        }

        public string DacDiemSinhThai
        {
            get => dacDiemSinhThai;
            set => SetPropertyValue(nameof(DacDiemSinhThai), ref dacDiemSinhThai, value);
        }

        public string DacDiemSinhVatHoc
        {
            get => dacDiemSinhVatHoc;
            set => SetPropertyValue(nameof(DacDiemSinhVatHoc), ref dacDiemSinhVatHoc, value);
        }

        public string PhanBo
        {
            get => phanBo;
            set => SetPropertyValue(nameof(PhanBo), ref phanBo, value);
        }

        public string PhamViApDung
        {
            get => phamViApDung;
            set => SetPropertyValue(nameof(PhamViApDung), ref phamViApDung, value);
        }

        public string GiaTriSuDung
        {
            get => giaTriSuDung;
            set => SetPropertyValue(nameof(GiaTriSuDung), ref giaTriSuDung, value);
        }

        public string QuyTrinhSanXuat
        {
            get => quyTrinhSanXuat;
            set => SetPropertyValue(nameof(QuyTrinhSanXuat), ref quyTrinhSanXuat, value);
        }
        
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [Association("LoaiCayTrong-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }

        private VungTrong vungTrong;
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
    }
}
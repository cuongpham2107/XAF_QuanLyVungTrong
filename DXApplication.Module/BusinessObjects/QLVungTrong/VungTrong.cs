using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
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
    public class VungTrong : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public VungTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string hinhThucCanhTac;
        string sanLuongDuKien;
        bool hoatDong;
        string loaiDat;
        double dienTichCanhTac;
        double dienTichCoSo;
        string quyMo;
        string tieuChuan;
        int namCap;
        string soCoSoCap;
        string diaChi;
        string maSo;

        public string MaSo
        {
            get => maSo;
            set => SetPropertyValue(nameof(MaSo), ref maSo, value);
        }

        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }

        public string SoCoSoCap
        {
            get => soCoSoCap;
            set => SetPropertyValue(nameof(SoCoSoCap), ref soCoSoCap, value);
        }

        public int NamCap
        {
            get => namCap;
            set => SetPropertyValue(nameof(NamCap), ref namCap, value);
        }

        public string TieuChuan
        {
            get => tieuChuan;
            set => SetPropertyValue(nameof(TieuChuan), ref tieuChuan, value);
        }

        public string QuyMo
        {
            get => quyMo;
            set => SetPropertyValue(nameof(QuyMo), ref quyMo, value);
        }

        public double DienTichCoSo
        {
            get => dienTichCoSo;
            set => SetPropertyValue(nameof(DienTichCoSo), ref dienTichCoSo, value);
        }

        public double DienTichCanhTac
        {
            get => dienTichCanhTac;
            set => SetPropertyValue(nameof(DienTichCanhTac), ref dienTichCanhTac, value);
        }

        public string LoaiDat
        {
            get => loaiDat;
            set => SetPropertyValue(nameof(LoaiDat), ref loaiDat, value);
        }

        public bool HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }

        public string SanLuongDuKien
        {
            get => sanLuongDuKien;
            set => SetPropertyValue(nameof(SanLuongDuKien), ref sanLuongDuKien, value);
        }
        
        public string HinhThucCanhTac
        {
            get => hinhThucCanhTac;
            set => SetPropertyValue(nameof(HinhThucCanhTac), ref hinhThucCanhTac, value);
        }
        [Association("VungTrong-ThuocBVTVs")]
        public XPCollection<ThuocBVTV> ThuocBVTVs
        {
            get
            {
                return GetCollection<ThuocBVTV>(nameof(ThuocBVTVs));
            }
        }
        [Association("VungTrong-PhanBons")]
        public XPCollection<PhanBon> PhanBons
        {
            get
            {
                return GetCollection<PhanBon>(nameof(PhanBons));
            }
        }
        [Association("VungTrong-SinhVatGayHais")]
        public XPCollection<SinhVatGayHai> SinhVatGayHais
        {
            get
            {
                return GetCollection<SinhVatGayHai>(nameof(SinhVatGayHais));
            }
        }
        [Association("VungTrong-TaiLieus")]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        private LoaiCayTrong loaiCayTrong;
        public LoaiCayTrong LoaiCayTrong
        {
            get { return loaiCayTrong; }
            set
            {
                if (loaiCayTrong == value) return;
                LoaiCayTrong prevLoaiCayTrong = loaiCayTrong;
                loaiCayTrong = value;
                if (IsLoading) return;
                if (prevLoaiCayTrong != null && prevLoaiCayTrong.VungTrong == this)
                    prevLoaiCayTrong.VungTrong = null;
                if (loaiCayTrong != null)
                    loaiCayTrong.VungTrong = this;
                OnChanged(nameof(LoaiCayTrong));
            }
        }
    }
}
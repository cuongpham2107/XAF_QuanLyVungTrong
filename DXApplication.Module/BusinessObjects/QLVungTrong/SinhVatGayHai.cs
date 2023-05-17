using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class SinhVatGayHai : BaseObject
    { 
        public SinhVatGayHai(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        VungTrong vungTrong;
        string ghiChu;
        string bienPhapPhongTru;
        string moTa;
        MucDoPhoBien mucDoPhoBien;
        string loaiSinhVat;
        string tenSinhVat;

        public string TenSinhVat
        {
            get => tenSinhVat;
            set => SetPropertyValue(nameof(TenSinhVat), ref tenSinhVat, value);
        }

        public string LoaiSinhVat
        {
            get => loaiSinhVat;
            set => SetPropertyValue(nameof(LoaiSinhVat), ref loaiSinhVat, value);
        }

        public MucDoPhoBien MucDoPhoBien
        {
            get => mucDoPhoBien;
            set => SetPropertyValue(nameof(MucDoPhoBien), ref mucDoPhoBien, value);
        }

        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }

        public string BienPhapPhongTru
        {
            get => bienPhapPhongTru;
            set => SetPropertyValue(nameof(BienPhapPhongTru), ref bienPhapPhongTru, value);
        }

        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [Association("SinhVatGayHai-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        
        [Association("VungTrong-SinhVatGayHais")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
    }
}
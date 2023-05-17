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
    public class NhatKyCanhTac : BaseObject
    { 
        public NhatKyCanhTac(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        bool phatHienSauBenh;
        string ghiChu;
        string moTa;
        DateTime thoiGian;
        string hoatDong;
        string giaiDoanCanhTac;

        public string GiaiDoanCanhTac
        {
            get => giaiDoanCanhTac;
            set => SetPropertyValue(nameof(GiaiDoanCanhTac), ref giaiDoanCanhTac, value);
        }

        public string HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }

        public DateTime ThoiGian
        {
            get => thoiGian;
            set => SetPropertyValue(nameof(ThoiGian), ref thoiGian, value);
        }

        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        
        public bool PhatHienSauBenh
        {
            get => phatHienSauBenh;
            set => SetPropertyValue(nameof(PhatHienSauBenh), ref phatHienSauBenh, value);
        }
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [Association("NhatKyCanhTac-TaiLieus")]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
    }
}
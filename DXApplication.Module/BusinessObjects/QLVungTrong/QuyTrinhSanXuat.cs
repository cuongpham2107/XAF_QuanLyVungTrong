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
    public class QuyTrinhSanXuat : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public QuyTrinhSanXuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string baoQuan;
        string thuHai;
        string suDungThuoc;
        string bonPhan;
        string sauBenh;
        string thoiVu;
        string kiThuatChamSoc;
        string kiThuatTrong;
        string mucTieu;
        int namBanHanh;

        public int NamBanHanh
        {
            get => namBanHanh;
            set => SetPropertyValue(nameof(NamBanHanh), ref namBanHanh, value);
        }

        public string MucTieu
        {
            get => mucTieu;
            set => SetPropertyValue(nameof(MucTieu), ref mucTieu, value);
        }

        public string KiThuatTrong
        {
            get => kiThuatTrong;
            set => SetPropertyValue(nameof(KiThuatTrong), ref kiThuatTrong, value);
        }

        public string KiThuatChamSoc
        {
            get => kiThuatChamSoc;
            set => SetPropertyValue(nameof(KiThuatChamSoc), ref kiThuatChamSoc, value);
        }

        public string ThoiVu
        {
            get => thoiVu;
            set => SetPropertyValue(nameof(ThoiVu), ref thoiVu, value);
        }

        public string SauBenh
        {
            get => sauBenh;
            set => SetPropertyValue(nameof(SauBenh), ref sauBenh, value);
        }

        public string BonPhan
        {
            get => bonPhan;
            set => SetPropertyValue(nameof(BonPhan), ref bonPhan, value);
        }

        public string SuDungThuoc
        {
            get => suDungThuoc;
            set => SetPropertyValue(nameof(SuDungThuoc), ref suDungThuoc, value);
        }

        public string ThuHai
        {
            get => thuHai;
            set => SetPropertyValue(nameof(ThuHai), ref thuHai, value);
        }
        
        public string BaoQuan
        {
            get => baoQuan;
            set => SetPropertyValue(nameof(BaoQuan), ref baoQuan, value);
        }
        [Association("QuyTrinhSanXuat-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
    }
}
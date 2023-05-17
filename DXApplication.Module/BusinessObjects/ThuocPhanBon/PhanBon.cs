using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class PhanBon : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public PhanBon(Session session)
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
        string kiThuatBon;
        string loaiPhanBon;
        string tenPhanBon;

        public string TenPhanBon
        {
            get => tenPhanBon;
            set => SetPropertyValue(nameof(TenPhanBon), ref tenPhanBon, value);
        }

        public string LoaiPhanBon
        {
            get => loaiPhanBon;
            set => SetPropertyValue(nameof(LoaiPhanBon), ref loaiPhanBon, value);
        }

        public string KiThuatBon
        {
            get => kiThuatBon;
            set => SetPropertyValue(nameof(KiThuatBon), ref kiThuatBon, value);
        }

        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [Association("PhanBon-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        
        [Association("VungTrong-PhanBons")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
    }
}
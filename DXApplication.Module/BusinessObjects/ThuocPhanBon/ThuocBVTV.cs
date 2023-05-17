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
    public class ThuocBVTV : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public ThuocBVTV(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        VungTrong vungTrong;
        DanhMucThuoc danhMucThuoc;
        string ghiChu;
        string loaiThuoc;
        string tenThuoc;

        public string TenThuoc
        {
            get => tenThuoc;
            set => SetPropertyValue(nameof(TenThuoc), ref tenThuoc, value);
        }

        public string LoaiThuoc
        {
            get => loaiThuoc;
            set => SetPropertyValue(nameof(LoaiThuoc), ref loaiThuoc, value);
        }

        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

        [Association("DanhMucThuoc-ThuocBVTVs")]
        public DanhMucThuoc DanhMucThuoc
        {
            get => danhMucThuoc;
            set => SetPropertyValue(nameof(DanhMucThuoc), ref danhMucThuoc, value);
        }
        [Association("ThuocBVTV-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        
        [Association("VungTrong-ThuocBVTVs")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
    }
}
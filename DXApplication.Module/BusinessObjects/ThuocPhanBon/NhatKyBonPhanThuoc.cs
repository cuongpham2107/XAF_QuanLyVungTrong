using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(LoaiSuDung))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Nhật ký bón phân/Thuốc")]
    [ImageName("book-stack")]
    [NavigationItem(Menu.PhanBon)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    [Appearance("a", AppearanceItemType = "ViewItem", TargetItems = "ThuocBVTV",
    Criteria = "LoaiSuDung=0", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a1", AppearanceItemType = "ViewItem", TargetItems = "PhanBon",
    Criteria = "LoaiSuDung=1", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    public class NhatKyBonPhanThuoc : BaseObject
    {
        public NhatKyBonPhanThuoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        ThuocBVTV thuocBVTV;
        PhanBon phanBon;
        string lieuLuong;
        string phuongPhap;
        string lyDo;
        LoaiSuDung loaiSuDung;
        [XafDisplayName("Loại sử dụng")]
        public LoaiSuDung LoaiSuDung
        {
            get => loaiSuDung;
            set => SetPropertyValue(nameof(LoaiSuDung), ref loaiSuDung, value);
        }
        [XafDisplayName("Lý do sử dụng")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhanThuoc.LyDo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LyDo
        {
            get => lyDo;
            set => SetPropertyValue(nameof(LyDo), ref lyDo, value);
        }
        [XafDisplayName("Phương pháp bón")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhanThuoc.PhuongPhap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string PhuongPhap
        {
            get => phuongPhap;
            set => SetPropertyValue(nameof(PhuongPhap), ref phuongPhap, value);
        }
        [XafDisplayName("Liều lượng")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhanThuoc.LieuLuong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LieuLuong
        {
            get => lieuLuong;
            set => SetPropertyValue(nameof(LieuLuong), ref lieuLuong, value);
        }
        [XafDisplayName("Phân Bón")]
        [Association("PhanBon-NhatKyBonPhanThuocs")]
        public PhanBon PhanBon
        {
            get => phanBon;
            set => SetPropertyValue(nameof(PhanBon), ref phanBon, value);
        }
        [XafDisplayName("Thuốc BVTV")]
        [Association("ThuocBVTV-NhatKyBonPhanThuocs")]
        public ThuocBVTV ThuocBVTV
        {
            get => thuocBVTV;
            set => SetPropertyValue(nameof(ThuocBVTV), ref thuocBVTV, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("NhatKyBonPhanThuoc-NhatKyCanhTacs")]
        public XPCollection<NhatKyCanhTac> NhatKyCanhTacs
        {
            get
            {
                return GetCollection<NhatKyCanhTac>(nameof(NhatKyCanhTacs));
            }
        }
    }
}
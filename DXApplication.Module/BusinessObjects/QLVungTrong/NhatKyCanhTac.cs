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
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(HoatDong))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Nhật ký canh tác")]
    [ImageName("book-stack")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    [Appearance("a", AppearanceItemType = "ViewItem", TargetItems = "NhatKyBonPhans,NhatKySuDungThuocs",
    Criteria = "HoatD=2", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a3", AppearanceItemType = "ViewItem", TargetItems = "NhatKySuDungThuocs,HoatDong",
    Criteria = "HoatD=0", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a4", AppearanceItemType = "ViewItem", TargetItems = "NhatKyBonPhans,HoatDong",
    Criteria = "HoatD=1", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a1", AppearanceItemType = "ViewItem", TargetItems = "SinhVatGayHais",
    Criteria = "PhatHienSauBenh=false", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 2)]
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

        VungTrong vungTrong;
        HoatDong hoatD;
        bool phatHienSauBenh;
        string ghiChu;
        string moTa;
        DateTime thoiGian;
        string hoatDong;
        string giaiDoanCanhTac;
        [XafDisplayName("Giai đoạn canh tác")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.GiaiDoanCanhTac", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string GiaiDoanCanhTac
        {
            get => giaiDoanCanhTac;
            set => SetPropertyValue(nameof(GiaiDoanCanhTac), ref giaiDoanCanhTac, value);
        }
        [XafDisplayName("Loại Hoạt động")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.HoatDong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string HoatDong
        {
            get
            {
                if (!IsSaving && !IsLoading && HoatD != Blazor.Common.Enums.HoatDong.Khac)
                {
                    hoatDong = HoatD.ToString();
                }
                if (!IsSaving && !IsLoading && HoatD == Blazor.Common.Enums.HoatDong.Khac)
                {
                    hoatDong = null;
                }
                return hoatDong;
            }

            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }
        [XafDisplayName("Hoạt động")]
        public HoatDong HoatD
        {
            get => hoatD;
            set => SetPropertyValue(nameof(HoatD), ref hoatD, value);
        }
        [XafDisplayName("Thời gian")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.ThoiGian", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime ThoiGian
        {
            get => thoiGian;
            set => SetPropertyValue(nameof(ThoiGian), ref thoiGian, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.MoTa", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Phát hiện sâu bệnh")]
        [CaptionsForBoolValues("Có", "Không")]
        public bool PhatHienSauBenh
        {
            get => phatHienSauBenh;
            set => SetPropertyValue(nameof(PhatHienSauBenh), ref phatHienSauBenh, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Tài liệu")]
        [Association("NhatKyCanhTac-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        [XafDisplayName("Sinh vật gây hại")]
        [Association("NhatKyCanhTac-SinhVatGayHais"), DevExpress.Xpo.Aggregated]
        public XPCollection<SinhVatGayHai> SinhVatGayHais
        {
            get
            {
                return GetCollection<SinhVatGayHai>(nameof(SinhVatGayHais));
            }
        }
        [XafDisplayName("Bón phân")]
        [Association("NhatKyCanhTac-NhatKyBonPhans"), DevExpress.Xpo.Aggregated]
        public XPCollection<NhatKyBonPhan> NhatKyBonPhans
        {
            get
            {
                return GetCollection<NhatKyBonPhan>(nameof(NhatKyBonPhans));
            }
        }
        [XafDisplayName("Thuốc BVTV")]
        [Association("NhatKyCanhTac-NhatKySuDungThuocs"), DevExpress.Xpo.Aggregated]
        public XPCollection<NhatKySuDungThuoc> NhatKySuDungThuocs
        {
            get
            {
                return GetCollection<NhatKySuDungThuoc>(nameof(NhatKySuDungThuocs));
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("VungTrong-NhatKyCanhTacs")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
    }
}
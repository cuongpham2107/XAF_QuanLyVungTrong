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
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(GiaiDoanCanhTac))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Nhật ký canh tác")]
    [ImageName("writing")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomRootListView(AllowNew =false)]
    [CustomDetailView(AllowNew =false)]
    [RuleCriteria("ThoiGian <= ThoiGianKT",
    CustomMessageTemplate = "Thời gian kết thúc phải lớn hơn thời gian bắt đầu!")]

    [CustomNestedListView(nameof(PhanBons),AllowDelete =false,AllowLink =true,AllowUnlink =true)]
    [CustomNestedListView(nameof(ThuocBVTVs), AllowDelete = false, AllowLink = true, AllowUnlink = true)]
    [CustomNestedListView(nameof(SinhVatGayHais), AllowDelete = false, AllowLink = true, AllowUnlink = true)]

    [Appearance("ASF", AppearanceItemType = "ViewItem", TargetItems = "PhatHienSauBenh",
    Criteria = "PhatHienSauBenh=true", Context = "Any", FontColor = "Red", Priority = 3)]
    [Appearance("a5", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "TrangThai=1", Context = "Any", BackColor = "204,255,204", Priority = 3)]
    [Appearance("a6", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "TrangThai=0", Context = "Any", BackColor = "204,204,255", Priority = 3)]
    [Appearance("a", AppearanceItemType = "ViewItem", TargetItems = "HoatDong",
    Criteria = "HoatD!=7", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a3", AppearanceItemType = "ViewItem", TargetItems = "PhanBons",
    Criteria = "HoatD!=0", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
    [Appearance("a4", AppearanceItemType = "ViewItem", TargetItems = "ThuocBVTVs",
    Criteria = "HoatD!=1", Context = "Any", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Enabled = false, Priority = 1)]
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
            thoiGian=DateTime.Now;
        }

        DateTime thoiGianKT;
        TrangThai trangThai;
        VungTrong vungTrong;
        HoatDong hoatD;
        bool phatHienSauBenh;
        string ghiChu;
        string moTa;
        DateTime thoiGian;
        string hoatDong;
        GiaiDoanCanhTac giaiDoanCanhTac;
        [XafDisplayName("Giai đoạn canh tác")]
        public GiaiDoanCanhTac GiaiDoanCanhTac
        {
            get => giaiDoanCanhTac;
            set => SetPropertyValue(nameof(GiaiDoanCanhTac), ref giaiDoanCanhTac, value);
        }
        [XafDisplayName("Hoạt động khác")]
        public string HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }
        [XafDisplayName("Hoạt động")]
        public HoatDong HoatD
        {
            get => hoatD;
            set => SetPropertyValue(nameof(HoatD), ref hoatD, value);
        }
        [XafDisplayName("Thời gian bắt đầu")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.ThoiGian", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime ThoiGian
        {
            get => thoiGian;
            set => SetPropertyValue(nameof(ThoiGian), ref thoiGian, value);
        }
        [XafDisplayName("Thời gian kết thúc")]
        public DateTime ThoiGianKT
        {
            get => thoiGianKT;
            set => SetPropertyValue(nameof(ThoiGianKT), ref thoiGianKT, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
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
        [XafDisplayName("Trạng thái")]
        public TrangThai TrangThai
        {
            get
            {
                if (!IsSaving && !IsLoading &&ThoiGianKT>ThoiGian&& ThoiGianKT < DateTime.Now)
                {
                    trangThai = TrangThai.DaHoanThanh;
                }
                return trangThai;
            }

            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
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
        [Association("NhatKyCanhTac-SinhVatGayHais")]
        public XPCollection<SinhVatGayHai> SinhVatGayHais
        {
            get
            {
                return GetCollection<SinhVatGayHai>(nameof(SinhVatGayHais));
            }
        }
        [XafDisplayName("Bón phân")]
        [Association("NhatKyCanhTac-PhanBons")]
        public XPCollection<PhanBon> PhanBons
        {
            get
            {
                return GetCollection<PhanBon>(nameof(PhanBons));
            }
        }
        [XafDisplayName("Thuốc BVTV")]
        [Association("NhatKyCanhTac-ThuocBVTVs")]
        public XPCollection<ThuocBVTV> ThuocBVTVs
        {
            get
            {
                return GetCollection<ThuocBVTV>(nameof(ThuocBVTVs));
            }
        }
        [XafDisplayName("Vùng Trồng")]
        [VisibleInDetailView(false)]
        [Association("VungTrong-NhatKyCanhTacs")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
        [Action(ToolTip = "Hoàn thành", Caption = "Hoàn thành", ConfirmationMessage = "Xác nhận hoàn thành?")]
        public void StatusChanged()
        {
            TrangThai = TrangThai.DaHoanThanh;
        }
    }
}
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
    [DefaultProperty(nameof(TenNhatKy))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Nhật ký canh tác")]
    [ImageName("notes")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomRootListView(AllowNew =false)]
    [CustomDetailView(AllowNew =false)]
    [CustomNestedListView(nameof(ChiTietNhatKys), AllowUnlink = false,AllowLink = false , FieldsToSum = new[] { "TongGioLamViec:Sum" })]

    [RuleCriteria("NgayBatDau < NgayKetThuc",
    CustomMessageTemplate = "Ngày kết thúc phải lớn hơn ngày bắt đầu")]
    [RuleCriteria("NgayNuoiTrong < NgayThuHoach",
    CustomMessageTemplate = "Ngày thu hoạch phải lớn hơn ngày nuôi trồng")]
    [RuleCriteria("NgayNuoiTrong>=NgayBatDau",
    CustomMessageTemplate = "Ngày nuôi trồng phải lớn hơn hoặc bằng ngày bắt đầu")]
    [RuleCriteria("NgayThuHoach<=NgayKetThuc",
    CustomMessageTemplate = "Ngày thu hoạch phải lớn hơn hoặc bằng ngày kết thúc")]

    [Appearance("NgayKetThuc", AppearanceItemType = "ViewItem", TargetItems = "NgayKetThuc",
     Context = "ListView", FontColor = "Black",BackColor = "Gold", Priority = 3)]
    [Appearance("SanLuong", AppearanceItemType = "ViewItem", TargetItems = "SanLuong",
     Context = "ListView", BackColor = "DeepSkyBlue", Priority = 3)]

    [Appearance("a5", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "[TrangThai] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThai,DangXyLy#", Context = "Any", BackColor = "204,255,204", Priority = 3)]
    [Appearance("a6", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "[TrangThai] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThai,DaHoanThanh#", Context = "Any", BackColor = "204,204,255", Priority = 3)]


    public class NhatKyCanhTac : BaseObject, IDetailViewCount
    { 
        public NhatKyCanhTac(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            nam = $"{ DateTime.Now.Year}";
            ngayBatDau=DateTime.Now;
        }
        string datCoSo;
        DonViSanLuong donViSanLuong;
        DateTime? ngayKetThuc;
        DateTime? ngayThuHoach;
        DateTime? ngayNuoiTrong;
        DateTime? ngayBatDau;
        string sanLuong;
        string nam;
        string tenNhatKy;
        TrangThai trangThai;
        VungTrong vungTrong;
        string ghiChu;

        [XafDisplayName("Tên nhật ký")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.TenNhatKy", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenNhatKy
        {
            get => tenNhatKy;
            set => SetPropertyValue(nameof(TenNhatKy), ref tenNhatKy, value);
        }
        [XafDisplayName("Vùng Trồng")]
        [VisibleInDetailView(true)]
        [Association("VungTrong-NhatKyCanhTacs")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
        [XafDisplayName("Diện tích chăm sóc")]
        [ModelDefault("AllowEdit","False")]
        public string DatCoSo
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(Dat_CoSos.Count > 0)
                    {
                        if(Dat_CoSos.Sum(x => x.DienTich) > 0)
                        {
                            return Dat_CoSos.Sum(x => x.DienTich).ToString();
                        }
                        
                    }
                }
                return null;
            }
            set => SetPropertyValue(nameof(DatCoSo), ref datCoSo, value);
        }
        //sản phẩm
        [XafDisplayName("Năm nhật ký")]
        [RuleRequiredField("Bắt buộc phải có NhatKyCanhTac.Nam", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }

        [XafDisplayName("Trạng thái")]
        public TrangThai TrangThai
        {
            get => trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
        }
       
        [XafDisplayName("Sản lượng")]
        public string SanLuong
        {
            get => sanLuong;
            set => SetPropertyValue(nameof(SanLuong), ref sanLuong, value);
        }
        [XafDisplayName("ĐVT")]
        public DonViSanLuong DonViSanLuong
        {
            get => donViSanLuong;
            set => SetPropertyValue(nameof(DonViSanLuong), ref donViSanLuong, value);
        }
        [XafDisplayName("Ngày bắt đầu")]
        public DateTime? NgayBatDau
        {
            get => ngayBatDau;
            set => SetPropertyValue(nameof(NgayBatDau), ref ngayBatDau, value);
        }
        [XafDisplayName("Ngày nuôi/trồng")]
        public DateTime? NgayNuoiTrong
        {
            get => ngayNuoiTrong;
            set => SetPropertyValue(nameof(NgayNuoiTrong), ref ngayNuoiTrong, value);
        }
        [XafDisplayName("Ngày thu hoạch")]
        public DateTime? NgayThuHoach
        {
            get => ngayThuHoach;
            set => SetPropertyValue(nameof(NgayThuHoach), ref ngayThuHoach, value);
        }
        [XafDisplayName("Ngày kết thúc")]
        public DateTime?  NgayKetThuc
        {
            get => ngayKetThuc;
            set => SetPropertyValue(nameof(NgayKetThuc), ref ngayKetThuc, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

        [Action(ToolTip = "Hoàn thành", TargetObjectsCriteria = "TrangThai!=1", Caption = "Hoàn thành", ConfirmationMessage = "Xác nhận hoàn thành?")]
        public void StatusChanged()
        {
            TrangThai = TrangThai.DaHoanThanh;
        }
        [XafDisplayName("Chi tiết nhật ký")]
        [Association("NhatKyCanhTac-ChiTietNhatKys")]
        public XPCollection<ChiTietNhatKy> ChiTietNhatKys
        {
            get
            {
                return GetCollection<ChiTietNhatKy>(nameof(ChiTietNhatKys));
            }
        }
        [XafDisplayName("Đất - Cơ sở")]
        [Association("NhatKyCanhTac-Dat_CoSos")]
        public XPCollection<Dat_CoSo> Dat_CoSos
        {
            get
            {

                return GetCollection<Dat_CoSo>(nameof(Dat_CoSos));
            }
        }
    }
}
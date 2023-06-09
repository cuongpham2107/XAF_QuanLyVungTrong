using System.ComponentModel;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DotLiquid;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.BusinessObjects.Ticket;
using DXApplication.Module.Extension;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects;

[MapInheritance(MapInheritanceType.ParentTable)]
[DefaultProperty(nameof(Ten))]
[Appearance("NongHo", AppearanceItemType = "ViewItem", TargetItems = "VungTrongs",
     Context = "Any", Criteria = "PhanLoaiNguoi!=0", Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Priority = 1)]
[Appearance("ChuyenGia", AppearanceItemType = "ViewItem", TargetItems = "DanhMucChuDes,CongViec,ChucVu",
     Context = "Any",Criteria ="PhanLoaiNguoi!=1",Visibility =DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Priority = 1)]

[CustomNestedListView(nameof(VungTrongs), AllowNew = false, AllowLink = false, AllowUnlink = false, AllowDelete = false)]
[CustomNestedListView(nameof(DanhMucChuDes), AllowNew = true, AllowLink = true, AllowUnlink = true, AllowDelete = true)]
public class ApplicationUser : PermissionPolicyUser, ISecurityUserWithLoginInfo {
    public ApplicationUser(Session session) : base(session) { }

    [Browsable(false)]
    [DevExpress.ExpressApp.DC.Aggregated, Association("User-LoginInfo")]
    public XPCollection<ApplicationUserLoginInfo> LoginInfo {
        get { return GetCollection<ApplicationUserLoginInfo>(nameof(LoginInfo)); }
    }

    IEnumerable<ISecurityUserLoginInfo> IOAuthSecurityUser.UserLogins => LoginInfo.OfType<ISecurityUserLoginInfo>();

    ISecurityUserLoginInfo ISecurityUserWithLoginInfo.CreateUserLoginInfo(string loginProviderName, string providerUserKey) {
        ApplicationUserLoginInfo result = new ApplicationUserLoginInfo(Session);
        result.LoginProviderName = loginProviderName;
        result.ProviderUserKey = providerUserKey;
        result.User = this;
        return result;
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        phanLoaiNguoi = PhanLoaiNguoi.NongHo;
    }

    PhanLoaiNguoi phanLoaiNguoi;
    string diaChiEmail;
    byte[] avatar;
    byte[] matSau;
    string chucVu;
    string congViec;
    byte[] matTruoc;
    string cCCD;
    string sDT;
    string diaChi;
    string ten;
    [XafDisplayName("Phân loại tài khoản")]
    public PhanLoaiNguoi PhanLoaiNguoi
    {
        get => phanLoaiNguoi;
        set => SetPropertyValue(nameof(PhanLoaiNguoi), ref phanLoaiNguoi, value);
    }
    [XafDisplayName("Tên")]
    public string Ten
    {
        get => ten;
        set => SetPropertyValue(nameof(Ten), ref ten, value);
    }

    [XafDisplayName("Địa chỉ")]
    public string DiaChi
    {
        get => diaChi;
        set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
    }
    [XafDisplayName("Số điện thoại")]
    public string SDT
    {
        get => sDT;
        set => SetPropertyValue(nameof(SDT), ref sDT, value);
    }
    [XafDisplayName("Địa chỉ email")]
    public string DiaChiEmail
    {
        get => diaChiEmail;
        set => SetPropertyValue(nameof(DiaChiEmail), ref diaChiEmail, value);
    }
    [XafDisplayName("Công việc")]
    public string CongViec
    {
        get => congViec;
        set => SetPropertyValue(nameof(CongViec), ref congViec, value);
    }

    [XafDisplayName("Chức vụ")]
    public string ChucVu
    {
        get => chucVu;
        set => SetPropertyValue(nameof(ChucVu), ref chucVu, value);
    }
    [XafDisplayName("Số CCCD")]
    public string CCCD
    {
        get => cCCD;
        set => SetPropertyValue(nameof(CCCD), ref cCCD, value);
    }
    [ImageEditor(ListViewImageEditorCustomHeight = 120, DetailViewImageEditorFixedWidth = 300)]
    [XafDisplayName("Avatar")]
    public byte[] Avatar
    {
        get => avatar;
        set => SetPropertyValue(nameof(Avatar), ref avatar, value);
    }
    [ImageEditor(ListViewImageEditorCustomHeight = 120, DetailViewImageEditorFixedWidth = 500)]
    [XafDisplayName("Mặt trước CCCD")]
    public byte[] MatTruoc
    {
        get => matTruoc;
        set => SetPropertyValue(nameof(MatTruoc), ref matTruoc, value);
    }
    [XafDisplayName("Mặt sau CCCD")]
    [ImageEditor(ListViewImageEditorCustomHeight = 120, DetailViewImageEditorFixedWidth = 500)]
    public byte[] MatSau
    {
        get => matSau;
        set => SetPropertyValue(nameof(MatSau), ref matSau, value);
    }
    [XafDisplayName("Vùng trồng")]
    [Association("ApplicationUser-VungTrongs")]
    public XPCollection<VungTrong> VungTrongs
    {
        get
        {
            return GetCollection<VungTrong>(nameof(VungTrongs));
        }
    }
    [XafDisplayName("Chủ đề")]
    [Association("ApplicationUser-DanhMucChuDes")]
    public XPCollection<DanhMucChuDe> DanhMucChuDes
    {
        get
        {
            return GetCollection<DanhMucChuDe>(nameof(DanhMucChuDes));
        }
    }
}

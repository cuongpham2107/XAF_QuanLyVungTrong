using System.ComponentModel;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.QLVungTrong;

namespace DXApplication.Module.BusinessObjects;

[MapInheritance(MapInheritanceType.ParentTable)]
[DefaultProperty(nameof(Ten))]
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



    string diaChiEmail;
    int soThanhVien;
    byte[] avatar;
    byte[] matSau;
    byte[] matTruoc;
    string cCCD;
    string sDT;
    string diaChi;
    string ten;
    [XafDisplayName("Tên người đại diện")]
    public string Ten
    {
        get => ten;
        set => SetPropertyValue(nameof(Ten), ref ten, value);
    }
    [XafDisplayName("Số thành viên (người)")]
    public int SoThanhVien
    {
        get => soThanhVien;
        set => SetPropertyValue(nameof(SoThanhVien), ref soThanhVien, value);
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
}

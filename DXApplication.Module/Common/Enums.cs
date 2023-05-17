using DevExpress.ExpressApp.DC;

namespace DXApplication.Blazor.Common;
public class Enums
{
    public enum MucDoPhoBien
    {
        [XafDisplayName("Thấp(3-5%)")] Thap,
        [XafDisplayName("TrungBinh(5-10%)")] TrungBinh,
        [XafDisplayName("Cao(10-15%)")] Cao,
    }
}
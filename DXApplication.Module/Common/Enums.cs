using DevExpress.ExpressApp.DC;

namespace DXApplication.Blazor.Common;
public class Enums
{
    public enum MucDoPhoBien
    {
        [XafDisplayName("Thấp(3-5%)")] Thap,
        [XafDisplayName("Trung Bình(5-10%)")] TrungBinh,
        [XafDisplayName("Cao(10-15%)")] Cao,
    }
    public enum HoatDong
    {
        [XafDisplayName("Bón phân")] BonPhan,
        [XafDisplayName("Sử dụng Thuốc BVTV")] Thuoc,
        [XafDisplayName("Chuẩn bị đất")] Dat,
        [XafDisplayName("Gieo hạt")] GieoHat,
        [XafDisplayName("Chăm sóc")] ChamSoc,
        [XafDisplayName("Hoạt động khác")] Khac,
    }
    public enum LoaiSuDung
    {
        [XafDisplayName("Bón phân")] Phân,
        [XafDisplayName("Sử dụng Thuốc BVTV")] Thuốc,
    }
    public enum TrangThai
    {
        [XafDisplayName("Đang xử lý")] DangXyLy,
        [XafDisplayName("Đã hoàn thành")] DaHoanThanh,
    }
    public enum CapCoSo
    {
        [XafDisplayName("Cấp Quốc Gia")] QuocGia,
        [XafDisplayName("Cấp Thành Phố")] TP,
        [XafDisplayName("Cấp Tỉnh")] Tinh,
        [XafDisplayName("Cấp Huyện")] Huyen,
    }
}
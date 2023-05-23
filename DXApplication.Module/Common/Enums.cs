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
        [XafDisplayName("Làm đất")] Dat,
        [XafDisplayName("Gieo hạt")] GieoHat,
        [XafDisplayName("Trồng cây")] TrongCay,
        [XafDisplayName("Tưới nước")] TuoiNuoc,
        [XafDisplayName("Làm cỏ")] LamCo,
        [XafDisplayName("Cắt tỉa")] CatTia,
        [XafDisplayName("Thu hoạch")] ThuHoach,
        [XafDisplayName("Bảo quản")] BaoQuan,
        [XafDisplayName("Hoạt động khác")] Khac,
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
    public enum GiaiDoanCanhTac
    {
        [XafDisplayName("Chuẩn bị đất trồng")] Dat,
        [XafDisplayName("Gieo trồng")] Thuoc,
        [XafDisplayName("Chăm sóc")] ChamSoc,
        [XafDisplayName("Thu hoạch")] ThuHoach,
        [XafDisplayName("Bảo quản")] BaoQuan,
    }
}
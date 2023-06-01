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
    public enum DonGia
    {
        [XafDisplayName("Cái")] Cai,
        [XafDisplayName("m")] m,
        [XafDisplayName("cm")] cm,
        [XafDisplayName("kg")] kg,
        [XafDisplayName("g")] g,
        [XafDisplayName("mg")] mg,
        [XafDisplayName("L")] L,
        [XafDisplayName("ml")] ml,
        [XafDisplayName("Con")] con,
        [XafDisplayName("Bao (Bì)")] baoBi,
        [XafDisplayName("Viên")] Vien,
        [XafDisplayName("Liều")] Lièu,
        [XafDisplayName("Hạt")] Hat,
        [XafDisplayName("Cay")] Cay,

    }
    public enum CongViec_TT
    {
        [XafDisplayName("Công việc")] CongViec,
        [XafDisplayName("Tình trạng")] TinhTrang,
       

    }
    public enum DonViSanLuong
    {
        [XafDisplayName("Kg")] kg,
        [XafDisplayName("Yến")] yen,
        [XafDisplayName("Tạ")] ta,
        [XafDisplayName("Tấn")] tan,
    }
    public enum PhanLoaiDat
    {
        [XafDisplayName("Sở hữu")] soHuu,
        [XafDisplayName("Cho thuê")] choThue,
    }
    public enum ChuDe
    {
        [XafDisplayName("Cây trồng")] cay,
        [XafDisplayName("Vùng trồng")] vungTrong,
        [XafDisplayName("Quy hoạch")] quyHoach,
        [XafDisplayName("Đất đai")] datDai,
        [XafDisplayName("Giống")] giong,
        [XafDisplayName("Gieo trồng")] gieoTrong,
        [XafDisplayName("Chăm sóc")] chamSoc,
        [XafDisplayName("Phân bón")] phanBon,
        [XafDisplayName("Nông dược")] nongDuoc,
        [XafDisplayName("Thu hoạch")] thuHai,
        [XafDisplayName("Bảo quản")] baoQuan,
        [XafDisplayName("Công nghệ")] congNghe,
        [XafDisplayName("Máy móc")] mayMoc,
        [XafDisplayName("Xuất khẩu")] xuatKhau,
        [XafDisplayName("Khác")] khac,
    }
}
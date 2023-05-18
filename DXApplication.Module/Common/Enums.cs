﻿using DevExpress.ExpressApp.DC;

namespace DXApplication.Blazor.Common;
public class Enums
{
    public enum MucDoPhoBien
    {
        [XafDisplayName("Thấp(3-5%)")] Thap,
        [XafDisplayName("TrungBinh(5-10%)")] TrungBinh,
        [XafDisplayName("Cao(10-15%)")] Cao,
    }
    public enum HoatDong
    {
        [XafDisplayName("Bón phân")] BonPhan,
        [XafDisplayName("Sử dụng Thuốc BVTV")] Thuoc,
        [XafDisplayName("Hoạt động khác")] Khac,
    }
    public enum LoaiSuDung
    {
        [XafDisplayName("Bón phân")] Phân,
        [XafDisplayName("Sử dụng Thuốc BVTV")] Thuốc,
    }
}
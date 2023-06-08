using crypto;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Core;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Authentication;
using DevExpress.ExpressApp.Security.Authentication.ClientServer;
using DXApplication.Module.BusinessObjects;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;

namespace ApiNoAuth.WebApi.CustomApi;

[ApiController]
[Route("api/[controller]")]
public class CustomApiController : ControllerBase
{
    IObjectSpaceFactory objectSpaceFactory;
    public CustomApiController(IObjectSpaceFactory objectSpaceFactory)
    {
        this.objectSpaceFactory = objectSpaceFactory;
    }
    [HttpGet]
    public IActionResult Get()
    {
        IObjectSpace a = objectSpaceFactory.CreateObjectSpace<VungTrong>();
        IEnumerable<VungTrong> vungTrong = a.GetObjects<VungTrong>();
        foreach(VungTrong v in vungTrong) 
        {
            return Ok(new
            {
                vungtrong = new
                {
                    Oid = v.Oid,
                    LoaiCay = v.LoaiCayTrong.TenCay,
                    MaSo = v.MaSo,
                    DiaChi = v.DiaChi,
                    NamCap = v.NamCap,
                    DienTich = v.DienTichCanhTac,
                    HinhThuc = v.HinhThucCanhTac,
                    SanLuong = v.SanLuongDuKien,
                    TieuChuan = v.TieuChuan,
                    TinhTrang = v.HoatDong,
                    GhiChu = v.GhiChu,
                    ToaDo = v.ToaDo,
                    LatLong = v.LatLong,
                }
            });
        }
        return Ok();
    }


}
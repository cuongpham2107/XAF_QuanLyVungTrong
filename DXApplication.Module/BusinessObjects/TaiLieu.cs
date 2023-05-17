using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class TaiLieu : BaseObject
    {
        public TaiLieu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        VungTrong vungTrong;
        NhatKyCanhTac nhatKyCanhTac;
        SinhVatGayHai sinhVatGayHai;
        PhanBon phanBon;
        ThuocBVTV thuocBVTV;
        QuyTrinhSanXuat quyTrinhSanXuat;
        LoaiCayTrong loaiCayTrong;
        DateTime nguoiSua;
        DateTime ngaySua;
        string nguoiTao;
        DateTime ngayTao;
        string ghiChu;
        string moTa;
        FileData fileTaiLieu;
        string tenTaiLieu;

        public string TenTaiLieu
        {
            get => tenTaiLieu;
            set => SetPropertyValue(nameof(TenTaiLieu), ref tenTaiLieu, value);
        }

        public FileData FileTaiLieu
        {
            get => fileTaiLieu;
            set => SetPropertyValue(nameof(FileTaiLieu), ref fileTaiLieu, value);
        }

        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }

        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }

        public string NguoiTao
        {
            get => nguoiTao;
            set => SetPropertyValue(nameof(NguoiTao), ref nguoiTao, value);
        }

        public DateTime NgaySua
        {
            get => ngaySua;
            set => SetPropertyValue(nameof(NgaySua), ref ngaySua, value);
        }

        public DateTime NguoiSua
        {
            get => nguoiSua;
            set => SetPropertyValue(nameof(NguoiSua), ref nguoiSua, value);
        }

        [Association("LoaiCayTrong-TaiLieus")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }

        [Association("QuyTrinhSanXuat-TaiLieus")]
        public QuyTrinhSanXuat QuyTrinhSanXuat
        {
            get => quyTrinhSanXuat;
            set => SetPropertyValue(nameof(QuyTrinhSanXuat), ref quyTrinhSanXuat, value);
        }

        [Association("ThuocBVTV-TaiLieus")]
        public ThuocBVTV ThuocBVTV
        {
            get => thuocBVTV;
            set => SetPropertyValue(nameof(ThuocBVTV), ref thuocBVTV, value);
        }

        [Association("PhanBon-TaiLieus")]
        public PhanBon PhanBon
        {
            get => phanBon;
            set => SetPropertyValue(nameof(PhanBon), ref phanBon, value);
        }

        [Association("SinhVatGayHai-TaiLieus")]
        public SinhVatGayHai SinhVatGayHai
        {
            get => sinhVatGayHai;
            set => SetPropertyValue(nameof(SinhVatGayHai), ref sinhVatGayHai, value);
        }

        [Association("NhatKyCanhTac-TaiLieus")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
        
        [Association("VungTrong-TaiLieus")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
    }
}
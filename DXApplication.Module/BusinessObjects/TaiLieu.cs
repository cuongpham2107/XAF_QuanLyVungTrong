using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
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
    [DefaultProperty(nameof(TenTaiLieu))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Tài liệu")]
    [ImageName("book-stack")]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class TaiLieu : BaseObject
    {
        public TaiLieu(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            ngayTao = DateTime.Now;
            nguoiTao = SecuritySystem.CurrentUserName.ToString();
        }

        VungTrong vungTrong;
        NhatKyCanhTac nhatKyCanhTac;
        SinhVatGayHai sinhVatGayHai;
        PhanBon phanBon;
        ThuocBVTV thuocBVTV;
        QuyTrinhSanXuat quyTrinhSanXuat;
        LoaiCayTrong loaiCayTrong;
        string nguoiSua;
        DateTime ngaySua;
        string nguoiTao;
        DateTime ngayTao;
        string ghiChu;
        string moTa;
        FileData fileTaiLieu;
        string tenTaiLieu;
        [XafDisplayName("Tên tài liệu")]
        [RuleRequiredField("Bắt buộc phải có TaiLieu.TenTaiLieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenTaiLieu
        {
            get => tenTaiLieu;
            set => SetPropertyValue(nameof(TenTaiLieu), ref tenTaiLieu, value);
        }
        [XafDisplayName("File tài liệu")]
        [RuleRequiredField("Bắt buộc phải có TaiLieu.FileTaiLieu", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public FileData FileTaiLieu
        {
            get => fileTaiLieu;
            set => SetPropertyValue(nameof(FileTaiLieu), ref fileTaiLieu, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Ngày tạo")]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }
        [XafDisplayName("Người tạo")]
        [ModelDefault("AllowEdit", "false")]
        public string NguoiTao
        {
            get => nguoiTao;
            set => SetPropertyValue(nameof(NguoiTao), ref nguoiTao, value);
        }
        [XafDisplayName("Ngày sửa")]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgaySua
        {
            get => ngaySua;
            set => SetPropertyValue(nameof(NgaySua), ref ngaySua, value);
        }
        [XafDisplayName("Người sửa")]
        [ModelDefault("AllowEdit", "false")]
        public string NguoiSua
        {
            get => nguoiSua;
            set => SetPropertyValue(nameof(NguoiSua), ref nguoiSua, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("LoaiCayTrong-TaiLieus")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("QuyTrinhSanXuat-TaiLieus")]
        public QuyTrinhSanXuat QuyTrinhSanXuat
        {
            get => quyTrinhSanXuat;
            set => SetPropertyValue(nameof(QuyTrinhSanXuat), ref quyTrinhSanXuat, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("ThuocBVTV-TaiLieus")]
        public ThuocBVTV ThuocBVTV
        {
            get => thuocBVTV;
            set => SetPropertyValue(nameof(ThuocBVTV), ref thuocBVTV, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("PhanBon-TaiLieus")]
        public PhanBon PhanBon
        {
            get => phanBon;
            set => SetPropertyValue(nameof(PhanBon), ref phanBon, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("SinhVatGayHai-TaiLieus")]
        public SinhVatGayHai SinhVatGayHai
        {
            get => sinhVatGayHai;
            set => SetPropertyValue(nameof(SinhVatGayHai), ref sinhVatGayHai, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("NhatKyCanhTac-TaiLieus")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association("VungTrong-TaiLieus")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
        
        protected override void OnSaving()
        {
            ngaySua = DateTime.Now;
            nguoiSua = SecuritySystem.CurrentUserName.ToString();
            base.OnSaving();
        }
    }
}
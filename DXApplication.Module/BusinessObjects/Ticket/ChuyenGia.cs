using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Ticket
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenChuyenGia))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Chuyên gia")]
    [ImageName("rating")]
    [NavigationItem(Menu.HoiDap)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class ChuyenGia : BaseObject, IListViewPopup
    {
        public ChuyenGia(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        byte[] hinhAnh;
        string cCCD;
        string chucVu;
        string congViec;
        string diaChi;
        string email;
        string sDT;
        string tenChuyenGia;
        [XafDisplayName("Tên chuyên gia")]
        [RuleRequiredField("Bắt buộc phải có ChuyenGia.TenChuyenGia", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenChuyenGia
        {
            get => tenChuyenGia;
            set => SetPropertyValue(nameof(TenChuyenGia), ref tenChuyenGia, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SDT
        {
            get => sDT;
            set => SetPropertyValue(nameof(SDT), ref sDT, value);
        }
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
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

        [XafDisplayName("Số CCCD/CMT")]
        public string CCCD
        {
            get => cCCD;
            set => SetPropertyValue(nameof(CCCD), ref cCCD, value);
        }
        [ImageEditor(ListViewImageEditorCustomHeight =80,DetailViewImageEditorFixedWidth =300)]
        [XafDisplayName("Ảnh")]
        public byte[] HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Lĩnh vực chủ đề")]
        [Association("DanhMucChuDes-ChuyenGias")]
        public XPCollection<DanhMucChuDe> DanhMucChuDes
        {
            get
            {
                return GetCollection<DanhMucChuDe>(nameof(DanhMucChuDes));
            }
        }
    }
}
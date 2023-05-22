﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenVungTrong))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Vùng Trồng")]
    [ImageName("planting")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomDetailView(Tabbed =true)]

    [RuleCriteria("7 <= DienTichCanhTac&&DienTichCanhTac<=12",
    CustomMessageTemplate = "Diện tích canh tác phải lớn hơn 7ha và nhỏ hơn 12ha")]

    [Appearance("b", AppearanceItemType = "ViewItem", TargetItems = "HoatDong",
    Criteria = "HoatDong=true", Context = "Any", BackColor = "204,255,204", Priority = 1)]
    [Appearance("b1", AppearanceItemType = "ViewItem", TargetItems = "HoatDong",
    Criteria = "HoatDong=false", Context = "Any", BackColor = "Red",FontColor ="White", Priority = 1)]
    public class VungTrong : BaseObject
    {
        public VungTrong(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            namCap = DateTime.Now.Year;
        }

        string ghiChu;
        string thongTinThoNhuong;
        LoaiCayTrong loaiCayTrong;
        string hinhThucCanhTac;
        string sanLuongDuKien;
        bool hoatDong;
        double dienTichCanhTac;
        string tieuChuan;
        int namCap;
        string diaChi;
        string maSo;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [XafDisplayName("Tên Vùng Trồng")]
        public string TenVungTrong
        {
            get
            {
                if (!IsSaving && !IsLoading)
                {
                    string a = $"{LoaiCayTrong} - {MaSo}";
                    return a;
                }
                return null;
            }
        }
        [XafDisplayName("Mã số vùng trồng")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.MaSo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaSo
        {
            get => maSo;
            set => SetPropertyValue(nameof(MaSo), ref maSo, value);
        }
        [XafDisplayName("Địa chỉ")]
        [RuleRequiredField("Bắt buộc phải có VungTrong.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Năm cấp")]
        [ModelDefault("DisplayFormat", "D")]
        public int NamCap
        {
            get => namCap;
            set => SetPropertyValue(nameof(NamCap), ref namCap, value);
        }
        [XafDisplayName("Tiêu chuẩn")]
        public string TieuChuan
        {
            get => tieuChuan;
            set => SetPropertyValue(nameof(TieuChuan), ref tieuChuan, value);
        }
        [XafDisplayName("Diện tích")]
        [ModelDefault("DisplayFormat", "{0} ha")]
        public double DienTichCanhTac
        {
            get => dienTichCanhTac;
            set => SetPropertyValue(nameof(DienTichCanhTac), ref dienTichCanhTac, value);
        }
        [XafDisplayName("Thông tin thổ nhưỡng")]
        [Size(1024)]
        public string ThongTinThoNhuong
        {
            get => thongTinThoNhuong;
            set => SetPropertyValue(nameof(ThongTinThoNhuong), ref thongTinThoNhuong, value);
        }
        [XafDisplayName("Tình trạng")]
        [CaptionsForBoolValues("Đang hoạt động", "Ngừng hoạt động")]
        public bool HoatDong
        {
            get => hoatDong;
            set => SetPropertyValue(nameof(HoatDong), ref hoatDong, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Sản lượng dự kiến")]
        public string SanLuongDuKien
        {
            get => sanLuongDuKien;
            set => SetPropertyValue(nameof(SanLuongDuKien), ref sanLuongDuKien, value);
        }
        [XafDisplayName("Hình thức canh tác")]
        [Size(1024)]
        public string HinhThucCanhTac
        {
            get => hinhThucCanhTac;
            set => SetPropertyValue(nameof(HinhThucCanhTac), ref hinhThucCanhTac, value);
        }
        [XafDisplayName("Nhật ký canh tác")]
        [Association("VungTrong-NhatKyCanhTacs"), DevExpress.Xpo.Aggregated]
        public XPCollection<NhatKyCanhTac> NhatKyCanhTacs
        {
            get
            {
                return GetCollection<NhatKyCanhTac>(nameof(NhatKyCanhTacs));
            }
        }
        [XafDisplayName("Tài liệu đi kèm")]
        [Association("VungTrong-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }

        [RuleRequiredField("Bắt buộc phải có VungTrong.LoaiCayTrong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [XafDisplayName("Loại cây trồng")] 
        [Association("LoaiCayTrong-VungTrongs")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }
    }
}
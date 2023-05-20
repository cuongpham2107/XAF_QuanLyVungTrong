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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(LoaiCayTrong))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Quy trình sản xuất")]
    [ImageName("book-stack")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    public class QuyTrinhSanXuat : BaseObject
    { 
        public QuyTrinhSanXuat(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            namBanHanh = DateTime.Now.Year;
        }

        LoaiCayTrong loaiCayTrong;
        string baoQuan;
        string thuHai;
        string suDungThuoc;
        string bonPhan;
        string sauBenh;
        string thoiVu;
        string kiThuatChamSoc;
        string kiThuatTrong;
        string mucTieu;
        int namBanHanh;
        [XafDisplayName("Năm ban hành")]
        [ModelDefault("DisplayFormat", "D")]
        public int NamBanHanh
        {
            get => namBanHanh;
            set => SetPropertyValue(nameof(NamBanHanh), ref namBanHanh, value);
        }
        [XafDisplayName("Mục tiêu")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string MucTieu
        {
            get => mucTieu;
            set => SetPropertyValue(nameof(MucTieu), ref mucTieu, value);
        }
        [XafDisplayName("Kĩ thuật trồng")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string KiThuatTrong
        {
            get => kiThuatTrong;
            set => SetPropertyValue(nameof(KiThuatTrong), ref kiThuatTrong, value);
        }
        [XafDisplayName("Kĩ thuật chăm sóc")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string KiThuatChamSoc
        {
            get => kiThuatChamSoc;
            set => SetPropertyValue(nameof(KiThuatChamSoc), ref kiThuatChamSoc, value);
        }
        [XafDisplayName("Thời vụ")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string ThoiVu
        {
            get => thoiVu;
            set => SetPropertyValue(nameof(ThoiVu), ref thoiVu, value);
        }
        [XafDisplayName("Sâu bệnh")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string SauBenh
        {
            get => sauBenh;
            set => SetPropertyValue(nameof(SauBenh), ref sauBenh, value);
        }
        [XafDisplayName("Phân bón")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string BonPhan
        {
            get => bonPhan;
            set => SetPropertyValue(nameof(BonPhan), ref bonPhan, value);
        }
        [XafDisplayName("Thuốc BVTV")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string SuDungThuoc
        {
            get => suDungThuoc;
            set => SetPropertyValue(nameof(SuDungThuoc), ref suDungThuoc, value);
        }
        [XafDisplayName("Thu hái")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string ThuHai
        {
            get => thuHai;
            set => SetPropertyValue(nameof(ThuHai), ref thuHai, value);
        }
        [XafDisplayName("Bảo quản")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string BaoQuan
        {
            get => baoQuan;
            set => SetPropertyValue(nameof(BaoQuan), ref baoQuan, value);
        }
        [XafDisplayName("Tài liệu")]
        [Association("QuyTrinhSanXuat-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }
        [XafDisplayName("Loại cây trồng")]
        [RuleRequiredField("Bắt buộc phải có QuyTrinhSanXuat.LoaiCayTrong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("LoaiCayTrong-QuyTrinhSanXuats")]
        public LoaiCayTrong LoaiCayTrong
        {
            get => loaiCayTrong;
            set => SetPropertyValue(nameof(LoaiCayTrong), ref loaiCayTrong, value);
        }
    }
}
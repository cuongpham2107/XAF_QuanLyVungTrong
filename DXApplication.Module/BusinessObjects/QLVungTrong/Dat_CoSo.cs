using DevExpress.Data.Filtering;
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
    [DefaultProperty(nameof(TenDatCoSo))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Đất - Cơ sở")]
    [ImageName("management")]
    [NavigationItem(Menu.Danhmuc)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

   
    [Appearance("DienTich", AppearanceItemType = "ViewItem", TargetItems = "DienTich",
     Context = "ListView", BackColor = "DeepSkyBlue",FontStyle =System.Drawing.FontStyle.Bold, Priority = 3)]

    public class Dat_CoSo : BaseObject, IListViewPopup
    { 
        public Dat_CoSo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
          
        }

        VungTrong vungTrong;
        string ghiChu;
        string diaDiem;
        PhanLoaiDat phanLoaiDat;
        DonViDat donViDat;
        int dienTich;
        string soDatCoSo;
        string tenDatCoSo;
        [XafDisplayName("Tên đất cơ sở")]
        [RuleRequiredField("Bắt buộc phải có Dat_CoSo.TenDatCoSo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenDatCoSo
        {
            get => tenDatCoSo;
            set => SetPropertyValue(nameof(TenDatCoSo), ref tenDatCoSo, value);
        }
        [XafDisplayName("Số đất cơ sở")]
        public string SoDatCoSo
        {
            get => soDatCoSo;
            set => SetPropertyValue(nameof(SoDatCoSo), ref soDatCoSo, value);
        }
        [XafDisplayName("Vùng trồng")]
        [VisibleInDetailView(true)]
        [Association("VungTrong-Dat_CoSos")]
        public VungTrong VungTrong
        {
            get => vungTrong;
            set => SetPropertyValue(nameof(VungTrong), ref vungTrong, value);
        }
        [XafDisplayName("Diện tích")]

        public int DienTich
        {
            get => dienTich;
            set => SetPropertyValue(nameof(DienTich), ref dienTich, value);
        }
        [XafDisplayName("ĐV")]
        public DonViDat DonViDat
        {
            get => donViDat;
            set => SetPropertyValue(nameof(DonViDat), ref donViDat, value);
        }
        [XafDisplayName("Phân loại đất")]
        public PhanLoaiDat PhanLoaiDat
        {
            get => phanLoaiDat;
            set => SetPropertyValue(nameof(PhanLoaiDat), ref phanLoaiDat, value);
        }
        [XafDisplayName("Địa điểm")]
        public string DiaDiem
        {
            get => diaDiem;
            set => SetPropertyValue(nameof(DiaDiem), ref diaDiem, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Nhật ký canh tác")]
        [Association("NhatKyCanhTac-Dat_CoSos")]
        public XPCollection<NhatKyCanhTac> NhatKyCanhTacs
        {
            get
            {
                return GetCollection<NhatKyCanhTac>(nameof(NhatKyCanhTacs));
            }
        }
    }
}
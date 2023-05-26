
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.Common;
using System.ComponentModel;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.QLVungTrong
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TenSinhVat))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Sinh vật gây hại")]
    [ImageName("book-stack")]
    [NavigationItem(Menu.VungTrong)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    [Appearance("a7", AppearanceItemType = "ViewItem", TargetItems = "MucDoPhoBien",
    Criteria = "MucDoPhoBien=0", Context = "Any", BackColor = "204,255,204", Priority = 3)]
    [Appearance("a5", AppearanceItemType = "ViewItem", TargetItems = "MucDoPhoBien",
    Criteria = "MucDoPhoBien=1", Context = "Any", BackColor = "Yellow", Priority = 3)]
    [Appearance("a6", AppearanceItemType = "ViewItem", TargetItems = "MucDoPhoBien",
    Criteria = "MucDoPhoBien=2", Context = "Any", BackColor = "Red",FontColor ="White", Priority = 3)]
    public class SinhVatGayHai : BaseObject
    { 
        public SinhVatGayHai(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        MediaDataObject hinhAnh;
        string ghiChu;
        string bienPhapPhongTru;
        string moTa;
        MucDoPhoBien mucDoPhoBien;
        string loaiSinhVat;
        string tenSinhVat;
        [XafDisplayName("Tên sinh vật")]
        [RuleRequiredField("Bắt buộc phải có SinhVatGayHai.TenSinhVat", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenSinhVat
        {
            get => tenSinhVat;
            set => SetPropertyValue(nameof(TenSinhVat), ref tenSinhVat, value);
        }
        [XafDisplayName("Loại sinh vật")]
        public string LoaiSinhVat
        {
            get => loaiSinhVat;
            set => SetPropertyValue(nameof(LoaiSinhVat), ref loaiSinhVat, value);
        }
        [XafDisplayName("Mức độ phổ biến")]
        public MucDoPhoBien MucDoPhoBien
        {
            get => mucDoPhoBien;
            set => SetPropertyValue(nameof(MucDoPhoBien), ref mucDoPhoBien, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
        [XafDisplayName("Biện pháp phòng trừ")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string BienPhapPhongTru
        {
            get => bienPhapPhongTru;
            set => SetPropertyValue(nameof(BienPhapPhongTru), ref bienPhapPhongTru, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Ảnh minh họa")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 80)]
        public MediaDataObject HinhAnh
        {
            get => hinhAnh;
            set => SetPropertyValue(nameof(HinhAnh), ref hinhAnh, value);
        }
        [XafDisplayName("Tài liệu")]
        [Association("SinhVatGayHai-TaiLieus"), DevExpress.Xpo.Aggregated]
        public XPCollection<TaiLieu> TaiLieus
        {
            get
            {
                return GetCollection<TaiLieu>(nameof(TaiLieus));
            }
        }

    }
}
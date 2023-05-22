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

namespace DXApplication.Module.BusinessObjects.Ticket
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(TieuDe))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Hỏi đáp")]
    [ImageName("Actions_Question")]
    [NavigationItem(Menu.HoiDap)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]

    [Appearance("mo", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "TrangThai=true", Context = "Any", BackColor = "204,255,204", Priority = 1)]
    [Appearance("mo1", AppearanceItemType = "ViewItem", TargetItems = "TrangThai",
    Criteria = "TrangThai=false", Context = "Any", BackColor = "Red", FontColor = "White", Priority = 1)]
    [Appearance("mo11", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = "TrangThai=false", Context = "Any", Enabled = false, Priority = 2)]
    public class Ticket : BaseObject, IListViewPopup
    { 
        public Ticket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        bool trangThai;
        string ghiChu;
        MediaDataObject file;
        string noiDung;
        string tieuDe;
        [XafDisplayName("Thời gian")]
        [VisibleInDetailView(false)]
        public string ThoiGian
        {
            get
            {
                if (!IsSaving && !IsLoading)
                {
                    TimeSpan x = DateTime.Now - ngayTao;
                    if (x.Days < 1)
                    {
                        if (x.Hours < 1)
                        {
                            var a = $"{x.Minutes} phút trước";
                            return a;
                        }
                        else
                        {
                            var a = $"{x.Hours} giờ trước";
                            return a;
                        }

                    }
                    else
                    {
                        if (x.Days > 365)
                        {
                            var a = $"{x.Days / 365} năm trước";
                            return a;
                        }
                        else
                        {
                            var a = $"{x.Days} ngày trước";
                            return a;
                        }
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Tiêu đề")]
        [RuleRequiredField("Bắt buộc phải có Ticket.TieuDe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TieuDe
        {
            get => tieuDe;
            set => SetPropertyValue(nameof(TieuDe), ref tieuDe, value);
        }
        [XafDisplayName("Nội dung câu hỏi")]
        [RuleRequiredField("Bắt buộc phải có Ticket.NoiDung", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Hình ảnh/Video đính kèm")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 100)]
        public MediaDataObject File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [CaptionsForBoolValues("Đang mở", "Đã đóng")]
        [XafDisplayName("Trạng thái")]
        public bool TrangThai
        {
            get => trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Hội thoại")]
        [Association("Ticket-HoiThoais"), DevExpress.Xpo.Aggregated]
        public XPCollection<HoiThoai> HoiThoais
        {
            get
            {
                return GetCollection<HoiThoai>(nameof(HoiThoais));
            }
        }
        [Action(ToolTip = "Điều chỉnh trạng thái Ticket", Caption = "Đóng/Mở Ticket", ConfirmationMessage = "Xác nhận đóng/mở Ticket?")]
        public void StatusChanged()
        {
            if (TrangThai == false)
            {
                TrangThai = true;
            }
            else
            {
                TrangThai = false;
            }
        }
    }
}
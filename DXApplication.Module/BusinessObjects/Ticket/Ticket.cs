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
using Helper = DXApplication.Module.Common.Helper;

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
    [CustomListViewColumnWidth(new[]{ "NoiDung:50%"})]
    public class Ticket : BaseObject, IListViewPopup, IRefreshNavigation
    {
        public Ticket(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            trangThai = true;
            ngayTao = DateTime.Now;
        }
        protected override void OnSaving()
        {

            base.OnSaving();
            string _Host = "";
            int _Port = 0;
            string _Account = "";
            string _Password = "";
            string _From = "";

            var Host = Session.Query<MailConfiguration>().FirstOrDefault(c => c.Key == "EmailHost");
            var Port = Session.Query<MailConfiguration>().FirstOrDefault(c => c.Key == "EmailPort");
            var Account = Session.Query<MailConfiguration>().FirstOrDefault(c => c.Key == "EmailAccount");
            var Password = Session.Query<MailConfiguration>().FirstOrDefault(c => c.Key == "EmailPassword");
            var From = Session.Query<MailConfiguration>().FirstOrDefault(c => c.Key == "EmailFrom");
            if (Host != null && Port != null && Account != null && Password != null && From != null)
            {
                _Host = Host.Value;
                _Port = int.Parse(Port.Value);
                _Account = Account.Value;
                _Password = Password.Value;
                _From = From.Value;
            }
            if (NguoiTao == null) throw new UserFriendlyException("Không tồn tại người tạo Tiket");
            if (string.IsNullOrEmpty(NguoiTao.DiaChiEmail)) throw new UserFriendlyException("Không có địa chỉ email.");

            var body = "<h3>Kính gửi chuyên gia {{ten}}.</h3>" +
                "<p>Thông báo về Câu hỏi mới nông hộ cần chuyên gia giả đáp:</p>" +
                "<p>Tiêu đề: {{tieude}}</p>" +
                "<span>Ngày tạo: {{ngaytao}}</span>" +
                "<p>Nội dung: {{noidung}}</p>";

            string header = "Người nông dân cần chuyên gia hỗ trợ";


            List<ApplicationUser> chuyengias = Session.Query<ApplicationUser>().Where(x => x.PhanLoaiNguoi == Blazor.Common.Enums.PhanLoaiNguoi.ChuyenGia).ToList();

            foreach (var item in chuyengias)
            {
                if (item.DanhMucChuDes != null)
                {
                    foreach (var value in item.DanhMucChuDes)
                    {
                        if (value.Oid == DanhMucChuDe.Oid)
                        {
                            Dictionary<string, string> pairs = new() {
                                { "{{ten}}", item.Ten },
                                { "{{tieude}}", TieuDe },
                                { "{{ngaytao}}", NgayTao.ToString() },
                                { "{{noidung}}", NoiDung },
                            };
                            var message = Helper.CreateBody(pairs, body);
                            Helper.SendEmail(_From, item.DiaChiEmail, header, message, _Host, _Port, _Account, _Password);
                        }

                    }
                }

            }

        }

        DanhMucChuDe danhMucChuDe;
        bool trangThai;
        byte[] file;
        string noiDung;
        string tieuDe;
        ApplicationUser nguoiTao;
        DateTime ngayTao;
        [XafDisplayName("Tiêu đề")]
        [RuleRequiredField("Bắt buộc phải có Ticket.TieuDe", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Size(200)]
        public string TieuDe
        {
            get => tieuDe;
            set => SetPropertyValue(nameof(TieuDe), ref tieuDe, value);
        }
        [XafDisplayName("Nội dung câu hỏi")]
        [Size(SizeAttribute.Unlimited), VisibleInListView(true)]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Hình ảnh/Video đính kèm")]
        [ImageEditor(ListViewImageEditorCustomHeight = 100, DetailViewImageEditorFixedHeight = 350)]
        public byte[] File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [CaptionsForBoolValues("Đang mở", "Đã đóng")]
        [VisibleInDetailView(false)]
        [XafDisplayName("Trạng thái")]
        public bool TrangThai
        {
            get => trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
        }
        [XafDisplayName("Ngày tạo")]
        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "false")]
        public DateTime NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }
        [XafDisplayName("Người tạo")]
        [VisibleInDetailView(false)]
        [ModelDefault("AllowEdit", "false")]
        public ApplicationUser NguoiTao
        {
            get => nguoiTao;
            set => SetPropertyValue(nameof(NguoiTao), ref nguoiTao, value);
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
        [XafDisplayName("Chủ đề hỏi đáp")]
        [Association("DanhMucChuDe-Tickets")]
        public DanhMucChuDe DanhMucChuDe
        {
            get => danhMucChuDe;
            set => SetPropertyValue(nameof(DanhMucChuDe), ref danhMucChuDe, value);
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
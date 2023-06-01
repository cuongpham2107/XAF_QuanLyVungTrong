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
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.Ticket;

[DefaultClassOptions]
[DefaultProperty(nameof(TenDanhMuc))]
[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
[XafDisplayName("Chủ đề hỏi đáp")]
[ImageName("topic")]
[NavigationItem(Menu.HoiDap)]
[ListViewFindPanel(true)]
[LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
[ListViewAutoFilterRow(true)]
[CustomNestedListView(nameof(Tickets), AllowNew = false, AllowLink = true, AllowUnlink = true, AllowDelete = false)]
public class DanhMucChuDe : BaseObject, IDetailViewCount
{ 
    public DanhMucChuDe(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
       
    }

    DanhMuc danhMuc;
    string moTa;
    string tenDanhMuc;
    [XafDisplayName("Tên chủ đề")]
    [RuleRequiredField("Bắt buộc phải có DanhMucChuDe.TenDanhMuc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
    public string TenDanhMuc
    {
        get => tenDanhMuc;
        set => SetPropertyValue(nameof(TenDanhMuc), ref tenDanhMuc, value);
    }
    [XafDisplayName("Mô tả")]
    [Size(200)]
    public string MoTa
    {
        get => moTa;
        set => SetPropertyValue(nameof(MoTa), ref moTa, value);
    }
    [XafDisplayName("Danh mục")]
    [Association("DanhMuc-DanhMucChuDes")]
    public DanhMuc DanhMuc
    {
        get => danhMuc;
        set => SetPropertyValue(nameof(DanhMuc), ref danhMuc, value);
    }
    [XafDisplayName("Chuyên gia")]
    [Association("ApplicationUser-DanhMucChuDes")]
    public XPCollection<ApplicationUser> ApplicationUsers
    {
        get
        {
            return GetCollection<ApplicationUser>(nameof(ApplicationUsers));
        }
    }
    [XafDisplayName("Câu hỏi")]
    [Association("DanhMucChuDe-Tickets")]
    public XPCollection<Ticket> Tickets
    {
        get
        {
            return GetCollection<Ticket>(nameof(Tickets));
        }
    }
}
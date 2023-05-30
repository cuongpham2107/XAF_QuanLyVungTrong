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
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Ten))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.Top)]
    [XafDisplayName("Nông hộ")]
    [ImageName("planting")]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [ListViewAutoFilterRow(true)]
    [CustomNestedListView(nameof(VungTrongs),AllowDelete =false,AllowNew =false,AllowEdit =false,AllowLink =false,AllowUnlink =false)]
    public class NongHo : BaseObject
    { 
        public NongHo(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        int soThanhVien;
        byte[] matSau;
        byte[] matTruoc;
        string cCCD;
        string sDT;
        string diaChi;
        string ten;
        [XafDisplayName("Tên người đại diện")]
        public string Ten
        {
            get => ten;
            set => SetPropertyValue(nameof(Ten), ref ten, value);
        }
        [XafDisplayName("Số thành viên (người)")]
        public int SoThanhVien
        {
            get => soThanhVien;
            set => SetPropertyValue(nameof(SoThanhVien), ref soThanhVien, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SDT
        {
            get => sDT;
            set => SetPropertyValue(nameof(SDT), ref sDT, value);
        }
        [XafDisplayName("Số CCCD")]
        public string CCCD
        {
            get => cCCD;
            set => SetPropertyValue(nameof(CCCD), ref cCCD, value);
        }
        [ImageEditor(ListViewImageEditorCustomHeight = 80, DetailViewImageEditorFixedWidth = 300)]
        [XafDisplayName("Mặt trước CCCD")]
        public byte[] MatTruoc
        {
            get => matTruoc;
            set => SetPropertyValue(nameof(MatTruoc), ref matTruoc, value);
        }
        [XafDisplayName("Mặt sau CCCD")]
        [ImageEditor(ListViewImageEditorCustomHeight = 80, DetailViewImageEditorFixedWidth = 300)]
        public byte[] MatSau
        {
            get => matSau;
            set => SetPropertyValue(nameof(MatSau), ref matSau, value);
        }
        [XafDisplayName("Vùng trồng")]
        [Association("NongHo-VungTrongs")]
        public XPCollection<VungTrong> VungTrongs
        {
            get
            {
                return GetCollection<VungTrong>(nameof(VungTrongs));
            }
        }
        
    
        private ApplicationUser applicationUser;
        [XafDisplayName("Tài khoản")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public ApplicationUser ApplicationUser
        {
            get { return applicationUser; }
            set
            {
                if (applicationUser == value) return;
                ApplicationUser prevApplicationUser = applicationUser;
                applicationUser = value;
                if (IsLoading) return;
                if (prevApplicationUser != null && prevApplicationUser.NongHo == this)
                    prevApplicationUser.NongHo = null;
                if (applicationUser != null)
                    applicationUser.NongHo = this;
                OnChanged(nameof(ApplicationUser));
            }
        }
    }
}
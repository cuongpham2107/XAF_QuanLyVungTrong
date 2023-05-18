using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enums;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [IntermediateObject(nameof(NhatKyCanhTac), nameof(PhanBon))]
    public class NhatKyBonPhan : BaseObject
    {
        public NhatKyBonPhan(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        NhatKyCanhTac nhatKyCanhTac;
        PhanBon phanBon;
        string lieuLuong;
        string phuongPhap;
        string lyDo;
        [XafDisplayName("Lý do sử dụng")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhan.LyDo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LyDo
        {
            get => lyDo;
            set => SetPropertyValue(nameof(LyDo), ref lyDo, value);
        }
        [XafDisplayName("Phương pháp bón")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhan.PhuongPhap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string PhuongPhap
        {
            get => phuongPhap;
            set => SetPropertyValue(nameof(PhuongPhap), ref phuongPhap, value);
        }
        [XafDisplayName("Liều lượng")]
        [RuleRequiredField("Bắt buộc phải có NhatKyBonPhan.LieuLuong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LieuLuong
        {
            get => lieuLuong;
            set => SetPropertyValue(nameof(LieuLuong), ref lieuLuong, value);
        }
        [XafDisplayName("Phân Bón")]
        [Association("PhanBon-NhatKyBonPhans")]
        public PhanBon PhanBon
        {
            get => phanBon;
            set => SetPropertyValue(nameof(PhanBon), ref phanBon, value);
        }
        
        [Association("NhatKyCanhTac-NhatKyBonPhans")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
    }
}
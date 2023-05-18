using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.ThuocPhanBon
{
    [DefaultClassOptions]
    [IntermediateObject(nameof(NhatKyCanhTac), nameof(ThuocBVTV))]
    public class NhatKySuDungThuoc : BaseObject
    { 
        public NhatKySuDungThuoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();           
        }
        ThuocBVTV thuocBVTV;
        NhatKyCanhTac nhatKyCanhTac;
        string lieuLuong;
        string phuongPhap;
        string lyDo;
        [XafDisplayName("Lý do sử dụng")]
        [RuleRequiredField("Bắt buộc phải có NhatKySuDungThuoc.LyDo", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LyDo
        {
            get => lyDo;
            set => SetPropertyValue(nameof(LyDo), ref lyDo, value);
        }
        [XafDisplayName("Phương pháp bón")]
        [RuleRequiredField("Bắt buộc phải có NhatKySuDungThuoc.PhuongPhap", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string PhuongPhap
        {
            get => phuongPhap;
            set => SetPropertyValue(nameof(PhuongPhap), ref phuongPhap, value);
        }
        [XafDisplayName("Liều lượng")]
        [RuleRequiredField("Bắt buộc phải có NhatKySuDungThuoc.LieuLuong", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string LieuLuong
        {
            get => lieuLuong;
            set => SetPropertyValue(nameof(LieuLuong), ref lieuLuong, value);
        }
        
        [Association("ThuocBVTV-NhatKySuDungThuocs")]
        public ThuocBVTV ThuocBVTV
        {
            get => thuocBVTV;
            set => SetPropertyValue(nameof(ThuocBVTV), ref thuocBVTV, value);
        }

        [Association("NhatKyCanhTac-NhatKySuDungThuocs")]
        public NhatKyCanhTac NhatKyCanhTac
        {
            get => nhatKyCanhTac;
            set => SetPropertyValue(nameof(NhatKyCanhTac), ref nhatKyCanhTac, value);
        }
    }
}
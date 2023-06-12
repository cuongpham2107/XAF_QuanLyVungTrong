using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Cấu hình Mail")]
    public class MailConfiguration : BaseObject, IListViewInline
    {
        public MailConfiguration(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        string key;
        [XafDisplayName("Khóa")]
        public string Key
        {
            get => key;
            set => SetPropertyValue(nameof(Key), ref key, value);
        }

        string data;
        [XafDisplayName("Giá trị")]
        public string Value
        {
            get => data;
            set => SetPropertyValue(nameof(Value), ref data, value);
        }

        string description;
        [XafDisplayName("Ghi chú")]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }
    }
}
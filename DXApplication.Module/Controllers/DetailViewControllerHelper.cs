using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication.Module.Controllers
{
   
    public partial class DetailViewControllerHelper : ViewController
    {
        
        public DetailViewControllerHelper()
        {
            InitializeComponent();
           
        }
        public static string ClearItemCountInTabCaption(string caption)
        {
            int index = caption.IndexOf('(');
            if (index != -1)
            {
                return caption.Remove(index - 1);
            }
            return caption;
        }

        public static string AddItemCountToTabCaption(string caption, int count)
        {
            return $"{caption} ({count})";
        }
      
    }
}

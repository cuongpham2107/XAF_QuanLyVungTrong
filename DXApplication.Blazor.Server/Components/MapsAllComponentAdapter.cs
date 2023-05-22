using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp;
using Microsoft.AspNetCore.Components;
using DevExpress.ExpressApp.Editors;

namespace DXApplication.Blazor.Server.Components
{
    public class MapsAllComponentAdapter : IComponentAdapter, IComplexControl
    {
        private XafApplication application;
        private RenderFragment component;
        public RenderFragment ComponentContent
        {
            get
            {
                if (component == null)
                {
                    component = builder => {
                        builder.OpenComponent<MapsAllComponent>(0);
                        //builder.AddAttribute(1, nameof(MapsAllComponent.Title), application.Title);
                        builder.CloseComponent();
                    };
                }
                return component;
            }
        }
        public void Refresh() { }
        public void Setup(IObjectSpace objectSpace, XafApplication application)
        {
            this.application = application;
        }
        public object GetValue()
        {
            return null;
        }
        public void SetValue(object value) { }
        public event EventHandler ValueChanged;
    }
}
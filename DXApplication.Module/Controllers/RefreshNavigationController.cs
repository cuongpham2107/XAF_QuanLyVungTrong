using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Map.Native;
using DXApplication.Module.BusinessObjects;
using DXApplication.Module.BusinessObjects.DoDung;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.BusinessObjects.Ticket;
using DXApplication.Module.Extension;

namespace DXApplication.Module.Controllers;

public partial class RefreshNavigationController : ViewController
{
    public RefreshNavigationController()
    {
        TargetViewNesting = Nesting.Root;
        TargetObjectType = typeof(IRefreshNavigation);
    }
    protected override void OnActivated()
    {
        base.OnActivated();
        View.ObjectSpace.Committed += ObjectSpace_Committed;
    }
    private void ObjectSpace_Committed(object sender, System.EventArgs e)
    {
        ShowNavigationItemController controller = Application.MainWindow.GetController<ShowNavigationItemController>();
        if (controller != null)
        {
            controller.ShowNavigationItemAction.BeginUpdate();
            controller.RecreateNavigationItems();
            controller.ShowNavigationItemAction.EndUpdate();
        }
    }
    protected override void OnDeactivated()
    {
        View.ObjectSpace.Committed -= ObjectSpace_Committed;
        base.OnDeactivated();
    }
}

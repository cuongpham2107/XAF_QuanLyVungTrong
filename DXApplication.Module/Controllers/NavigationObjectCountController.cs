using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Map.Native;
using DevExpress.Schedule;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects;
using DXApplication.Module.BusinessObjects.DoDung;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using DXApplication.Module.BusinessObjects.ThuocPhanBon;
using DXApplication.Module.BusinessObjects.Ticket;
using DXApplication.Module.Controllers;

namespace ItemCount.Module.Controllers;

public class NavigationObjectCountController<T> : WindowController 
{
    private ShowNavigationItemController navigationController;
    protected virtual string Getstring()
    {
        string a = "hehe";
        return a;
    }
    protected override void OnFrameAssigned()
    {
        UnsubscribeFromEvents();
        base.OnFrameAssigned();
        navigationController = Frame.GetController<ShowNavigationItemController>();
        if (navigationController != null)
        {
            navigationController.NavigationItemCreated += NavigationItemCreated;
        }
    }
    void NavigationItemCreated(object sender, NavigationItemCreatedEventArgs e)
    {
        var lvId = Application.GetListViewId(typeof(T));
        if (e.ModelNavigationItem.Id == lvId)
        {
            using (IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(T)))
            {
                IModelListView modelListView = (IModelListView)e.ModelNavigationItem.View;
                int objectsCount = objectSpace.GetObjectsCount(typeof(T), CriteriaOperator.Parse(modelListView.Criteria));
                e.NavigationItem.Caption = Getstring() + (objectsCount > 0 ? $" ({objectsCount})" : string.Empty);
            }
        }
    }
    private void UnsubscribeFromEvents()
    {
        if (navigationController != null)
        {
            navigationController.NavigationItemCreated -= NavigationItemCreated;
            navigationController = null;
        }
    }
    protected override void Dispose(bool disposing)
    {
        UnsubscribeFromEvents();
        base.Dispose(disposing);
    }
}
public class TicketController: NavigationObjectCountController<Ticket> { protected override string Getstring() { string a = "Hỏi đáp";return a; } }
public class LoaiCayTrongController : NavigationObjectCountController<LoaiCayTrong> { protected override string Getstring() { string a = "Loại cây trồng"; return a; } }
public class ThuocController : NavigationObjectCountController<ThuocBVTV> { protected override string Getstring() { string a = "Thuốc BVTV"; return a; } }
public class ThietBiController : NavigationObjectCountController<ThieuBiMayMoc> { protected override string Getstring() { string a = "Thiết bị máy móc"; return a; } }
public class PhanBonController : NavigationObjectCountController<PhanBon> { protected override string Getstring() { string a = "Phân bón"; return a; } }
public class NguyenLieuController : NavigationObjectCountController<NguyenLieu> { protected override string Getstring() { string a = "Nguyên vật liệu"; return a; } }
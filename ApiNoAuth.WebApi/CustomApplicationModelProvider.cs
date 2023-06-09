﻿using DevExpress.ExpressApp.WebApi.Mvc;
using DXApplication.Module.BusinessObjects.QLVungTrong;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Linq;
// ...
public class CustomApplicationModelProvider : IApplicationModelProvider
{
    public int Order => -1;

    public void OnProvidersExecuted(ApplicationModelProviderContext context)
    {
    }

    public void OnProvidersExecuting(ApplicationModelProviderContext context)
    {
        foreach (var controller in context.Result.Controllers)
        {
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                if (genericType == typeof(VungTrong))
                {
                    var action = controller.Actions.Where(action => action.ActionName != "Get");
                    foreach( var a in action)
                    {
                        a.ApiExplorer.IsVisible = false;
                    }
                                
                }
            }
        }
    }
}
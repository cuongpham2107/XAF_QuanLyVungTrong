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
using DXApplication.Module.BusinessObjects.QLVungTrong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DXApplication.Module.Controllers
{
    
    public partial class VungTrongController : ViewController
    {
       
        public VungTrongController()
        {
            InitializeComponent();
            Btn_TrangThai();
            //Btn_TrangThaiNhatKy();
        }
        public void Btn_TrangThai()
        {
            var action = new SingleChoiceAction(this, $"{nameof(Btn_TrangThai)}", "Edit")
            {
                Caption = "Sửa tình trạng",
                TargetViewNesting = Nesting.Root,
                TargetViewType = ViewType.Any,
                TargetObjectType = typeof(VungTrong),
                ItemType=SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
                ConfirmationMessage = "Xác nhận chuyển đổi trạng thái?",

            };
            action.Items.AddRange(new[]
            {
                new ChoiceActionItem("Đang hoạt động","hd"),
                new ChoiceActionItem("Ngừng hoạt động","nhd")
            });
            action.Execute += Action_Execute;
        }

        private void Action_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var selection = e.SelectedChoiceActionItem.Data as string;
            var os = Application.CreateObjectSpace();
            switch (selection)
            {
                case "hd":
                    foreach(VungTrong item in View.SelectedObjects)
                    {
                        item.HoatDong= true;
                        this.ObjectSpace.CommitChanges();
                        Application.ShowViewStrategy.ShowMessage("Xác nhận chuyển đổi trạng thái thành công!", InformationType.Success);               
                    }
                    break;
                case "nhd":
                    foreach (VungTrong item in View.SelectedObjects)
                    { 
                        item.HoatDong = false;
                        this.ObjectSpace.CommitChanges();
                        Application.ShowViewStrategy.ShowMessage("Xác nhận chuyển đổi trạng thái thành công!", InformationType.Success); 
                    }
                    break;
            }
        }
        public void Btn_TrangThaiNhatKy()
        {
            var action = new SimpleAction(this, $"{nameof(Btn_TrangThaiNhatKy)}", "Edit")
            {
                Caption = "Hoàn thành",
                TargetViewNesting = Nesting.Any,
                TargetViewType = ViewType.Any,
                TargetObjectType = typeof(NhatKyCanhTac),
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
                TargetObjectsCriteria = "[TrangThai] = ##Enum#DXApplication.Blazor.Common.Enums+TrangThai,DangXyLy# And [TrangThai] <> ##Enum#DXApplication.Blazor.Common.Enums+TrangThai,DaHoanThanh#",
                ConfirmationMessage = "Xác nhận chuyển đổi trạng thái?",
            };
            action.Execute += (s,e)=> 
            {
                foreach(NhatKyCanhTac a in View.SelectedObjects)
                {
                    if (a.TrangThai == Blazor.Common.Enums.TrangThai.DangXyLy)
                    {
                        a.TrangThai = Blazor.Common.Enums.TrangThai.DaHoanThanh;
                    }
                }
                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Chuyển đổi trạng thái thành công!", InformationType.Success);
            };
        }
    }
}

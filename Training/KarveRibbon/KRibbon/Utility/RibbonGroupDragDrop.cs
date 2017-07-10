using KRibbon.Model.Sybase;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Utility
{
    public class RibbonGroupDragDrop
    {
        public static void RibbonGroup_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var ribbongroup = e.Source as RibbonGroup;

                if (ribbongroup == null)
                    return;

                if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(ribbongroup, ribbongroup, DragDropEffects.All);
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        public static void RibbonGroup_Drop(object sender, DragEventArgs e)
        {
            try
            {                
                var target = e.Source as RibbonGroup;
                var origin = e.Data.GetData(typeof(RibbonGroup)) as RibbonGroup;

                if (!target.Equals(origin))
                {
                    var ribbontab = target.Parent as RibbonTab;
                    int originIndex = ribbontab.Items.IndexOf(origin);
                    int targetIndex = ribbontab.Items.IndexOf(target);

                    ribbontab.Items.Remove(origin);
                    ribbontab.Items.Insert(targetIndex, origin);

                    ribbontab.Items.Remove(target);
                    ribbontab.Items.Insert(originIndex, target);

                    UserConfig.SetCurrentUserRibbonTabConfig(ribbontab);
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }
    }
}

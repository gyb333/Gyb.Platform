using Gyb.Design.Client.Main.ViewModel.Base;
using Gyb.Design.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gyb.Design.Client.Main.Panel
{
    public class PanesStyleSelector : StyleSelector
    {
        public Style ToolStyle { get; set; }

        public Style DocumentStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            PaneViewModel pane = item as PaneViewModel;
            if (pane != null)
            {
                switch (pane.Type)
                {
                    case EPaneType.DocumentWindow:
                        return this.DocumentStyle;
                    case EPaneType.ToolWindow:
                        return this.ToolStyle;
                }
            }
            return base.SelectStyle(item, container);
        }
    }
}

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
    public class PanesTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProjectResourceManager { get; set; }

        public DataTemplate PropertySetting { get; set; }

        public DataTemplate Toolbox { get; set; }

        public DataTemplate StartPage { get; set; }

        public DataTemplate EntityDesigner { get; set; }

        public DataTemplate UIDesigner { get; set; }

        public DataTemplate WorkflowDesigner { get; set; }


        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            PaneViewModel pane = item as PaneViewModel;
            if (pane != null)
            {
                switch (pane.Type)
                {
                    case EPaneType.DocumentWindow:
                        return this.GetDocumentDataTemplate(pane as DocumentViewModel, container);
                    case EPaneType.ToolWindow:
                        return this.GetToolDataTemplate(pane as ToolViewModel, container);
                }
            }
            return base.SelectTemplate(item, container);
        }

        private DataTemplate GetToolDataTemplate(ToolViewModel item, DependencyObject container)
        {
            switch (item.ContentType)
            {
                case EToolContentType.ProjectResourceManager:
                    return this.ProjectResourceManager;
                case EToolContentType.PropertySetting:
                    return this.PropertySetting;
                case EToolContentType.Toolbox:
                    return this.Toolbox;
            }
            return base.SelectTemplate(item, container);
        }

        private DataTemplate GetDocumentDataTemplate(DocumentViewModel item, DependencyObject container)
        {
            switch (item.ContentType)
            {
                case EDocumentContentType.WorkflowDesigner:
                    return this.WorkflowDesigner;
                case EDocumentContentType.EntityDesigner:
                    return this.EntityDesigner;
                case EDocumentContentType.StartPage:
                    return this.StartPage;
                case EDocumentContentType.UIDesigner:
                    return this.UIDesigner;
            }
            return base.SelectTemplate(item, container);
        }

    }
}

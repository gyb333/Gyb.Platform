using GalaSoft.MvvmLight;
using Gyb.Design.Client.IServices;
using Gyb.Design.Client.Main.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Gyb.Design.Client.Main.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class WindowsManagerViewModel : ViewModelBase, IViewModelService
    {
        /// <summary>
        /// Initializes a new instance of the WindowsManagerViewModel class.
        /// </summary>
        public WindowsManagerViewModel()
        {
            Tools = new ObservableCollection<ToolViewModel>();
            Documents = new ObservableCollection<DocumentViewModel>();
            InitCommand();
        }

        /// <summary>
        /// 工具窗口集合
        /// </summary>
        public ObservableCollection<ToolViewModel> Tools { get; private set; }


        /// <summary>
        /// 文档窗口集合
        /// </summary>
        public ObservableCollection<DocumentViewModel> Documents { get; private set; }


        public ICommand OpenViewWindow { get; private set; }

        public ICommand CloseViewWindow { get; private set; }




        public void InitCommand()
        {
             
        }

        public void RegisterMessger()
        {
             
        }

    }
}
using GalaSoft.MvvmLight;


namespace Gyb.Design.Client.Main.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private WindowsManagerViewModel _WindowsManager = new WindowsManagerViewModel();
        public WindowsManagerViewModel WindowsManager
        {
            get { return _WindowsManager; }
            private set { _WindowsManager = value; }
        }


        private string _StatuInfo = "就绪";
        public string StatuInfo
        {
            get { return _StatuInfo; }
            set { this.Set<string>(ref _StatuInfo, value, "StatuInfo"); }
        }
    }
}
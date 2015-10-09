using GalaSoft.MvvmLight;
using Gyb.Design.Client.Models;

namespace Gyb.Design.Client.Main.ViewModel.Base
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public abstract class DocumentViewModel : PaneViewModel
    {
        /// <summary>
        /// Initializes a new instance of the DocumentViewModel class.
        /// </summary>
        public DocumentViewModel()
        {
        }


        #region ToolTip

        private string _ToolTip = null;
        public string ToolTip
        {
            get { return _ToolTip; }
            set
            {
                this.Set(ref _ToolTip, value, "ToolTip");
            }
        }

        #endregion

        /// <summary>
        /// 文档关联的数据对象
        /// </summary>
        public object Data { get; private set; }


        
        /// <summary>
        /// 文档内容类型
        /// </summary>
        public abstract EDocumentContentType ContentType { get; }






        public override EPaneType Type
        {
            get { return EPaneType.DocumentWindow; }

        }

    }
}
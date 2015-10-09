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
    public abstract class ToolViewModel : PaneViewModel
    {
        /// <summary>
        /// Initializes a new instance of the ToolViewModel class.
        /// </summary>
        public ToolViewModel()
        {
        }

        #region IsVisible

        private bool _IsVisible = true;
        public bool IsVisible
        {
            get { return _IsVisible; }
            set
            {
                this.Set(ref _IsVisible, value, "IsVisible");
            }
        }

        #endregion

     

        private object _Content = null;
        /// <summary>
        /// 当前窗口的呈现内容
        /// </summary>
        public object Content
        {
            get { return _Content; }
            set { this.Set(ref _Content, value, "Content"); }
        }
  
      
        public override EPaneType Type
        {
            get { return EPaneType.ToolWindow; }
        }



     
        /// <summary>
        /// 
        /// </summary>
        public abstract EToolContentType ContentType { get; }




        /// <summary>
        /// 注册消息
        /// </summary>
        protected virtual void RegisterMessage() { }

        /// <summary>
        /// 根据活动窗口获取当前窗口的内容对象
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        protected virtual object GetContent()
        {
            return this.Content;
        }
      

    }
}
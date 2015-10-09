using GalaSoft.MvvmLight;
using Gyb.Design.Client.Models;
using System;

namespace Gyb.Design.Client.Main.ViewModel.Base
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public abstract class PaneViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the PaneViewModel class.
        /// </summary>
        public PaneViewModel()
        {
        }

        #region Title

        private string _Title = null;
        public string Title
        {
            get { return _Title; }
            set
            {
                this.Set(ref _Title, value, "Title");
            }
        }

        #endregion



        #region ContentId

        private string _ContentId = null;
        public string ContentId
        {
            get { return _ContentId; }
            set
            {
                this.Set(ref _ContentId, value, "ContentId");
            }
        }

        #endregion

        #region IsSelected

        private bool _IsSelected = false;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                this.Set(ref _IsSelected, value, "IsSelected");
            }
        }

        #endregion

        #region IsActive

        private bool _IsActive = false;
        public bool IsActive
        {
            get { return _IsActive; }
            set
            {
                this.Set(ref _IsActive, value, "IsActive");
            }
        }

        #endregion


        /// <summary>
        /// 当前面板的类型
        /// </summary>
        public abstract EPaneType Type { get; }


        public virtual Uri IconSource
        {
            get;

            protected set;
        }

    }
}
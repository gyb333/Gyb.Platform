using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    internal sealed class DatabaseSessionFactory
    {
        #region Private Static Fields
        /// <summary>
        /// The singleton instance of the database session factory.
        /// </summary>
        private static readonly DatabaseSessionFactory databaseSessionFactory = new DatabaseSessionFactory();

        #endregion

        #region Private Fields
        /// <summary>
        /// The session factory instance.
        /// </summary>
        private ISessionFactory sessionFactory = null;
        /// <summary>
        /// The session instance.
        /// </summary>
        private ISession session = null;
        #endregion
        #region Constructors
        /// <summary>
        /// Privately constructs the database session factory instance, configures the
        /// NHibernate framework by using the assemblies listed in the configured spaces(paths)
        /// that are decorated by <see cref="EntityVisibleAttribute"/>.
        /// </summary>
        private DatabaseSessionFactory()
        {
            Configuration nhibernateConfig = new Configuration();
            nhibernateConfig.Configure();
            nhibernateConfig.AddAssembly(typeof(IAggregateRoot).Assembly);
            sessionFactory = nhibernateConfig.BuildSessionFactory();
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// Gets the singleton instance of the database session factory.
        /// </summary>
        public static DatabaseSessionFactory Instance
        {
            get
            {
                return databaseSessionFactory;
            }
        }
        /// <summary>
        /// Gets the singleton instance of the session. If the session has not been
        /// initialized or opened, it will return a newly opened session from the session factory.
        /// </summary>
        public ISession Session
        {
            get
            {
                ISession result = session;
                if (result != null && result.IsOpen)
                    return result;
                return OpenSession();
            }
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Always opens a new session from the session factory.
        /// </summary>
        /// <returns>The newly opened session.</returns>
        public ISession OpenSession()
        {
            this.session = sessionFactory.OpenSession();
            return this.session;
        }
        #endregion
    } 
}

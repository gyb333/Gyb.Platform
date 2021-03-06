﻿using Gyb.FrameWork.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain.Imp.EF
{
    /// <summary>
    /// 自定义事务处理
    /// </summary>
    public class EFRepositoryTransactionContext : IRepositoryTransactionContext
    {

        private IDbContextFactory factory;


        DbContextTransaction transaction;
        private bool _disposed;


        public EFRepositoryTransactionContext(IDbContextFactory factory)
        {
            this.factory = factory;
        }

     

        public void BeginTransaction()
        {
            transaction = factory.GetDbContext().Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    transaction.Dispose();
                }
            }
            _disposed = true;
        }

    }
}

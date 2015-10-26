
using Gyb.FrameWork.IRepositoryUOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.RepositoryUnitOfWork
{
    public abstract class UnitOfWorkRepository  : IUnitOfWorkRepository
    {

        private readonly IUnitOfWork _unitOfWork;



        public UnitOfWorkRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("Unit of work");
            _unitOfWork = unitOfWork;
        }

        public void PersistAdded(IAggregateRoot entity)
        {
            _unitOfWork.RegisterAdded(entity, this);
        }

        public void PersistUpdated(IAggregateRoot entity)
        {
            _unitOfWork.RegisterUpdated(entity, this);            
        }

        public void PersistDeleted(IAggregateRoot entity)
        {
            _unitOfWork.RegisterDeleted(entity, this);    
        }




    
    }
}

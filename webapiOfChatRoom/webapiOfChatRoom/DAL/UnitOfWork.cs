using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapiOfChatRoom.Models;
using webapiOfChatRoom.Repositories;

namespace webapiOfChatRoom.DAL
{
    public class UnitOfWork : IDisposable
    {
        private AccountContext context = new AccountContext();

        private GenericRepository<SysUser> sysUserRepository;
        private GenericRepository<DataModel> dataModelRepository;

        public GenericRepository<SysUser> SysUserRepository
        {
            get
            {
                if (this.sysUserRepository == null)
                {
                    this.sysUserRepository = new GenericRepository<SysUser>(context);
                }
                return sysUserRepository;
            }
        }

        public GenericRepository<DataModel> DataModelRepository
        {
            get
            {
                if (this.dataModelRepository == null)
                {
                    this.dataModelRepository = new GenericRepository<DataModel>(context);
                }
                return dataModelRepository;
            }
        }


        #region Save & Dispose
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
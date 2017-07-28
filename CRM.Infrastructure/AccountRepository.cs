using CRM.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Infrastructure
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private DataContext dc;
        private bool disposed = false;

        public AccountRepository(DataContext dc)
        {
            this.dc = dc;
        }

        //public async Task<bool> CreateCustomer(Customer c)
        //{
        //    try
        //    {
        //        dc.Customers.Add(c);
        //        await dc.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        return false;
        //    }
        //}

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dc.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public interface IAccountRepository : IDisposable
    {
        //Task<bool> CreateCustomer(Customer c);
    }
}

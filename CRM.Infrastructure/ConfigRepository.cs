using CRM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace CRM.Infrastructure
{
    public interface IConfigRepository : IDisposable
    {
    }

    public class ConfigRepository : IConfigRepository, IDisposable
    {
        private DataContext dc;
        private bool disposed = false;

        public ConfigRepository(DataContext dc)
        {
            this.dc = dc;
        }

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
}

using CRM.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRM.Infrastructure
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        private DataContext dc;
        private bool disposed = false;

        public HomeRepository(DataContext dc)
        {
            this.dc = dc;
        }

        #region Single Entity
        public async Task<tbl_Dictionary> GetDictionaryById(int id)
        {
            return await dc.tbl_Dictionary.FindAsync(id);
        }

        public async Task<List<tbl_Dictionary>> GetDictionaryByCategory(int id)
        {
            return await dc.tbl_Dictionary.Where(p => p.DictionaryCategoryId == id).ToListAsync();
        }

        #endregion

        #region For PagedList

        #endregion

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
    public interface IHomeRepository : IDisposable
    {
        // Single Entity
        Task<tbl_Dictionary> GetDictionaryById(int id);
        Task<List<tbl_Dictionary>> GetDictionaryByCategory(int id);

        // For PagedList

    }
}

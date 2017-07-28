using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using OfficeOpenXml;
//using VIETLIKE.Utilities;
using CRM.Enum;

namespace CRM.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DataContext dc;
        private bool disposed = false;

        public GenericRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return dc.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await GetAllAsQueryable().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await dc.Set<T>().FindAsync(id);
        }

        public T FindId(object id)
        {
            return dc.Set<T>().Find(id);
        }

        public async Task<bool> Create(T t)
        {
            try
            {
                dc.Set<T>().Add(t);
                await dc.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(T t)
        {
            try
            {
                dc.Entry<T>(t).State = EntityState.Modified;
                await dc.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(object id, Boolean delete = false)
        {
            try
            {
                var itemdelete = await GetById(id);
                if (delete)
                {
                    dc.Set<T>().Remove(itemdelete);
                    await dc.SaveChangesAsync();
                }
                else
                {
                    typeof(T).GetProperty("IsDelete").SetValue(itemdelete, true);
                    await Update(itemdelete);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteMany(object[] ids, bool delete = false)
        {
            var ListDelete = new List<T>();
            foreach (string id in ids)
            {
                ListDelete.Add(await GetById(Convert.ToInt32(id)));
            }
            try
            {
                if(delete)
                {
                    dc.Set<T>().RemoveRange(ListDelete);
                }
                else
                {
                    foreach(var Delete in ListDelete)
                    {
                        typeof(T).GetProperty("IsDelete").SetValue(Delete, true);
                    }
                }
                
                await dc.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteDocument(int id)
        {
            typeof(T).GetProperty("IsDelete").SetValue(id, true);
            await dc.SaveChangesAsync();
            return true;
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

    public interface IGenericRepository<T> : IDisposable
    {
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        T FindId(object id);
        Task<bool> Create(T t);
        Task<bool> Update(T t);
        Task<bool> Delete(object id, Boolean delete = false);
        Task<bool> DeleteMany(object[] ids, Boolean delete = false);
        Task<bool> DeleteDocument(int id);
    }
}

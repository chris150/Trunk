using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.BaseRepositories
{    

    public class GenericRepository<TEntity, TModel> : IGenericRepository<TEntity>
        where TEntity: class, new()
        where TModel : DbContext, new()
    {

        #region Private members
        public DbContext context;
        internal DbSet<TEntity> dbSet;
        #endregion


        #region ctor | dtor
        
        public GenericRepository()
        {
            this.Init(new TModel());
        
        }

        public GenericRepository(DbContext context)
        {
            this.Init(context);
        }

        #endregion


        public void Init(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

            var objectContext = (this.context as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
            objectContext.ContextOptions.LazyLoadingEnabled = false;
            // objectContext.ContextOptions.ProxyCreationEnabled = false;

        }

        public DbSet<TEntity> DbSet
        {
            get { return this.dbSet; }
        }

        #region [C]reate methods

        public TEntity Insert(TEntity t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t", "Entity is null.");
            }

            this.dbSet.Add(t);
            this.context.SaveChanges();

            return t;
        }

        public async Task<TEntity> InsertAsync(TEntity t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t", "Entity is null.");
            }

            this.dbSet.Add(t);
            await this.context.SaveChangesAsync();

            return t;
        }

        #endregion
        
        #region [R]ead methods

        public ICollection<TEntity> GetAll()
        {
            return this.dbSet.ToList();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await this.dbSet.ToListAsync();
        }

        public TEntity GetByKey(object key)
        {
            /* Alternativ
              return this.context.Set<TEntity>().Find(key); */
            return this.dbSet.Find(key);
        }

        public async Task<TEntity> GetByKeyAsync(object key)
        {
            return await this.dbSet.FindAsync(key);
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> match)
        {
            return this.dbSet.SingleOrDefault(match);   
        }

        public async Task<TEntity> FindAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> match)
        {
            return await this.dbSet.SingleOrDefaultAsync(match);   
        }

        public ICollection<TEntity> FindAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> match)
        {
            return this.dbSet.Where(match).ToList();
        }

        public async Task<ICollection<TEntity>> FindAllAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> match)
        {
            return await this.dbSet.Where(match).ToListAsync();
        }


        public void Reload(TEntity t)
        {
            this.context.Entry(t).Reload();
        }
        
        public async Task ReloadAsync(TEntity t)
        {
            await this.context.Entry(t).ReloadAsync();
        }

        #endregion

        #region [U]pdate methods
        public TEntity Update(TEntity updated, object key)
        {
            if(updated == null)
            {
                throw new ArgumentNullException("updated", "Entity is null!");
            }

            TEntity existing = this.dbSet.Find(key);
            if(existing != null)
            {
                this.context.Entry(existing).CurrentValues.SetValues(updated);

            }

            this.context.SaveChanges();
            return existing;
        }

        public async Task<TEntity> UpdateAsync(TEntity updated, object key)
        {
            if (updated == null)
            {
                throw new ArgumentNullException("updated", "Entity is null!");
            }

            TEntity existing = await this.dbSet.FindAsync(key);
            if (existing != null)
            {
                this.context.Entry(existing).CurrentValues.SetValues(updated);

            }
            await this.context.SaveChangesAsync();
            return existing;
        }



        #endregion

        #region [D]elete methods

        public void Delete (TEntity t )
        {
            if (t == null)
            {
                throw new ArgumentNullException("t", "Entity is null!");
            }

            this.dbSet.Remove(t);
            this.context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t", "Entity is null!");
            }

            this.dbSet.Remove(t);
            await this.context.SaveChangesAsync();
        }

        public void DeleteByKey(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "Key is null!");
            }

            TEntity toDelete = this.dbSet.Find(key);

            if(toDelete != null)
            {
                context.Set<TEntity>().Remove(toDelete);
            }
                        
            this.context.SaveChanges();
        }

        public async Task DeleteByKeyAsync(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key", "Key is null!");
            }

            TEntity toDelete = await this.dbSet.FindAsync(key);

            if (toDelete != null)
            {
                context.Set<TEntity>().Remove(toDelete);
            }

           await this.context.SaveChangesAsync();
        }
     
        #endregion
    }
}

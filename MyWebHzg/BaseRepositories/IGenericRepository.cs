using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebHzg.BaseRepositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, new()
    {

        //void Init(DbContext context);

        DbSet<TEntity> DbSet { get; }
        
        #region [C]reate methods

        TEntity Insert(TEntity t);

        Task<TEntity> InsertAsync(TEntity t);

        
        #endregion

        #region [R]ead methods

        /// <summary>
        /// Liefert alle Objekte der Entität
        /// </summary>
        /// <returns></returns>
        ICollection<TEntity> GetAll();
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Liefert nur das Objekt mit der entsprechenden ID
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetByKey(object key);
        Task<TEntity> GetByKeyAsync(object key);

        /// <summary>
        /// Findet ein einzelnes Objekt mit dem entsprechenden Kriterium
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Findet ein oder mehrere Objekte mit dem entsprechenden Kriterium
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);


        void Reload(TEntity t);
        Task ReloadAsync(TEntity t);

        #endregion

        #region [U]pdate methods

        TEntity Update(TEntity updated, object key);

        Task<TEntity> UpdateAsync(TEntity updated, object key);

        #endregion

        #region [D]elete methods

        void Delete(TEntity t);
        Task DeleteAsync(TEntity t);
        
        void DeleteByKey(object key);
        Task DeleteByKeyAsync(object key);

        #endregion


    }
}

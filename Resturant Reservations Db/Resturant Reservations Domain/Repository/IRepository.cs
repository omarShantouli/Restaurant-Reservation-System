using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Reservations_Db.Resturant_Reservations_Domain
{
    public interface IRepository <TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
       void Update(TEntity entity);
       void Delete(int id);
    }
}

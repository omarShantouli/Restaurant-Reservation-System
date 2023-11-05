using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Reservations_Db.Resturant_Reservations_Domain
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RestaurantReservationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public Repository() 
        {
            _context = new RestaurantReservationDbContext();
            _dbSet= _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Create(TEntity entity) 
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity) 
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id) 
        {
            TEntity entityToDelete = GetById(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

    }
}

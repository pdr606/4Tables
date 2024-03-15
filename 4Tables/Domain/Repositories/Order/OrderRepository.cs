﻿using _4Tables.DataBase.Data;
using _4Tables.Domain.Base.Repositories;
using _4Tables.Domain.Entities.Order;
using _4Tables.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace _4Tables.Domain.Repositories.Order
{
    public class OrderRepository : DomainRepository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<bool> Delete(long id)
        {
            var entity = await _db.
                Set<OrderEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity != null)
            {
                entity.AtivarDesativar(false);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public Task<List<OrderEntity>> FindAllActives()
        {
            return _db.Set<OrderEntity>()
                       .Where(x => x.Available)
                       .AsNoTracking()
                       .ToListAsync();
        }

        public async Task<OrderEntity> GetById(long id)
        {
            return await _db.Set<OrderEntity>().Include(x => x.ClientProducts).ThenInclude(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(OrderEntity entity)
        {
            _db.Set<OrderEntity>().Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

﻿using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        public ApplicationDbContext _db { get; }

        public VillaRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;  
            _db.villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
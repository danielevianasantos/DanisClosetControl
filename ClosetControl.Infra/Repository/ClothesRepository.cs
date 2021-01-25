using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClosetControl.Infra.Repository
{
    public class ClothesRepository : IClothesRepository
    {
        private LiteDatabase _liteDb;

        public ClothesRepository(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }

        public bool Create(Clothes clothes) => _liteDb.GetCollection<Clothes>("Clothes").Insert(clothes) > 0;

        public bool Delete(Guid id) => _liteDb.GetCollection<Clothes>("Clothes").DeleteMany(piece => piece.Id == id)>0;

        public IEnumerable<Clothes> FindAll() => _liteDb.GetCollection<Clothes>("Clothes").FindAll().OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type);

        public IEnumerable<Clothes> FindBySeason(int season) => _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Season == season).OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type);

        public IEnumerable<Clothes> FindByType(string clothesType) => _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Type.Contains(clothesType)).OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type);

        public Clothes FindOne(Guid id) => _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Id == id).FirstOrDefault();

        public bool IsExistent(Guid id) => _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Id == id).Any();

        public bool Update(Clothes clothes) => _liteDb.GetCollection<Clothes>("Clothes").Update(clothes);
    }
}

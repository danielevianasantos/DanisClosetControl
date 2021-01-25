using ClosetControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ClosetControl.Domain.Interfaces
{
    public interface IClothesRepository
    {
        bool Create(Clothes clothes);

        bool Delete(Guid id);

        IEnumerable<Clothes> FindAll();

        IEnumerable<Clothes> FindBySeason(int season);

        IEnumerable<Clothes> FindByType(string clothesType);

        Clothes FindOne(Guid id);

        bool IsExistent(Guid id);

        bool Update(Clothes clothes);
    }
}

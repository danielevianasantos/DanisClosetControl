using ClosetControl.Application.Models;
using ClosetControl.Domain.Entities;
using System;

namespace ClosetControl.Application.Interface
{
    public interface IClothesService
    {
        Response<Clothes> Create(Clothes clothes);
        
        Response<Clothes> Delete(Guid id);

        Response<Clothes> FindAll();

        Response<Clothes> FindBySeason(int season);

        Response<Clothes> FindByType(string clothesType);

        Response<Clothes> FindOne(Guid id);

        Response<Clothes> Update(Clothes clothes);
    }
}
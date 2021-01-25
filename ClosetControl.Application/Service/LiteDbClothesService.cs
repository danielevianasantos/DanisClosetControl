using ClosetControl.Application.Interface;
using ClosetControl.Application.Models;
using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using LiteDB;
using System;
using System.Linq;

namespace ClosetControl.Application.Service
{
    public class LiteDbClothesService : ILiteDbClothesService
    {
        private LiteDatabase _liteDb;
        private readonly IClothesUpdateCreationValidation _updateCreateValidation;
        private readonly IClothesDeleteValidation _deleteValidation;

        public LiteDbClothesService(ILiteDbContext liteDbContext, IClothesUpdateCreationValidation updateCreateValidation, IClothesDeleteValidation deleteValidation)
        {
            _liteDb = liteDbContext.Database;
            _updateCreateValidation = updateCreateValidation;
            _deleteValidation = deleteValidation;
        }

    public Response<Clothes> Create(Clothes clothes)
        {
            try
            {
                var result = _updateCreateValidation.Validate(clothes);
                if (result.IsValid)
                {
                    _liteDb.GetCollection<Clothes>("Clothes").Insert(clothes);
                    return new Response<Clothes>(true, "");
                }
                return new Response<Clothes>(false, result.Errors.Select(e => e.ErrorMessage).ToList());
            }
            catch(Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> Delete(Guid id)
        {
            try
            {   
                var validationResult = _deleteValidation.Validate(id);
                if (validationResult.IsValid)
                {
                    _liteDb.GetCollection<Clothes>("Clothes").DeleteMany(piece => piece.Id == id);
                    return new Response<Clothes>(true, "");
                }
                return new Response<Clothes>(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> FindAll()
        {
            try
            {
                return new Response<Clothes>(true, null, _liteDb.GetCollection<Clothes>("Clothes").FindAll().OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type));
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> FindOne(Guid id)
        {
            try
            {
                _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Id == id);
                return new Response<Clothes>(true, "");
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> FindByType(string clothesType)
        {
            try
            {
                var researchResult = _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Type.Contains(clothesType)).OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type);
                if (!researchResult.Any())
                    return new Response<Clothes>(true, "You don't have any piece of that kind. If you really need it, you'd better go shopping.");
                return new Response<Clothes>(true, null, researchResult);
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> Update(Clothes clothes)
        {
            try
            {
                var result = _updateCreateValidation.Validate(clothes);
                if (result.IsValid)
                {
                    _liteDb.GetCollection<Clothes>("Clothes").Update(clothes);
                    return new Response<Clothes>(true, "");
                }
                return new Response<Clothes>(false, result.Errors.Select(e => e.ErrorMessage).ToList());
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }

        public Response<Clothes> FindBySeason(int season)
        {
            try
            {
                var researchResult = _liteDb.GetCollection<Clothes>("Clothes").Find(piece => piece.Season == season).OrderByDescending(piece => piece.LastUsed).OrderBy(piece => piece.Type);
                if (!researchResult.Any())
                    return new Response<Clothes>(true, "There is no piece propper for this season. You'd better go shopping.");
                return new Response<Clothes>(true, null, researchResult);
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }
    }
}

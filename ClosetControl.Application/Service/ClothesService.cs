using ClosetControl.Application.Interface;
using ClosetControl.Application.Models;
using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using LiteDB;
using System;
using System.Linq;

namespace ClosetControl.Application.Service
{
    public class ClothesService : IClothesService
    {
        private readonly IClothesUpdateCreationValidation _updateCreateValidation;
        private readonly IClothesDeleteValidation _deleteValidation;
        private readonly IClothesRepository _clothesRepository;

        public ClothesService(IClothesUpdateCreationValidation updateCreateValidation, IClothesDeleteValidation deleteValidation, IClothesRepository clothesRepository)
        {
            _updateCreateValidation = updateCreateValidation;
            _deleteValidation = deleteValidation;
            _clothesRepository = clothesRepository;
        }

    public Response<Clothes> Create(Clothes clothes)
        {
            try
            {
                var result = _updateCreateValidation.Validate(clothes);
                if (result.IsValid)
                {
                    var createResult = _clothesRepository.Create(clothes);
                    if(createResult)
                        return new Response<Clothes>(createResult, "Done!");
                    return new Response<Clothes>(createResult, "Not done!");
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
                    var deleteResult =  _clothesRepository.Delete(id);
                    if (deleteResult)
                        return new Response<Clothes>(deleteResult, "Done!");
                    return new Response<Clothes>(deleteResult, "Not done!");
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
                var findResult = _clothesRepository.FindAll();
                if(findResult.Any())
                    return new Response<Clothes>(true, $"You have a total of {findResult.Count()} pieces in your closet.", findResult);
                return new Response<Clothes>(false, "You don't have any piece in your closet.", findResult);
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
                var searchResult = _clothesRepository.FindBySeason(season);
                if (!searchResult.Any())
                    return new Response<Clothes>(true, "There is no propper piece for this season in your closet. You'd better go shopping.");
                return new Response<Clothes>(true, "Here are all you options", searchResult);
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
                var searchResult = _clothesRepository.FindByType(clothesType);
                if (!searchResult.Any())
                    return new Response<Clothes>(true, "You don't have any piece of that kind. If you really need it, you'd better go shopping.");
                return new Response<Clothes>(true, "Here are all pieces that you own of that kind.", searchResult);
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
                var searchResult = _clothesRepository.FindOne(id);
                if(searchResult != null)
                    return new Response<Clothes>(true, searchResult);
                else
                    return new Response<Clothes>(false, "You don't have such a piece in your closet.");
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
                var validationResult = _updateCreateValidation.Validate(clothes);
                if (validationResult.IsValid)
                {
                    var updateResult = _clothesRepository.Update(clothes);
                    if (updateResult)
                        return new Response<Clothes>(updateResult, "Done!");
                    return new Response<Clothes>(updateResult, "Not done!");
                }
                return new Response<Clothes>(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            catch (Exception e)
            {
                return new Response<Clothes>(false, e.Message);
            }
        }
    }
}

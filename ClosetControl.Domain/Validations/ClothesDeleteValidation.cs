using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using FluentValidation;
using System;

namespace ClosetControl.Domain.Validations
{
    public class ClothesDeleteValidation : AbstractValidator<Guid>, IClothesDeleteValidation
    {
        private readonly ILiteDbContext _liteDbContext;
        public ClothesDeleteValidation(ILiteDbContext liteDbContext)
        {
            VerifyIfExistent();
            _liteDbContext = liteDbContext;
        }

        private void VerifyIfExistent()
        {
            RuleFor(piece => piece).Must(id =>
              {
                  return _liteDbContext.Database.GetCollection<Clothes>("Clothes").FindOne(piece => piece.Id == id) != null;
              }).WithMessage("There's no such piece in this closet.");
            
        }
    }
}

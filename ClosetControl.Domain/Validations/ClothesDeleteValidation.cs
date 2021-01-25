using ClosetControl.Domain.Interfaces;
using FluentValidation;
using System;

namespace ClosetControl.Domain.Validations
{
    public class ClothesDeleteValidation : AbstractValidator<Guid>, IClothesDeleteValidation
    {
        private readonly IClothesRepository _clothesRepository;
        public ClothesDeleteValidation(IClothesRepository clothesRepository)
        {
            VerifyIfExistent();
            _clothesRepository = clothesRepository;
        }

        private void VerifyIfExistent()
        {
            RuleFor(piece => piece).Must(id =>
              {
                  return _clothesRepository.IsExistent(id);
              }).WithMessage("There's no such piece in this closet.");
        }
    }
}

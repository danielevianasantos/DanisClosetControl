using ClosetControl.Domain.Entities;
using ClosetControl.Domain.Interfaces;
using FluentValidation;

namespace ClosetControl.Domain.Validations
{
    public class ClothesUpdateCreationValidation : AbstractValidator<Clothes>, IClothesUpdateCreationValidation
    {
        private readonly ILiteDbContext _liteDbContext;
        public ClothesUpdateCreationValidation(ILiteDbContext liteDbContext)
        {
            VerifyCreation();
            _liteDbContext = liteDbContext;
        }

        private void VerifyCreation()
        {
            RuleFor(piece => piece.Type).NotEmpty().WithMessage("Please enter with the closet piece type.").MaximumLength(20).WithMessage("Do not exceed the maximum of 20 characters.");
            RuleFor(piece => piece.Fabric).NotEmpty().WithMessage("Please enter with the closet piece fabric.").MaximumLength(20).WithMessage("Do not exceed the maximum of 20 characters.");
            RuleFor(piece => piece.Style).NotEmpty().WithMessage("Please enter with the closet piece style.").MaximumLength(20).WithMessage("Do not exceed the maximum of 20 characters.");
            RuleFor(piece => piece.Observation).MaximumLength(20).WithMessage("Do not exceed the maximum of 20 characters.");
            RuleFor(piece => piece.Season).NotEmpty().WithMessage("There are only four seasons: 1 = Winter, 2 = Spring, 3 = Summer, 4 = Fall. Please choose one of them or all of them with 5").LessThanOrEqualTo(5).WithMessage("There are only four seasons: 1 = Winter, 2 = Spring, 3 = Summer, 4 = Fall. Please choose one of them or all of them with 5");
        }
    }
}

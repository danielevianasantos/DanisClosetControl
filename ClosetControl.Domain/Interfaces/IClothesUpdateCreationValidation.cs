using ClosetControl.Domain.Entities;
using FluentValidation;

namespace ClosetControl.Domain.Interfaces
{
    public interface IClothesUpdateCreationValidation : IValidator<Clothes>
    {
    }
}

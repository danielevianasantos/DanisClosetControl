using FluentValidation;
using System;

namespace ClosetControl.Domain.Interfaces
{
    public interface IClothesDeleteValidation : IValidator<Guid>
    {
    }
}

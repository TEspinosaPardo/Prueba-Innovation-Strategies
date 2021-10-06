using FluentValidation;
using SampleApp.Application.Contracts.DTO;

namespace SampleApp.Application.Validators
{
    /// <summary>
    /// Fluent validations for the SampleForCreate DTO
    /// </summary>
    internal class SampleForCreateValidator : AbstractValidator<SampleForCreate>
    {
        public SampleForCreateValidator()
        {
            RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("'Name' cannot be null");
        }
    }
}

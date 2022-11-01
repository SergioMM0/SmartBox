using Domain;
using FluentValidation;

namespace Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(o => o.UserId).NotNull();
        RuleFor(o => o.DeliveryAddress).NotEmpty().NotNull();
        /*
        RuleFor(o => o.Boxes).NotEmpty().NotNull();
        RuleFor(o => o.User).NotNull();
        */
    }
}
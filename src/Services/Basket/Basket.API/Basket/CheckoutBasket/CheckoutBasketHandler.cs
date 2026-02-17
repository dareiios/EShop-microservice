using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketCommand(CheckoutBasketDto CheckoutBasketDto) : ICommand<CheckoutBasketResult>;
    public record CheckoutBasketResult(bool IsSuccess);
    public class CheckoutBasketCommandValidator
    : AbstractValidator<CheckoutBasketCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            RuleFor(x => x.CheckoutBasketDto).NotNull().WithMessage("BasketCheckoutDto can't be null");
            RuleFor(x => x.CheckoutBasketDto.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }

    //publishEndpoint to publish an event to rabbitMq
    public class CheckoutBasketHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint)
        : ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
    {
        //????
        public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
        {
            //steps: retrive basket, publish basket checkoutEvent, delete basket

            var basket = await repository.GetBasketAsync(command.CheckoutBasketDto.UserName, cancellationToken);
            if (basket is null)
                return new(false);

            var eventMessage = command.CheckoutBasketDto.Adapt<BasketCheckoutEvent>();
            eventMessage.TotalPrice = basket.TotalPrice;

            await publishEndpoint.Publish(eventMessage, cancellationToken);//send event to rabbitmq(to different service=>BasketCheckoutEventHandler)
            await repository.DeleteBasketAsync(command.CheckoutBasketDto.UserName, cancellationToken);
            return new(true);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace GraphQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddMakePayload> AddMakeAsync(AddMakeInput input, [ScopedService] AppDbContext context, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            var make = new Make
            {
                Name = input.Name
            };
            context.Makes.Add(make);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnMakeAdded), make, cancellationToken);
            return new AddMakePayload(make);
        }
        
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCarPayload> AddCarAsync(AddCarInput input, [ScopedService] AppDbContext context)
        {
            var car = new Car
            {
                Name = input.Name,
                MakeId = input.MakeId,
                BodyType = input.BodyType
            };
            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return new AddCarPayload(car);
        }
    }
}
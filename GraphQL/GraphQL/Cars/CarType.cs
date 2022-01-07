using System.Linq;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQL.Cars
{
    public class CarType: ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.Description("Represents a Car Model");

            descriptor
                .Field(f => f.Make)
                .ResolveWith<Resolvers>(c => c.GetMake(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the Make to which the car model belongs");
        }
        
        private class Resolvers
        {
            public Make GetMake([Parent]Car car, [ScopedService] AppDbContext context)
            {
                return context.Makes.FirstOrDefault(m => m.Id == car.MakeId);
            }
        }
    }
}
using System.Linq;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQL.Cars
{
    public class MakeType: ObjectType<Make>
    {
        protected override void Configure(IObjectTypeDescriptor<Make> descriptor)
        {
            descriptor.Description("Represents a Car Make");
            // descriptor
            //     .Field(f => f.OriginCountry).Ignore();
            descriptor
                .Field(m => m.Cars)
                .ResolveWith<Resolvers>(m => m.GetCars(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("List of available car models for this make");
        }

        private class Resolvers
        {
            public IQueryable<Car> GetCars([Parent]Make make, [ScopedService] AppDbContext context)
            {
                return context.Cars.Where(c => c.MakeId == make.Id);
            }
            
            //TODO: Check this out on how HotChocolate deals with the Select N+1 issue the code above is creating:
            // https://chillicream.com/docs/hotchocolate/v10/data-fetching/#gatsby-focus-wrapper
        }
    }
}
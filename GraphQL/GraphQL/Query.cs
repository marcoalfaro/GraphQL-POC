using System.Linq;
using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Car> GetCar([ScopedService] AppDbContext context)
        {
            return context.Cars;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Make> GetMake([ScopedService] AppDbContext context)
        {
            return context.Makes;
        }
    }
}
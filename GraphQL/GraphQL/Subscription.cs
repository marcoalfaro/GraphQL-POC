using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GraphQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Make OnMakeAdded([EventMessage] Make make) => make;
    }
}
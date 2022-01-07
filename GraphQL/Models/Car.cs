using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace GraphQL.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [GraphQLDescription("Name of the car model")]
        public string Name { get; set; }
        [GraphQLDescription("Body type of the car model. For example: coupe, sedan, SUV, truck, etc.")]
        public string BodyType { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }
}
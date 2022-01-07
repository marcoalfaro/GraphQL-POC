using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
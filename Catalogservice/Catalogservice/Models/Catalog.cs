using System.ComponentModel.DataAnnotations;
namespace Catalogservice.Models
{
    public class Catalog
    {
        [Key]
        public int catalogId { get; set; }
        [Required]
        public string catalogName { get; set; }
        [Required]
        public string catalogDescription { get; set; }
    }
}
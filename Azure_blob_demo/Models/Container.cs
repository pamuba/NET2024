using System.ComponentModel.DataAnnotations;

namespace Azure_blob_demo.Models
{
    public class Container
    {
        [Required]
        public string Name { get; set; }
    }
}

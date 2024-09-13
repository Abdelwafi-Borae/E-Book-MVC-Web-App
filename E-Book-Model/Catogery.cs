using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Book_Model
{
    public class Catogery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "display order must be betwwen 1 to 100")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

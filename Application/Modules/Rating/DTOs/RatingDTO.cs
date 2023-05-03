using System.ComponentModel.DataAnnotations;

namespace Application.Modules.Ratings.DTOs
{
    public class RatingDTO
    {
        [Key]
        public string Grade { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Key]
        [Required]
        public Guid ReceiverID { get; set; }

        [Key]
        [Required]
        public Guid AuthorID { get; set; }
    }
}

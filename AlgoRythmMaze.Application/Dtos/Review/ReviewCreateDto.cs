using System.ComponentModel.DataAnnotations;

namespace TopiTopi.Application.Dtos.Review
{
    public class ReviewCreateDto
    {
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The review must be up to 200 characters long.")]
        public required string Text { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The title must be up to 100 characters long.")]
        public required string Title { get; set; }

        public int ClientId { get; set; }
        public int CaregiverId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MvcFirstApp.Models
{
    #region "Movie Class"
    /// <summary>
    /// Movie Class
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Title must be between 4 and 20 char")]
        public string Title { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Movie star must be between 2 and 20 char")]
        public string MovieStar { get; set; }        
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Movie type must be between 2 and 20 char")]
        public string MovieType { get; set; }
                
    }
    #endregion
}
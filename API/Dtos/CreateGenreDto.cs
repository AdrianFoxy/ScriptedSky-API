using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateGenreDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string EnName { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace TodoApi.DTOs
{
    public class CreateTaskDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = null!;
    }
}

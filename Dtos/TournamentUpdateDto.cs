using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public class TournamentUpdateDto
{
    [Required(ErrorMessage = "Title är obligatorisk.")]
    [MinLength(3, ErrorMessage = "Title måste vara minst 3 tecken.")]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int MaxPlayers { get; set; }

    [FutureDate]
    public DateTime Date { get; set; }
}

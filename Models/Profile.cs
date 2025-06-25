using System.ComponentModel.DataAnnotations;

namespace RESTREST_2.Models;

public class Profile{
    public int Id{ get; set; }
    [Required] public string Name{ get; set; } = null!;
    public bool IsActive{ get; set; } = false; 
}
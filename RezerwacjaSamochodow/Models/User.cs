using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Username")]
    public string Username { get; set; }

    [Required]
    [StringLength(256)]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email Address")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
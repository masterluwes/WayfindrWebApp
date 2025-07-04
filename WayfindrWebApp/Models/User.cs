namespace WayfindrWebApp.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string ContactNumber { get; set; }

    public string ProfileImagePath { get; set; }

    public int AssessmentsCompleted { get; set; }

    public DateTime? LastModified { get; set; }

    public string CurrentTrack { get; set; }
}

﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingApp.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}

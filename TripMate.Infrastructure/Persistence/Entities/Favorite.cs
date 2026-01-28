using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TripMate.Infrastructure.Persistence.Entities;

public partial class Favorite
{
    [Key]
    [Column("favorite_id")]
    public int FavoriteId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("destination_id")]
    public int? DestinationId { get; set; }

    [Column("package_id")]
    public int? PackageId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("DestinationId")]
    [InverseProperty("Favorites")]
    public virtual Destination? Destination { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("Favorites")]
    public virtual Package? Package { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Favorites")]
    public virtual User User { get; set; } = null!;
}

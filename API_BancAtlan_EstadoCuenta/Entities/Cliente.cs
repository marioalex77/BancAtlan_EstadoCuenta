using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("cliente")]
public partial class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("nombres")]
    [StringLength(1000)]
    public string Nombres { get; set; } = null!;

    [Column("apellidos")]
    [StringLength(1000)]
    public string Apellidos { get; set; } = null!;

    [Column("genero")]
    [StringLength(1)]
    public string Genero { get; set; } = null!;

    [InverseProperty("IdTarjetaNavigation")]
    public virtual Tarjetum? Tarjetum { get; set; }
}

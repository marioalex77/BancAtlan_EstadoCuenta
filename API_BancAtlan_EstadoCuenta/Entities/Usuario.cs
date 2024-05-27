using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("usuario")]
public partial class Usuario
{
    [Key]
    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("correo")]
    [StringLength(255)]
    public string Correo { get; set; } = null!;

    [Column("password")]
    [StringLength(1000)]
    public string Password { get; set; } = null!;
}

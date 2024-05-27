using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("estado_cuenta")]
public partial class EstadoCuentum
{
    [Key]
    [Column("id_estado_cuenta")]
    public int IdEstadoCuenta { get; set; }

    [Column("id_tarjeta")]
    public int IdTarjeta { get; set; }

    [Column("mes")]
    public int Mes { get; set; }

    [Column("anio")]
    public int Anio { get; set; }

    [Column("disponible", TypeName = "decimal(19, 2)")]
    public decimal Disponible { get; set; }

    [Column("saldo", TypeName = "decimal(19, 2)")]
    public decimal Saldo { get; set; }

    [Column("pago_minimo", TypeName = "decimal(19, 2)")]
    public decimal PagoMinimo { get; set; }

    [Column("fecha_vto_pago", TypeName = "datetime")]
    public DateTime FechaVtoPago { get; set; }

    [ForeignKey("IdTarjeta")]
    [InverseProperty("EstadoCuenta")]
    public virtual Tarjetum IdTarjetaNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("transaccion")]
public partial class Transaccion
{
    [Key]
    [Column("id_transaccion")]
    public int IdTransaccion { get; set; }

    [Column("id_tarjeta")]
    public int IdTarjeta { get; set; }

    [Column("fecha_transaccion", TypeName = "datetime")]
    public DateTime FechaTransaccion { get; set; }

    [Column("fecha_movimiento", TypeName = "datetime")]
    public DateTime FechaMovimiento { get; set; }

    [Column("descripcion")]
    [StringLength(2500)]
    public string Descripcion { get; set; } = null!;

    [Column("id_tipo_transaccion")]
    public int IdTipoTransaccion { get; set; }

    [Column("monto", TypeName = "decimal(19, 4)")]
    public decimal Monto { get; set; }

    [Column("signo")]
    [StringLength(1)]
    [Unicode(false)]
    public string Signo { get; set; } = null!;

    [ForeignKey("IdTarjeta")]
    [InverseProperty("Transaccions")]
    public virtual Tarjetum IdTarjetaNavigation { get; set; } = null!;

    [ForeignKey("IdTipoTransaccion")]
    [InverseProperty("Transaccions")]
    public virtual TipoTransaccion IdTipoTransaccionNavigation { get; set; } = null!;
}

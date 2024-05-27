using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("tarjeta")]
public partial class Tarjetum
{
    [Key]
    [Column("id_tarjeta")]
    public int IdTarjeta { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("numero")]
    [StringLength(16)]
    [Unicode(false)]
    public string Numero { get; set; } = null!;

    [Column("limite_credito", TypeName = "decimal(19, 4)")]
    public decimal LimiteCredito { get; set; }

    [Column("saldo", TypeName = "decimal(19, 4)")]
    public decimal Saldo { get; set; }

    [Column("interes", TypeName = "decimal(5, 2)")]
    public decimal Interes { get; set; }

    [Column("saldo_minimo", TypeName = "decimal(5, 2)")]
    public decimal SaldoMinimo { get; set; }

    [Column("dia_corte_mes")]
    public int DiaCorteMes { get; set; }

    [InverseProperty("IdTarjetaNavigation")]
    public virtual ICollection<EstadoCuentum> EstadoCuenta { get; set; } = new List<EstadoCuentum>();

    [ForeignKey("IdTarjeta")]
    [InverseProperty("Tarjetum")]
    public virtual Cliente IdTarjetaNavigation { get; set; } = null!;

    [InverseProperty("IdTarjetaNavigation")]
    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}

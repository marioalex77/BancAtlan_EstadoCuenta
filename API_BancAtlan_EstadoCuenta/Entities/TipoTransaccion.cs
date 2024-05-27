using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

[Table("tipo_transaccion")]
public partial class TipoTransaccion
{
    [Key]
    [Column("id_tipo_transaccion")]
    public int IdTipoTransaccion { get; set; }

    [Column("valor")]
    [StringLength(1)]
    [Unicode(false)]
    public string Valor { get; set; } = null!;

    [Column("concepto")]
    [StringLength(50)]
    public string Concepto { get; set; } = null!;

    [InverseProperty("IdTipoTransaccionNavigation")]
    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}

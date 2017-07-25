﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpDatabase.Entities
{
    public class Factura : IEntity
    {
        [Column("FacturaId")]
        public virtual int Id { get; set; }

        [Column("ClinetId")]
        public virtual int ClientId { get; set; }

        public virtual int ComandaId { get; set; }
        
        //Asa am eu in baza ca sunt prost tare
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        [ForeignKey("ComandaId")]
        public virtual Comanda Comanda { get; set; }

        [InverseProperty("Factura")]
        public virtual IList<LinieFactura> Linii { get; set; }
    }
}

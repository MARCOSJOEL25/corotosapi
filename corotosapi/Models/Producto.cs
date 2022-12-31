using System;
using System.Collections.Generic;

namespace corotosapi.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Precio { get; set; }
        public bool IsNew { get; set; }
        public bool IsStore { get; set; }
        public int ContactClient { get; set; }
    }
}

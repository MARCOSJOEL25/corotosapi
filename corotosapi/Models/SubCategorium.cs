using System;
using System.Collections.Generic;

namespace corotosapi.Models
{
    public partial class SubCategorium
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
    }
}

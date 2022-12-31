using System;
using System.Collections.Generic;

namespace corotosapi.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            SubCategoria = new HashSet<SubCategorium>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<SubCategorium> SubCategoria { get; set; }
    }
}

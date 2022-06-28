using System;
using System.Collections.Generic;

namespace pt1_mvc.Models
{
    public partial class Llibre
    {
        public int Id { get; set; }
        public string Titol { get; set; } = null!;
        public int AutorId { get; set; }

        public virtual Autor Autor { get; set; } = null!;
    }
}

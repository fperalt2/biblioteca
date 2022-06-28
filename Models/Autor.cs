using System;
using System.Collections.Generic;

namespace pt1_mvc.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Llibres = new HashSet<Llibre>();
        }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Cognoms { get; set; } = null!;

        public virtual ICollection<Llibre> Llibres { get; set; }

        public string FullName
        {
            get
            {
                return Nom + " " + Cognoms;
            }
        }
    }
}

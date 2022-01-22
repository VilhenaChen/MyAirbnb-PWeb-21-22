using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP.Models
{
    public class Imagem
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public virtual ICollection<Imovel> Imoveis { get; set; }
    }
}

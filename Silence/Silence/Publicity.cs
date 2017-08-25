using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silence
{
   public class Publicity
    {
        public string Description { get; set; }
        public int Index { get; set; }
        public string PublicidadeToString()
        {
            return "Pulicidade numero: "+Index+"    Descrição: "+Description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Persona
    {
        public Persona() { }
        public Persona(string nom, string apeP)
        {
            this.nom = nom;
            this.apeP = apeP;

        }

        public int id { get; set; }
        public string nom { get; set; }

        public string apeP { get; set; }

        public string apeM { get; set; }



    }
}

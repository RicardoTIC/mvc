using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Helpers
{
    public class auxiliar
    {


        public void msg(string tipo,string msg)
        {
            switch (tipo)
            {
                case "error":

                    Console.WriteLine("Error"); 

                        break;
                case "satisfecho":
                    Console.WriteLine("Satisfecho");
                    break;

                default:
                    break;
            }
        }

    }
}

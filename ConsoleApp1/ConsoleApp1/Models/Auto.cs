using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Auto
    {
        public int Autoid { get; set; } 
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public Propietario propietarioid { get; set; }
        public Color colorid { get; set; }
    }
}

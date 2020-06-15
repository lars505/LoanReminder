using System;
using SQLite;

namespace LoanRimender.Models
{
    public class Rimender
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public String Cedula { get; set; }
        public int Celular { get; set; }
        public string Direccion { get; set; }


        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }

        public int MontoI { get; set; }
        public int MontoF { get; set; }
        public bool debe { get; set; }
    }

    public class Segurity
    {
        public int Pass { get; set; }
    }


}
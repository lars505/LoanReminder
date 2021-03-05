using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace LoanRimender.Modelos
{
    public class Prestamo
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaI { get; set; }
        public DateTime FechaF { get; set; }
        public int MontoI { get; set; }
        public int MontoF { get; set; }
        public bool debe { get; set; }
        public int porcentageinteres { get; set; }
        public int interes { get; set; }
    }
}

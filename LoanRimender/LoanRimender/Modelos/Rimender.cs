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
    }
}
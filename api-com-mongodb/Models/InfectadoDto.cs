using System;

namespace api_com_mongodb.Models
{
    public class InfectadoDto
    {
        public string Cod { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
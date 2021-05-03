using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace api_com_mongodb.Data.Collections
{
    public class Infectado
    {
        public string Cod { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }

        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude, string cod = null)
        {
            this.Cod = (string.IsNullOrEmpty(cod) ? Guid.NewGuid().ToString() : cod);
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
    }
}
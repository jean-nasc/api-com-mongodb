using api_com_mongodb.Data.Collections;
using api_com_mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api_com_mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }


        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }


        [HttpGet("{cod}")]
        public ActionResult ObterInfectadoPorCod(string cod)
        {
            var infectado = _infectadosCollection.FindSync(Builders<Infectado>.Filter.Where(c => c.Cod == cod)).ToList();

            if(infectado.Count == 0) return NotFound();
            
            return Ok(infectado);
        }


        [HttpPost]
        public ActionResult SalvarInfectado(InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, dto);
        }


        [HttpPut("{cod}")]
        public ActionResult AtualizarInfectado(string cod, InfectadoDto dto)
        {
            if(cod != dto.Cod) return BadRequest();

            var doc = _infectadosCollection.FindSync(Builders<Infectado>.Filter.Where(c => c.Cod == cod)).ToList();

            if(doc.Count == 0) return NotFound();

            var atualizar = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude, dto.Cod);

            _infectadosCollection.ReplaceOne(Builders<Infectado>.Filter.Where(c => c.Cod == cod), atualizar);
            
            return Ok(dto);
        }
        

        [HttpDelete("{cod}")]
        public ActionResult DeletarInfectado(string cod)
        {
            var doc = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(c => c.Cod == cod));

            if(!doc.Any<Infectado>()) return NotFound();

            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(c => c.Cod == cod));
            
            return Ok("Infectado deletado com sucesso!");
        }
    }
}
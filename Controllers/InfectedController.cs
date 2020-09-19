using ApiDotNet.Data.Collections;
using ApiDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiDotNet.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class InfectedController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<infected> _infectedCollection;

        
        public InfectedController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectedCollection = _mongoDB.DB.GetCollection<infected>(typeof(infected).Name.ToLower());
        }
        [HttpPost]
        public ActionResult SaveInfected([FromBody] InfectedDTO dto)
        {
            var infect = new infected(dto.BourDate, dto.Sex, dto.Latitude, dto.Longitude);
            _infectedCollection.InsertOne(infect);

            return StatusCode(201, "Infectado adicionado com sucesso.");
        }
        [HttpGet]
        public ActionResult GetInfected()
        {
            var infect = _infectedCollection.Find(Builders<infected>.Filter.Empty).ToList();
            return Ok(infect);
        }

    }
}
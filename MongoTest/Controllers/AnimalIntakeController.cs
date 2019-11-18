using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoTest.Models;
using MongoTest.Services;

namespace MongoTest.Controllers
{
    [ApiController]
    [Route("api/animals")]
    public class AnimalIntakeController : ControllerBase
    {
        private readonly AnimalIntakeService _service;

        public AnimalIntakeController(AnimalIntakeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<AnimalIntake>> Get() => _service.Get();

        [HttpGet("{id:length(24)}", Name = "GetAnimal")]
        public ActionResult<AnimalIntake> Get(string id)
        {
            AnimalIntake animal = _service.Get(id);
            if (animal == null)
                return NotFound();
            
            return animal;
        }

        [HttpPost]
        public ActionResult<AnimalIntake> Create(AnimalIntake data)
        {
            _service.AddData(data);
            return CreatedAtRoute("GetAnimal", new {id = data.Id}, data);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult<AnimalIntake> Update(string id, AnimalIntake data)
        {
            AnimalIntake animal = _service.Get(id);
            if (animal == null)
                return NotFound();

            return _service.ChangeData(id, data);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            AnimalIntake animal = _service.Get(id);
            if (animal == null)
                return NotFound();

            _service.Remove(id);
            return NoContent();
        }

        [HttpGet]
        [Route("stat")]
        public ActionResult<List<CountObject>> GetAnimalStat() => _service.GetCountByAnimal();
        
        [HttpGet]
        [Route("stat/shelter")]
        public ActionResult<List<CountObject>> GetShelterStat() => _service.GetCountByShelter();
        
        [HttpGet]
        [Route("stat/shelter")]
        public ActionResult<List<CountObject>> GetConditionStat() => _service.GetCountByCondition();
    }
}
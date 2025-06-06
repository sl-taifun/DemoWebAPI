using DemoWebAPI.DTO;
using FakeDAL.Entities;
using FakeDAL.Interfaces;
using FakeDAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerRepository _trainerRepository;

        public TrainerController(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TrainerDTO>))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult GetAll()
        {
            IEnumerable<TrainerDTO> trainers = _trainerRepository.GetAll()
                .Select(entity => new TrainerDTO(entity));

            return Ok(trainers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TrainerDTO))]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult GetById(int id)
        {
            Trainer? trainer = _trainerRepository.GetById(id);
            if (trainer == null)
            {
                return NotFound(new { message = $"Trainer #{id} not found"});
            }
            return Ok(new TrainerDTO(trainer));
        }

        [HttpPost]
        [ProducesResponseType(201 , Type = typeof(TrainerDTO))]
        [Produces("application/json")]
        public IActionResult Create(CreateTrainerDTO trainer)
        {
            if (trainer == null)
            {
                return BadRequest("Trainer cannot be null");
            }
            TrainerDTO trainerAdded = new TrainerDTO(_trainerRepository.Add(CreateTrainerDTO.ToEntity(trainer)));
            return CreatedAtAction(nameof(GetById), new { id = trainerAdded.Id }, trainerAdded);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [Produces("application/json")]
        public IActionResult Update(int id, Trainer trainer)
        {
            if (trainer == null || id != trainer.Id)
            {
                return BadRequest("Trainer data is invalid");
            }
            Trainer? updatedTrainer = _trainerRepository.Update(id, trainer);
            if (updatedTrainer == null)
            {
                return NotFound();
            }
            return Ok(updatedTrainer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            bool deleted = _trainerRepository.Delete(id);
            if (!deleted)
            {
                return NotFound( new { message = $"Trainer #{id} not found !" });
            }
            return NoContent();
        }
    }
}

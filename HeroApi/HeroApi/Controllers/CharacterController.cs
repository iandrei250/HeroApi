using HeroApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly DataContext _dataContext;

        public CharacterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var character = await _dataContext.Characters.FindAsync(id);

            if (character == null) return NotFound(id);

            return Ok(character);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(Character character)
        {

            _dataContext.Characters.Add(character);

            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Characters.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> Put(Character character)
        {
            var _character = await _dataContext.Characters.FindAsync(character.Id);

            if (_character == null) return NotFound(character.Id);

            _character.Name = character.Name;
            _character.Surname = character.Surname;
            _character.Age = character.Age;
            _character.Height = character.Height;
            _character.Weight = character.Weight;
            _character.Background = character.Background;
            _character.Ability_Description = character.Ability_Description;

            await _dataContext.SaveChangesAsync();

            return Ok(_character);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var _character = await _dataContext.Characters.FindAsync(id);

            if (_character == null) return NotFound(id);

            _dataContext.Characters.Remove(_character);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Characters.ToListAsync());
        }
    }
}

using AutoMapper;
using HeroApi.Models;
using HeroApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public CharacterController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var character = await _dataContext.Characters.FindAsync(id);

            if (character == null) return NotFound(id);

            return Ok(character);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> GetName([FromBody]string name)
        {
            var character = await _dataContext.Characters.Where(c => c.Name == name).FirstOrDefaultAsync();

            if (character == null) return NotFound(name);

            return Ok(character);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(Character character)
        {

            _dataContext.Characters.Add(character);

            await _dataContext.SaveChangesAsync();
            return Created(new Uri(Request.Host + Request.Path+character.Id), character);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CharacterDTO character)
        {
            var _characterInDb = await _dataContext.Characters.FindAsync(character.Id);

            if (_characterInDb == null) return NotFound(character.Id);

            _mapper.Map(character, _characterInDb);

            await _dataContext.SaveChangesAsync();

            return Ok(_characterInDb);
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

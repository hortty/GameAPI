using GamesAPI.Context;
using GamesAPI.Model;
using GamesAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            try
            {
                return Ok(await _gameRepository.MostrarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<List<Game>>> Post(Game game)
        {
            try
            {
                await _gameRepository.AdicionarAsync(game);
                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<List<Game>>> Put(Game game)
        {

            try
            {
                await _gameRepository.AtualizarAsync(game);
                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Game>>> Delete(Game game)
        {
            try
            {
                await _gameRepository.DeletarAsync(game);
                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("[controller]API")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly VideoGameDbContext _db;

        public VideoGameController(VideoGameDbContext db)
        {
            _db = db;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<VideoGame>>> GetAll()
        {
            return Ok(await _db.VideoGames.ToListAsync());
        }

        [HttpGet("GetById/{id:min(1)}")]
        public async Task<ActionResult<VideoGame>> GetById(int id)
        {
            var videoGame = await _db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }

        [HttpPost("AddVideoGame")]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame videoGame)
        {
            if (videoGame == null)
            {
                return BadRequest();
            }

            _db.VideoGames.Add(videoGame);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = videoGame.Id }, videoGame);
        }

        [HttpPut("UpdateById/{id:min(1)}")]
        public async Task<ActionResult> UpdateVideoGame(int id, VideoGame editedVideoGame)
        {
            var videoGame = await _db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            videoGame.Name = editedVideoGame.Name;
            videoGame.Platform = editedVideoGame.Platform;
            videoGame.Developer = editedVideoGame.Developer;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("DeleteById/{id:min(1)}")]
        public async Task<ActionResult> DeleteVideoGame(int id)
        {
            var videoGame = await _db.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            _db.VideoGames.Remove(videoGame);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}

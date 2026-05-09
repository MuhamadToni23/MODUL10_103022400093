using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MODUL10_103022400093.Model;
using System.Collections.Generic;
using System.Diagnostics;
namespace MODUL10_103022400093.Controllers
{
    // Controller untuk mengelola data game
    [Route("api/[controller]")]
    [ApiController]
    public class GameController
    {
        // List untuk menyimpan data game secara in-memory
        private static List<Game> Game = new List<Game> {
        // Contoh data game yang sudah ada
        new Game {Id = 1, Name = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS",
        Rating = 8.5, Platform = ["PC"], Mode = ["Multiplayer"], IsOnline = true, Harga = 0},

        new Game {Id = 2, Name = "GTA V", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "OpenWorld",
        Rating = 9.5, Platform = ["PC", "PS4", "PS5", "Xbox"], Mode = ["Singleplayer",
        "Multiplayer"], IsOnline = true, Harga = 300000},

        new Game {Id = 3, Name =  "The Witcher 3", Developer = "CD Projekt Red", TahunRilis = 2015, Genre = 
        "RPG", Rating = 9.7, Platform = ["PC", "PS4", "PS5", "Xbox", "Switch"], Mode = 
        ["Singleplayer"], IsOnline = false, Harga = 250000}
        };

        // Endpoint untuk mendapatkan semua data game
        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return Game;
        }

        // Endpoint untuk menambahkan data game baru
        [HttpPost]
         public ActionResult AddGame([FromBody]Game newGame)
         {
             Game.Add(newGame);
            return Ok("Game Berhasil Ditambahkan");
        }

        // Endpoint untuk mendapatkan data game berdasarkan ID
        [HttpGet("{id}")]
        public ActionResult<Game> GetById(int id)
        // Cek apakah ID valid
        {
            if (id < 0 || id >= Game.Count)
           {
                return NotFound("Game tidak ditemukan");
           }
            else
            {
               return Game[id];
            }
        }

        // Endpoint untuk memperbarui data game berdasarkan ID
        [HttpPut("{id}")]
        public ActionResult Update(int id, Game updatedGame)
        // Cek apakah ID valid
        {
            var index = Game.FindIndex(g => g.Id == updatedGame.Id);
            if (id < -1)
                return NotFound("Game tidak ditemukan");
            Game[index] = updatedGame;
            return Ok(updatedGame);
        }

        // Endpoint untuk menghapus data game berdasarkan ID
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        // Cek apakah ID valid
        {
            if (id < 0 || id >= Game.Count)
            {
                return NotFound("Game tidak ditemukan");
            }
            Game.RemoveAt(id);
            return Ok("Game Berhasil Dihapus");
        }

        private ActionResult Ok(Game updatedGame)
        {
            throw new NotImplementedException();
        }

        private ActionResult NotFound(string v)
        {
            return new NotFoundObjectResult(v);
        }

        private ActionResult Ok(string v)
        {
            return new OkObjectResult(v);
        }
    }
}

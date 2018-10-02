using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhittyServer.Web.Data;
using WhittyServer.Web.Entities;
using WhittyServer.Web.Models;

namespace WhittyServer.Web.Controllers
{
    [Route("login/")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly WhittyGittersDbContext _context;

        public StatusController(WhittyGittersDbContext context)
        {
            _context = context;
        }

        //shizznit voor te testen

        [HttpPost]
        public ActionResult<PlayerInfo> Login(string email, string password)
        {
            var player = _context.Players.SingleOrDefault(p => p.Email.Equals(email));
            PlayerInfo playerInfo;
            if (password.Equals(player?.Password))
            {
                playerInfo = new PlayerInfo
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    Highscore = player.Highscore,
                    IngameName = player.IngameName,
                    Image = player.Image
                };
                return playerInfo;
            }
            return NotFound();


            //todo: check alive

        }



    }
}
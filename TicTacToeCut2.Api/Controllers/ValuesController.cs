using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToeCut2.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/tictactoe
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get ()
        {
            return new string[] { "value1" , "value2" };
        }

        // GET api/tictactoe/players
        [HttpGet( "/players" )]
        public List<PlayerModel> GetPlayersList ()
        {
            var webGame = new WebGame();
            return webGame.Model.Players;
        }

        // POST api/values
        [HttpPost]
        public void Post ( [FromBody] string value )
        {
        }

        // PUT api/values/5
        [HttpPut( "{id}" )]
        public void Put ( int id , [FromBody] string value )
        {
        }

        // DELETE api/values/5
        [HttpDelete( "{id}" )]
        public void Delete ( int id )
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;
using FinalProject.Models;
using System.Net;
using FinalProject.Entities;
using FinalProject.Filters;
using System.Security.Claims;

namespace FinalProject.Controllers
{

    [Route("api/[controller]")]
    [TypeFilter(typeof(ModelFilter))]
    public class PokemonController : Controller
    {
        private PokemonDatabase database;
        private Pokedex pokedex;
        private SecurityProvider securityProvider;

        public PokemonController(PokemonDatabase database, Pokedex pokedex, SecurityProvider securityProvider)
        {
            this.database = database;
            this.pokedex = pokedex;
            this.securityProvider = securityProvider;
        }

        [HttpGet]
        public IEnumerable<PokemonModel> Get()
        {
            List<PokemonModel> teamList = new List<PokemonModel>();
            foreach(var key in database.teamDatabase.Keys)
            {
                teamList.Add(database.teamDatabase[key]);
            }
            return teamList.Select(team => team);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return new JsonResult(database.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]PokemonEntity pokemon)
        {
            if (database.teamDatabase.Count == 6)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "You have a full team and cannot add any new Pokemon."
                };
            }
            if (database.CheckIfinDatabase(pokemon.Id))
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Content = "Species Clause: Can't have more than one of the same type of pokemon"
                };
            }
            if (pokemon.Name.Equals("MissingNo") && pokemon.Id.Equals("???") && pokemon.MoveOne.Equals("unknown"))
            {
                Claim MissingNo = new Claim("pokemon", "MissingNo");
                return new JsonResult(this.securityProvider.GetToken(new List<Claim> { MissingNo }));
            }
            database.Add(pokemon.ToModel());
            return new JsonResult(pokemon);
        }

        // DELETE api/values/5
        [HttpPost("{id}")]
        public void Delete(string id)
        {
            if (database.CheckIfinDatabase(id))
            {
                database.Delete(id);
            }
        }
    }
}

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
    [TypeFilter(typeof(AuthorizationFilter))]
    public class HackedPokemonController : Controller
    {
        private PokemonDatabase database;

        public HackedPokemonController(PokemonDatabase database)
        {
            this.database = database;
        }

        [HttpGet]
        public IEnumerable<PokemonModel> Get()
        {
            List<PokemonModel> teamList = new List<PokemonModel>();
            foreach (var key in database.teamDatabase.Keys)
            {
                teamList.Add(database.teamDatabase[key]);
            }
            return teamList.Select(team => team);
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
            database.Add(pokemon.ToModel());
            return new JsonResult(pokemon);
        }
    }
}

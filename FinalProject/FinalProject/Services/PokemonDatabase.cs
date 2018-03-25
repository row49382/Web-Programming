using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Services
{
    public class PokemonDatabase
    {
        public Dictionary<string, PokemonModel> teamDatabase;

        public PokemonDatabase()
        {
            teamDatabase = new Dictionary<string, PokemonModel>();
        }

        public void Add(PokemonModel team)
        {
            team.Position = teamDatabase.Count + 1;
            teamDatabase.Add((team.Position).ToString(), team);
        }

        public PokemonModel Get(string Id)
        {
            return teamDatabase[Id];
        }

        public bool CheckIfinDatabase(string key)
        {
            if (teamDatabase.ContainsKey(key))
                return true;
            return false;
        }

        // look at later
        public void Update(string position, PokemonModel pokemon)
        {
            teamDatabase[position] = pokemon;
        }

        public void Delete(string position)
        {
            teamDatabase.Remove(position);
        }
    }
}

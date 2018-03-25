using FinalProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class Pokedex
    {
        private Dictionary<string, PokedexEntry> pokedex;
        
        public Pokedex()
        {
            //PopulatePokedex();
        }

        public bool IsValidPokemon(PokemonModel pokemon)
        {
            if (pokedex.ContainsKey(pokemon.Id) && pokedex[pokemon.Id].Name == pokemon.Name)
                return true;
            return false;
        }

        private void PopulatePokedex()
        {
            using (StreamReader r = new StreamReader("Gen1Pokes.json"))
            {
                string json = r.ReadToEnd();
                List<PokedexEntry> list = JsonConvert.DeserializeObject<List<PokedexEntry>>(json);
                for (int i = 0; i < list.Count; i++)
                {
                    pokedex.Add(list[i].Number, list[i]);
                }
            }
        }
    }
}

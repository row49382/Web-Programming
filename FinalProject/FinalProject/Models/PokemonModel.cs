using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class PokemonModel
    {
        public int Position { get; set; }
        public int Level { get; set; }
        public string MoveOne { get; set; }
        public string MoveTwo { get; set; }
        public string MoveThree { get; set; }
        public string MoveFour { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public PokemonModel()
        {
            
        }

        public PokemonEntity ToEntity()
        {
            return new PokemonEntity()
            {
                MoveOne = this.MoveOne,
                MoveTwo = this.MoveTwo,
                MoveThree = this.MoveThree,
                MoveFour = this.MoveFour,
                Level = this.Level
            };
        }


    }
}

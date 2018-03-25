using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{

    public class PokemonEntity
    {
        public int Position { get; set; }

        [Required]
        [MaxLength(20)]
        public string MoveOne { get; set; }

        [MaxLength(20)]
        public string MoveTwo { get; set; }

        [MaxLength(20)]
        public string MoveThree { get; set; }

        [MaxLength(20)]
        public string MoveFour { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Id { get; set; }

        [Range(1, 100)]
        public int Level { get; set; }

        public PokemonModel ToModel()
        {
            return new PokemonModel()
            {
                Name = this.Name,
                MoveOne = this.MoveOne,
                MoveTwo = this.MoveTwo,
                MoveThree = this.MoveThree,
                MoveFour = this.MoveFour,
                Id = this.Id,
                Level = this.Level
            };
        }
    }
}

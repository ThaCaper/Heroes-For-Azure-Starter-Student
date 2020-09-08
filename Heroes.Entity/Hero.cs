using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Entity
{
   public class Hero
    {
        public int HeroId { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}

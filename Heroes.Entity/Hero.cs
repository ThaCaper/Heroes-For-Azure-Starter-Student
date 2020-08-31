using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Entity
{
   public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> pets { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Model
{
    public class PokemonReturn
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<PokemonModel> results { get; set; }

    }
}

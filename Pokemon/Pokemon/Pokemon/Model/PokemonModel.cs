using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Model
{
    public class PokemonModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image { get; set; } 
        public string anotation { get; set; } 
    }
}

using Pokemon.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.DataAccess
{

        public static class Database
        {
            public static  SQLiteAsyncConnection _database;

            public static void NewDatabase(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<PokemonModel>();
            }

            public static Task<List<PokemonModel>> GetItemAsync()
            {
                return _database.Table<PokemonModel>().ToListAsync();
            }

            public static Task<int> SaveItemAsync(PokemonModel person)
            {
                return _database.InsertAsync(person);
            }

            public static Task<int> UpdateItemAsync(PokemonModel person)
            {
                return _database.UpdateAsync(person);
            }

            public static Task<int> DeleteItemAsync(PokemonModel person)
            {
                return _database.DeleteAsync(person);
            }
        }
    }


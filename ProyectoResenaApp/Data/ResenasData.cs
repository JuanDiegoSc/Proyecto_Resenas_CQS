using SQLite;
using System.IO;
using ProyectoResenaApp.Models;

namespace ProyectoResenaApp.Data
{
    public class ResenasData
    {
        private static SQLiteConnection _database;
        private static readonly string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "games.db3");

        public ResenasData()
        {
            _database = new SQLiteConnection(_databasePath);
            _database.CreateTable<Resena>();
        }

        public List<Resena> GetResenasForGame(string gameName)
        {
            return _database.Table<Resena>().Where(r => r.GameName == gameName).ToList();
        }

        public void SaveResena(Resena resena)
        {
            _database.Insert(resena);
        }

        public void UpdateResena(Resena resena)
        {
            _database.Update(resena);
        }

        public void DeleteResena(int id)
        {
            _database.Delete<Resena>(id);
        }
    }
}

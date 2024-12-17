using System;
using System.Data.SQLite;

namespace TeslaRentalPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=tesla_rental.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                InitializeDatabase(connection);

                Console.WriteLine("Datubaze izveidota.");
            }
        }

        static void InitializeDatabase(SQLiteConnection connection)
        {
            string izveidoTesla = @"CREATE TABLE IF NOT EXISTS TeslaMasina (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                Modelis TEXT NOT NULL,
                StundasLikme REAL NOT NULL,
                KmLikme REAL NOT NULL
            );";

            string izveidoKlientus = @"CREATE TABLE IF NOT EXISTS Klienti (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                VardsUzvards TEXT NOT NULL,
                Epasts TEXT NOT NULL
            );";

            string izveidoIre = @"CREATE TABLE IF NOT EXISTS Ire (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                KlientsID INTEGER NOT NULL,
                CarID INTEGER NOT NULL,
                SakumaLaiks DATETIME NOT NULL,
                BeiguLaiks DATETIME NOT NULL,
                NobrauktieKm REAL NOT NULL,
                Maksajums REAL NOT NULL,
                FOREIGN KEY(CustomerID) REFERENCES Klienti(ID),
                FOREIGN KEY(CarID) REFERENCES TeslaMasina(ID)
            );";

            using (var command = new SQLiteCommand(izveidoTesla, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(izveidoKlientus, connection))
            {
                command.ExecuteNonQuery();
            }

            using (var command = new SQLiteCommand(izveidoIre, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

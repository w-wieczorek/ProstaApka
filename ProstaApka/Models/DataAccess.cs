using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace ProstaApka.Models;

public static class DataAccess
{
    public static async Task<List<Osoba>> FindPersons(int type)
    {
        SQLiteConnection connection = new SQLiteConnection();
        connection.ConnectionString = "Data Source=d:\\sqlite\\prosta.db;Version=3;";
        await connection.OpenAsync();
        string query = $"SELECT * FROM osoby WHERE type = {type}";
        var output = await connection.QueryAsync<Osoba>(query);
        var result = output.ToList();
        await connection.CloseAsync();
        return result;
    }
}
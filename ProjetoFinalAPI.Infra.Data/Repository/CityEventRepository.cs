using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using ProjetoFinalAPI.Service.Interface;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Infra.Data.Repository
{
    public class CityEventRepository : ICityEventRepository
    {
        private string _stringConnection;
        public CityEventRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
        public async Task<bool> AdicionarEvento(CityEventEntity evento)
        {
            string query = @"INSERT INTO CityEvent(title, description, dateHourEvent, local, address, price, status) 
             VALUES (@title, @description, @dateHourEvent, @local, @address, @price, true)";
            DynamicParameters parametros = new(evento);

            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametros);
            return linhasAfetadas > 0;
        }

        public async Task<IEnumerable<CityEventEntity>> ConsultarEventoLD(string local, DateTime data)
        {
            string query = @"SELECT * FROM CityEvent where local = @local and data (dateHourEvent) = @data";
            DynamicParameters parametros = new();
            parametros.Add("local", local);
            parametros.Add("data", data);
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parametros)).ToList();
        }

        public async Task<List<CityEventEntity>> ConsultarEventoPD(decimal preço, DateTime data)
        {
            string query = "SELECT * FROM CityEvent where data (dateHourEvent) = @data and price = @preço";
            DynamicParameters parametros = new();
            parametros.Add("data", data);
            parametros.Add("preço", preço);
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parametros)).ToList();
        }

        public async Task<List<CityEventEntity>> ConsultarEventoT(string titulo)
        {
            string query = "SELECT * FROM CityEvent where title = @titulo";
            DynamicParameters parametros = new();
            parametros.Add("titulo", titulo);
            using MySqlConnection conn = new(_stringConnection);
            return (conn.Query<CityEventEntity>(query, parametros)).ToList();
        }

        public async Task<bool> EditarEvento(CityEventEntity evento, int id)
        {
            string query = "UPDATE CityEvent set title=@title, description=@description, dateHourEvent=@dateHourEvent," +
                " local=@local, address=@address, price=@price where idEvent=@id";
            DynamicParameters parametros = new(evento);
            parametros.Add("id", id);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametros);
            return linhasAfetadas > 0;
        }

        public async Task<bool> DeletarEvento(int id)
        {
            string query = "DELETE FROM CityEvent WHERE idEvent = @id";
            DynamicParameters parametros = new();
            parametros.Add("id", id);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametros);
            return linhasAfetadas > 0;
        }
    }
}

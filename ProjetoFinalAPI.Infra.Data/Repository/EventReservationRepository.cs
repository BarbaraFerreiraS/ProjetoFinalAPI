﻿using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using ProjetoFinalAPI.Service.Interface;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Infra.Data.Repository
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private string _stringConnection;
        public EventReservationRepository() {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }
        public async Task<IEnumerable<EventReservationEntity>> ConsultarReserva(string nome, string titulo2)
        {
            string query = "SELECT * FROM EventReservation WHERE PersonName = @nome AND Title = @titulo";
            DynamicParameters parametro = new();
            parametro.Add("nome", nome);
            parametro.Add("titulo",titulo2);
            using MySqlConnection conn = new(_stringConnection);
            return conn.Query<EventReservationEntity>(query, parametro).ToList();
        }

        public async Task<bool> DeletarReserva(int id)
        {
            string query = "DELETE FROM EventReservation where id = @id";
            DynamicParameters parametro = new(id);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> EditarReserva(int id, int quantidade)
        {
            string query = "UPDATE EventReservation SET Quantity = @quantidade where idReservation = @id";
            DynamicParameters parametro = new(id);
            parametro.Add("quantidade", quantidade);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> AdicionarReserva(EventReservationEntity reserva)
        {
            string query = "INSERT INTO EventReservation (IdEvent, PersonName, Quantity) VALUES (@IdEvent, @PersonName, @Quantity)";
            DynamicParameters parametro = new(reserva);
            using MySqlConnection conn = new(_stringConnection);
            int linhasAfetadas = await conn.ExecuteAsync(query, parametro);
            return linhasAfetadas > 0;
        }

        public async Task<bool> ValidarReserva(int idEvento)
        {
            string query = "SELECT * FROM CityEvent where idEvent = @idEvento";
            DynamicParameters parametro = new();
            parametro.Add("idEvento", idEvento);
            using MySqlConnection conn = new(_stringConnection);
            var valor = await conn.QueryFirstOrDefaultAsync<CityEventDto>(query, parametro);
            return valor.Status;
        }
    }
}

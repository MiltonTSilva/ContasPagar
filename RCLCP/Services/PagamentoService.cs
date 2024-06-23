﻿using RCLCP.Entitys;
using RCLCP.Interfaces;
using SQLite;



namespace RCLCP.Services
{
    public class PagamentoService : IPagamento
    {
        private SQLiteAsyncConnection? _dbConnection;
        private readonly IBancoDados bancoDadosService;

        public PagamentoService(IBancoDados bancoDadosService)
        {

            this.bancoDadosService = bancoDadosService;
            _dbConnection = this.bancoDadosService.ConnectionDB<Pagamento>();
        }


        public async Task<bool> AddPagamentoAsync(Pagamento? pagamento)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.InsertAsync(pagamento) > 0;
            }

            return retorno;
        }

        public async Task<bool> DeletePagamentoAsync(Pagamento? pagamento)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.DeleteAsync(pagamento) > 0;
            }

            return retorno;
        }

        public async Task<Pagamento> GetPagamentoAsync(int id)
        {
            Pagamento retorno = new();
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Pagamento>();
                retorno = await table.FirstOrDefaultAsync(c => c.PagamentoId == id);
            }

            return retorno;
        }

        public async Task<List<Pagamento>> GetPagamentosAsync()
        {
            List<Pagamento> retorno = [];
            if (_dbConnection != null)
            {
                var table = _dbConnection.Table<Pagamento>();
                retorno = await table.ToListAsync();
            }

            return retorno;
        }

       
        public async Task<bool> UpdatePagamentoAsync(Pagamento? pagamento)
        {
            bool retorno = false;
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.UpdateAsync(pagamento) > 0;
            }
            return retorno;
        }

        public async Task<List<Pagamento>> GetPagamentosComFornecedorAsync()
        {
            List<Pagamento> retorno = [];
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.Table<Pagamento>().ToListAsync();
                foreach (var pagamento in retorno)
                {
                    pagamento.Fornecedor = await _dbConnection.FindAsync<Fornecedor>(pagamento.FornecedorId);
                }
            }
            return retorno;
        }

        public async Task<Pagamento> GetPagamentoComFornecedorAsync(int id)
        {
            Pagamento retorno = new();
            if (_dbConnection != null)
            {
                retorno = await _dbConnection.Table<Pagamento>().FirstOrDefaultAsync(c => c.PagamentoId == id);
                retorno.Fornecedor = await _dbConnection.FindAsync<Fornecedor>(retorno.FornecedorId);

            }
            return retorno;
        }

    }
}

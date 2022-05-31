using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using AppListaSupermercado.Model;
using System.Threading.Tasks;

namespace AppListaSupermercado.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _db;

        public SQLiteDatabaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Produto>().Wait();
        }

       public Task<List<Produto>> GetAllRows()
       {
            return _db.Table<Produto>().OrderByDescending(i => i.Id).ToListAsync();
       }

        public Task<Produto> GetById(int id)
        {
            return _db.Table<Produto>().FirstAsync(i => i.Id == id);
        }

        public Task<int> Insert(Produto p)
        {
            return _db.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string SQL = "UPDATE Produto SET Descricao = ?, Quantidade = ?, ValorEstimado = ?, TotalEstimado = ?, ValorReal = ?, TotalReal = ?, Comprado = ? WHERE Id = ?";

            return _db.QueryAsync<Produto>(SQL,
                p.Descricao,
                p.Quantidade,
                p.ValorEstimado,
                p.TotalEstimado,
                p.ValorReal,
                p.TotalReal,
                p.Comprado,
                p.Id);
        }

        public Task<List<Produto>> UpdateComprado(Produto p)
        {
            string SQL = "UPDATE Produto SET Comprado = ? WHERE Id = ?";

            return _db.QueryAsync<Produto>(SQL,
                p.Comprado,
                p.Id);
        }

        public Task<int> Delete(int id)
        {
            return _db.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produto>> Search(string busca)
        {
            string SQL = "SELECT * FROM Produto WHERE Descricao LIKE %?%";

            return _db.QueryAsync<Produto>(SQL, busca);
        }
    }
}

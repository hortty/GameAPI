using GamesAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq.Expressions;

public interface IRepository<TEntity> where TEntity : Entity
{
        public Task<IEnumerable<TEntity>> MostrarTodos(Expression<Func<TEntity, bool>> filter = null);
        public Task<IEnumerable<TEntity>> AdicionarAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> AtualizarAsync(TEntity entity);
        public Task<IEnumerable<TEntity>> DeletarAsync(TEntity entity);

        public Task<TEntity> MostrarPorId(Guid id);

        public Task<IEnumerable<TEntity>> SalvarAlteracoesAsync();
}

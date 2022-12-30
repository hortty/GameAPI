using GamesAPI.Context;
using GamesAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _DbSet;
    private readonly DataContext _dataContext;

    public Repository(DataContext dataContext)
    {
        _DbSet = dataContext.Set<TEntity>();
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<TEntity>> AdicionarAsync(TEntity entity)
    {
        await _DbSet.AddAsync(entity);
        return await SalvarAlteracoesAsync();
    }

    public async Task<IEnumerable<TEntity>> AtualizarAsync(TEntity entity)
    {
        _DbSet.Update(entity);
        return await SalvarAlteracoesAsync();
    }

    public async Task<IEnumerable<TEntity>> DeletarAsync(TEntity entity)
    {
        _DbSet.Remove(entity);
        return await SalvarAlteracoesAsync();
    }

    public async Task<TEntity> MostrarPorId(Guid id)
    {
        return await _DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> MostrarTodos(Expression<Func<TEntity, bool>> filter = null)
    {
        var query = _DbSet.AsQueryable();

        if(filter != null)
        {
            query = query.Where(filter).AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> SalvarAlteracoesAsync()
    {
        await _dataContext.SaveChangesAsync();
        return await MostrarTodos();
    }
}

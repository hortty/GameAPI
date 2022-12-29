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

    public async Task AdicionarAsync(TEntity entity)
    {
        await _DbSet.AddAsync(entity);
        SalvarAlteracoesAsync();
    }

    public async Task AtualizarAsync(TEntity entity)
    {
        _DbSet.Update(entity);
        SalvarAlteracoesAsync();
    }

    public async Task DeletarAsync(TEntity entity)
    {
        _DbSet.Remove(entity);
        SalvarAlteracoesAsync();
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

    public async void SalvarAlteracoesAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}

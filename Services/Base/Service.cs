using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Services.Base;
public class Service<T> : IService<T> where T : EntityBase
{
    private readonly IRepository<T> _repositoryBase;
    public Service(IRepository<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync(bool active = true)
    {
        return await _repositoryBase.GetAllAsync(active);
    }
    public virtual async Task<T> GetByIdAsync(int id, bool active = true)
    {
        return await _repositoryBase.GetByIdAsync(id, active);
    }
    public virtual async Task SaveAsync(T entity)
    {
        await _repositoryBase.SaveAsync(entity);
    }
    public virtual void Validate(T entity)
    {
        if (entity == null)
            throw new Exception("Entity is null");
        
        if (entity.Id < 0)
            throw new Exception("Id is invalid");
    }
}
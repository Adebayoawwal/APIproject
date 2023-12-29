using Microsoft.AspNetCore.Components.Web;

namespace APIproject.Solution.DataService.Repositries.Interface
{
    public interface IGenericRepositry<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T?> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid id);


    }
}

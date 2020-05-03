using MyFirstShop.Core.Models;
using System.Linq;

namespace MyFirstShop.Core.Contracts
{
    public interface IRespository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}
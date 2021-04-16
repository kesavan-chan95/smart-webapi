using Microsoft.EntityFrameworkCore;
namespace SmartOffice.Infrastructure.Infrastructure
{
    public interface IUnitOfWork<U>
          where U : DbContext
    {
        void Commit();
    }
}

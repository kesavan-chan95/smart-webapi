using Microsoft.EntityFrameworkCore;
namespace SmartOffice.Infrastructure.Infrastructure
{
    public class UnitOfWork<U> : IUnitOfWork<U>
        where U : DbContext
    {
        private readonly U context;
        public UnitOfWork(U context)
        {
            this.context = context;
        }
        public void Commit()
        {
            context.SaveChanges();
        }
    }
}

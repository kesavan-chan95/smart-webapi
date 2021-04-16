using SmartOffice.DataLayer.MasterDBContext;
using SmartOffice.Infrastructure.Infrastructure;

namespace SmartOffice.DataLayer.Repositories
{
    //public class EmployeeRepository
    //{
    //}
    public interface ImasuserRepository : IRepository<Masuser, MasterDBContext.MasterDBContext> { }
    public class masuserRepository : Repository<Masuser, MasterDBContext.MasterDBContext>, ImasuserRepository
    {
        public masuserRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface IconfigdatamanagerRepository : IRepository<Configdatamanager, MasterDBContext.MasterDBContext> { }
    public class configdatamanagerRepository : Repository<Configdatamanager, MasterDBContext.MasterDBContext>, IconfigdatamanagerRepository
    {
        public configdatamanagerRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface IconfiglovRepository : IRepository<Configlov, MasterDBContext.MasterDBContext> { }
    public class configlovRepository : Repository<Configlov, MasterDBContext.MasterDBContext>, IconfiglovRepository
    {
        public configlovRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface IconfigsubscriptionRepository : IRepository<Configsubscription, MasterDBContext.MasterDBContext> { }
    public class configsubscriptionRepository : Repository<Configsubscription, MasterDBContext.MasterDBContext>, IconfigsubscriptionRepository
    {
        public configsubscriptionRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasacgroupRepository : IRepository<Masacgroup, MasterDBContext.MasterDBContext> { }
    public class masacgroupRepository : Repository<Masacgroup, MasterDBContext.MasterDBContext>, ImasacgroupRepository
    {
        public masacgroupRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasacmasterRepository : IRepository<Masacmaster, MasterDBContext.MasterDBContext> { }
    public class masacmasterRepository : Repository<Masacmaster, MasterDBContext.MasterDBContext>, ImasacmasterRepository
    {
        public masacmasterRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasaddressRepository : IRepository<Masaddress, MasterDBContext.MasterDBContext> { }
    public class masaddressRepository : Repository<Masaddress, MasterDBContext.MasterDBContext>, ImasaddressRepository
    {
        public masaddressRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasbranchRepository : IRepository<Masbranch, MasterDBContext.MasterDBContext> { }
    public class masbranchRepository : Repository<Masbranch, MasterDBContext.MasterDBContext>, ImasbranchRepository
    {
        public masbranchRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasbusinessRepository : IRepository<Masbusiness, MasterDBContext.MasterDBContext> { }
    public class masbusinessRepository : Repository<Masbusiness, MasterDBContext.MasterDBContext>, ImasbusinessRepository
    {
        public masbusinessRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasemployeeRepository : IRepository<Masemployee, MasterDBContext.MasterDBContext> { }
    public class masemployeeRepository : Repository<Masemployee, MasterDBContext.MasterDBContext>, ImasemployeeRepository
    {
        public masemployeeRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasfacilityRepository : IRepository<Masfacility, MasterDBContext.MasterDBContext> { }
    public class masfacilityRepository : Repository<Masfacility, MasterDBContext.MasterDBContext>, ImasfacilityRepository
    {
        public masfacilityRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImassalarygroupRepository : IRepository<Massalarygroup, MasterDBContext.MasterDBContext> { }
    public class massalarygroupRepository : Repository<Massalarygroup, MasterDBContext.MasterDBContext>, ImassalarygroupRepository
    {
        public massalarygroupRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasshiftRepository : IRepository<Masshift, MasterDBContext.MasterDBContext> { }
    public class masshiftRepository : Repository<Masshift, MasterDBContext.MasterDBContext>, ImasshiftRepository
    {
        public masshiftRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ImasslotRepository : IRepository<Masslot, MasterDBContext.MasterDBContext> { }
    public class masslotRepository : Repository<Masslot, MasterDBContext.MasterDBContext>, ImasslotRepository
    {
        public masslotRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ItrnattendanceRepository : IRepository<Trnattendance, MasterDBContext.MasterDBContext> { }
    public class trnattendanceRepository : Repository<Trnattendance, MasterDBContext.MasterDBContext>, ItrnattendanceRepository
    {
        public trnattendanceRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ItrnledgerRepository : IRepository<Trnledger, MasterDBContext.MasterDBContext> { }
    public class trnledgerRepository : Repository<Trnledger, MasterDBContext.MasterDBContext>, ItrnledgerRepository
    {
        public trnledgerRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ItrnsalarydetailsRepository : IRepository<Trnsalarydetails, MasterDBContext.MasterDBContext> { }
    public class trnsalarydetailsRepository : Repository<Trnsalarydetails, MasterDBContext.MasterDBContext>, ItrnsalarydetailsRepository
    {
        public trnsalarydetailsRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ItrnsalaryheaderRepository : IRepository<Trnsalaryheader, MasterDBContext.MasterDBContext> { }
    public class trnsalaryheaderRepository : Repository<Trnsalaryheader, MasterDBContext.MasterDBContext>, ItrnsalaryheaderRepository
    {
        public trnsalaryheaderRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }

    public interface ItrnslotbookingRepository : IRepository<Trnslotbooking, MasterDBContext.MasterDBContext> { }
    public class trnslotbookingRepository : Repository<Trnslotbooking, MasterDBContext.MasterDBContext>, ItrnslotbookingRepository
    {
        public trnslotbookingRepository(MasterDBContext.MasterDBContext context) : base(context) { }
    }
}

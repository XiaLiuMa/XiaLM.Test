using NetCoreT01.Db.Entities;
using NetCoreT01.Db.IRepositories;

namespace NetCoreT01.Db.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(BaseDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}

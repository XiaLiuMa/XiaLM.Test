using NetCoreT01.Db.Entities;
using NetCoreT01.Db.IRepositories;

namespace NetCoreT01.Db.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(BaseDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}

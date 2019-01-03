using NetCoreT01.Db.Entities;
using System;

namespace NetCoreT01.Db.IRepositories
{
    public interface IDepartmentRepository : IBaseRepository<Department, Guid>
    {
    }
}

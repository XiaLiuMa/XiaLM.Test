using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaLM.Compass.DbManager.TbModel;

namespace XiaLM.Compass.DbManager
{
   public class CompassDbContext: DbContext
    {
        public CompassDbContext() : base("CompassDb") { }
        /// <summary>
        /// Tb_YZSY表
        /// </summary>
        public DbSet<Tb_YZSY> Yzsys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

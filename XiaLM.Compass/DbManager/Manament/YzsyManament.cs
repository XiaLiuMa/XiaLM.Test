using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiaLM.Compass.DbManager.Model;
using XiaLM.Compass.DbManager.Model.Yzsy;
using XiaLM.Compass.DbManager.TbModel;

namespace XiaLM.Compass.DbManager.Manament
{
    public class YzsyManament
    {
        private static YzsyManament instance;
        private readonly static object objLock = new object();
        public static YzsyManament GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new YzsyManament();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public object SelectYzsys()
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    var obj = dbContext.Yzsys.ToList();
                    return obj;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"查询YZSY所有数据失败，{ex.ToString()}");
                }
            }

            return null;
        }

        /// <summary>
        /// 分页查询所有数据
        /// </summary>
        /// <returns></returns>
        public object SelectYzsysLimit(BaseLimitParam limitParam)
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    var list = dbContext.Yzsys.OrderBy(x => x.MDirection).ThenBy(y => y.WDirection).ThenBy(z => z.CDirection).ToList();
                    if (list != null)
                    {
                        return new YzsyLimitResult()
                        {
                            totalCount = list.Count,
                            dataList = list.Skip(limitParam.offset).Take(limitParam.limit).ToList()   //分页查询
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"分页查询YZSY所有数据失败，{ex.ToString()}");
                }
            }

            return null;
        }

        /// <summary>
        /// 查询单个数据
        /// </summary>
        /// <returns></returns>
        public object SelectYzsy(SelectParam select)
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    var obj = dbContext.Yzsys.Where(r => r.MDirection.Equals(select.MDirection) && r.WDirection.Equals(select.WDirection) && r.CDirection.Equals(select.CDirection)).FirstOrDefault();
                    if (obj == null)
                    {
                        var _obj = dbContext.Yzsys.Where(r => r.MDirection.Equals(select.MDirection) && r.WDirection.Equals(select.WDirection)).FirstOrDefault();
                        if (_obj != null) _obj.DescribeF = string.Empty;
                        return _obj;
                    }
                    return obj;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"数据库单个查询YZSY失败，{ex.ToString()}");
                }
            }

            return null;
        }

        /// <summary>
        /// 插入单个数据
        /// </summary>
        /// <param name="importStr"></param>
        /// <returns></returns>
        public bool ImportYzsy(ImportParam import)
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    var obj = dbContext.Yzsys.Where(r => r.MDirection.Equals(import.MDirection) && r.WDirection.Equals(import.WDirection) && r.CDirection.Equals(import.CDirection)).FirstOrDefault();
                    if (obj != null) return false;
                    dbContext.Yzsys.Add(new Tb_YZSY()
                    {
                        MDirection = import.MDirection,
                        WDirection = import.WDirection,
                        DescribeZ = import.DescribeZ,
                        CDirection = import.CDirection,
                        DescribeF = import.DescribeF
                    });
                    var n = dbContext.SaveChanges();
                    if (n > 0) return true;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show($"数据库单个插入YZSY失败，{ex.ToString()}");
                }
            }

            return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idArray"></param>
        /// <returns></returns>
        public object DeleteYzsys(string[] idArray)
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    DbBaseResult baseResult = new DbBaseResult()
                    {
                        TotalNum = idArray.Length,
                        SuccessNum = idArray.Length
                    };
                    for (int i = 0; i < idArray.Length; i++)
                    {
                        int tempid = int.Parse(idArray[i]);
                        var obj = dbContext.Yzsys.Where(r => r.Id.Equals(tempid)).FirstOrDefault();
                        if (obj == null) continue;
                        dbContext.Yzsys.Remove(obj);
                        var n = dbContext.SaveChanges();
                        if (n < 0)
                        {
                            baseResult.SuccessNum--;
                        }
                    }
                    return baseResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除YZSY失败，{ex.ToString()}");
                }
            }

            return null;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        /// <returns></returns>
        public bool ClearYzsys()
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    var obj = dbContext.Yzsys.ToList();
                    dbContext.Yzsys.RemoveRange(obj);
                    var n = dbContext.SaveChanges();
                    if (n >= 0) return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"清空YZSY失败，{ex.ToString()}");
                }
            }

            return false;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="updateStr"></param>
        /// <returns></returns>
        public object UpdateYzsys(List<Tb_YZSY> updates)
        {
            using (CompassDbContext dbContext = new CompassDbContext())
            {
                try
                {
                    DbBaseResult baseResult = new DbBaseResult()
                    {
                        TotalNum = updates.Count,
                        SuccessNum = updates.Count
                    };
                    foreach (var item in updates)
                    {
                        var obj = dbContext.Yzsys.Where(d => d.Id.Equals(item.Id)).FirstOrDefault();
                        if (obj == null) continue;
                        obj.MDirection = item.MDirection;
                        obj.WDirection = item.WDirection;
                        obj.DescribeZ = item.DescribeZ;
                        obj.CDirection = item.CDirection;
                        obj.DescribeF = item.DescribeF;
                        var n = dbContext.SaveChanges();
                        if (n < 0)
                        {
                            baseResult.SuccessNum--;
                        }
                    }
                    return baseResult;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"修改YZSY失败，{ex.ToString()}");
                }
            }

            return null;
        }
    }
}

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrjConsultation.Help
{
    /// <summary>
    /// Execl帮助类
    /// </summary>
    public class ExeclHelp
    {
        private static readonly object lockObj = new object();
        private static ExeclHelp execlHelp;

        public ExeclHelp()
        {

        }

        public static ExeclHelp GetInitialize()
        {
            if (execlHelp == null)
            {
                lock (lockObj)
                {
                    if (execlHelp == null)
                    {
                        execlHelp = new ExeclHelp();
                    }
                }
            }
            return execlHelp;
        }

        /// <summary>
        /// 打开一个Excel文件
        /// </summary>
        /// <param name="fileName">excel文件名，包括文件路径</param>
        public IWorkbook OpenExecl(string fileName)
        {
            IWorkbook workbook = null;
            using (FileStream fs = File.OpenRead(fileName))
            {
                //判断文件格式:HSSF只能读取xls,XSSF只能读取xlsx格式的
                if (Path.GetExtension(fs.Name) == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else if (Path.GetExtension(fs.Name) == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
            }

            return workbook;
        }

    }
}

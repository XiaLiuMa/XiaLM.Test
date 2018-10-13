using System;
using System.Data;
using System.Data.OleDb;
using XiaLM.Tool450.source.common;

namespace CrjConsultation.Help
{
    /// <summary>
    /// Access数据库帮组类
    /// </summary>
    public class AccessHelp
    {
        private static readonly object lockObj = new object();
        private static AccessHelp accessHelp;

        public AccessHelp()
        {

        }

        public static AccessHelp GetInitialize()
        {
            if (accessHelp == null)
            {
                lock (lockObj)
                {
                    if (accessHelp == null)
                    {
                        accessHelp = new AccessHelp();
                    }
                }
            }
            return accessHelp;
        }

        /// <summary>
        /// 连接Access数据库
        /// </summary>
        /// <returns></returns>
        private OleDbConnection ConnectionAccess()
        {
            OleDbConnectionStringBuilder oleString = new OleDbConnectionStringBuilder();
            oleString.Provider = "Microsoft.ACE.OleDB.12.0";
            oleString.DataSource = AppDomain.CurrentDomain.BaseDirectory + @"Resources\MaxvisionRobot.accdb";
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = oleString.ToString();
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 通过ID查问题
        /// </summary>
        /// <param name="qId"></param>
        /// <returns></returns>
        public DataTable SelectQuestionByID(string qId)
        {
            var conn = ConnectionAccess();
            DataTable dt = new DataTable();
            try
            {
                string txtCmd = "SELECT * FROM Question WHERE ID='"+ qId + "'";
                var oleDA = new OleDbDataAdapter(txtCmd, conn);
                oleDA.Fill(dt);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return dt;
        }

    }
}

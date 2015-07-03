using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GlobalWebService.Infrastructure.Configuration;
using SqlServerDataAdapter;

namespace GlobalWebService.Service.FilesTransport
{
    public class FileUploader
    {
        private static readonly string _connStr = ConnectionStringFactory.NXJCConnectionString;
        private static readonly ISqlServerDataFactory _dataFactory = new SqlServerDataFactory(_connStr);
        public static DataTable GetFileInfo(string myFileName, string myGroupId, string myFileClassify)
        {
            string m_Sql = @"Select 
                    A.FileItemId as FileItemId, 
                    A.FileName as FileName,
                    replace(A.FilePath,'\','\\\\') as FilePath,
                    A.FileType as FileType, 
                    A.CreateTime as CreateTime 
                    from system_UserFiles A 
					where A.FileGroupId = '{0}'
					and A.FileClassify = '{1}'
                    {2} 
                    order by A.CreateTime";
            try
            {
                string m_FileNameSql = "";
                if (myFileName != "")
                {
                    m_FileNameSql = string.Format("and A.FileName like '%{0}%' ", myFileName);
                }
                m_Sql = string.Format(m_Sql, myGroupId, myFileClassify, m_FileNameSql);
                DataTable m_Result = _dataFactory.Query(m_Sql);
                m_Result.TableName = "FileInfo";
                return m_Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int AddFileInfo(string myFileName, string myFileGroupId, string myFileClassify, string myFilePath, string myFileType, string myUserId)
        {
            string m_Sql = @"Insert into system_UserFiles 
                ( FileName, FileGroupId, FileClassify, FilePath, FileType,UserId, CreateTime) 
                values
                ( @FileName, @FileGroupId, @FileClassify, @FilePath, @FileType, @UserId, @CreateTime)";
            SqlParameter[] m_Parameters = { new SqlParameter("@FileName", myFileName),
                                          new SqlParameter("@FileGroupId", myFileGroupId),
                                          new SqlParameter("@FileClassify", myFileClassify),
                                          new SqlParameter("@FilePath", myFilePath),
                                          new SqlParameter("@FileType", myFileType),
                                          new SqlParameter("@UserId", myUserId),
                                          new SqlParameter("@CreateTime", DateTime.Now)};
            try
            {
                return _dataFactory.ExecuteSQL(m_Sql, m_Parameters);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static int DeleteFileInfo(string myFileItemId, string myFileClassify)
        {
            string m_Sql = @"DELETE FROM system_UserFiles where FileItemId=@FileItemId and FileClassify = @FileClassify";
            SqlParameter[] m_Parameters = { new SqlParameter("@FileItemId", myFileItemId),
                                          new SqlParameter("@FileClassify", myFileClassify)};
            try
            {
                return _dataFactory.ExecuteSQL(m_Sql, m_Parameters);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static int DeleteAllFileInfoByGroupId(string myFileGroupId, string myFileClassify)
        {
            string m_Sql = @"DELETE FROM system_UserFiles where FileGroupId=@FileGroupId and FileClassify = @FileClassify";
            SqlParameter[] m_Parameters = { new SqlParameter("@FileGroupId", myFileGroupId),
                                          new SqlParameter("@FileClassify", myFileClassify) };
            try
            {
                return _dataFactory.ExecuteSQL(m_Sql, m_Parameters);
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public static string FileRootPath
        {
            get
            {
                return WebConfigurations.FileRootPath;
            }
        }
    }
}

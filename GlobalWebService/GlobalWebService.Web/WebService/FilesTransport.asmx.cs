using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Data;
namespace GlobalWebService.Web.WebService
{
    /// <summary>
    /// FilesTransport 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class FilesTransport : System.Web.Services.WebService
    {
        private static string FileRootPath;
        private const string KeyWord = "UploadFiles";
        public FilesTransport()
        {
            FileRootPath = GlobalWebService.Service.FilesTransport.FileUploader.FileRootPath;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod(Description = "Web 服务提供的方法，返回是否文件上载成功与否。")]
        public int Upload(byte[] myFileStream, string myFileName, string myFileGroupId, string myFileClassify, float myFileSize, string myFilePath, string myFileType, string myKeyId)
        {
            string m_CurrentPath = System.IO.Directory.GetCurrentDirectory();

            try
            {
                string[] m_KeyList = myKeyId.Split(';');
                string m_UserId = m_KeyList[0];
                string m_KeyWord = m_KeyList[1];
                string m_SaveFilePath = FileRootPath + "\\" + myFilePath;
                string m_SaveFileFolder = m_SaveFilePath.Substring(0,m_SaveFilePath.LastIndexOf('\\'));
                if (!Directory.Exists(m_SaveFileFolder))//判断是否存在
                {
                    Directory.CreateDirectory(m_SaveFileFolder);//创建新路径
                }
                if (m_KeyWord == KeyWord)
                {
                    int AddResult = GlobalWebService.Service.FilesTransport.FileUploader.AddFileInfo(myFileName, myFileGroupId, myFileClassify, m_SaveFilePath, myFileType, m_UserId);
                    if (!File.Exists(m_SaveFilePath) && AddResult > 0)
                    {
                        ///定义并实例化一个内存流，以存放提交上来的字节数组。
                        MemoryStream m_MemoryStream = new MemoryStream(myFileStream);
                        ///定义实际文件对象，保存上载的文件。
                        FileStream m_FileStream = new FileStream(m_SaveFilePath, FileMode.Create);
                        ///把内内存里的数据写入物理文件
                        m_MemoryStream.WriteTo(m_FileStream);
                        m_MemoryStream.Close();
                        m_FileStream.Close();
                        m_FileStream = null;
                        m_MemoryStream = null;

                        //mTextFileIO.writeFile("", "UpdateLog.txt", myFileName + ",",

                        System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                        return 1;
                    }
                    else if(File.Exists(m_SaveFilePath))
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 4;
                }
            }
            catch (Exception err)
            {
                System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                return 99;
            }
        }
        [WebMethod(Description = "Web 服务提供的方法，返回是否文件上载成功与否。")]
        public byte[] DownLoad(string myFileName, string myFilePath, string myKeyId)
        {
            string m_CurrentPath = System.IO.Directory.GetCurrentDirectory();
            try
            {
                string[] m_KeyList = myKeyId.Split(';');
                string m_UserId = m_KeyList[0];
                string m_KeyWord = m_KeyList[1];
                if (m_KeyWord == KeyWord)
                {
                    if (File.Exists(myFilePath))
                    {
                        FileStream fs = new FileStream(myFilePath, FileMode.Open);
                        byte[] bytes = new byte[(int)fs.Length];
                        fs.Read(bytes, 0, bytes.Length);
                        fs.Close();
                        //mTextFileIO.writeFile("", "UpdateLog.txt", myFileName + ",",

                        System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                        return bytes;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                return null;
            }
        }
        [WebMethod(Description = "Web 服务提供的方法，返回是否文件上载成功与否。")]
        public DataTable GetFilesList(string myFileName, string myFileGroupId, string myFileClassify, string myKeyId)
        {
            string[] m_KeyList = myKeyId.Split(';');
            string m_UserId = m_KeyList[0];
            string m_KeyWord = m_KeyList[1];
            if (m_KeyWord == KeyWord)
            {
                DataTable m_FilesListTable = GlobalWebService.Service.FilesTransport.FileUploader.GetFileInfo(myFileName, myFileGroupId, myFileClassify);
                return m_FilesListTable;
            }
            else
            {
                return null;
            }
        }
        [WebMethod(Description = "Web 服务提供的方法，删除指定文件")]
        public int Delete(string myFileItemId, string myFileClassify, string myFilePath, string myKeyId)
        {
            string m_CurrentPath = System.IO.Directory.GetCurrentDirectory();
            try
            {
                string[] m_KeyList = myKeyId.Split(';');
                string m_UserId = m_KeyList[0];
                string m_KeyWord = m_KeyList[1];
                if (m_KeyWord == KeyWord)
                {
                    int DeleteResult = GlobalWebService.Service.FilesTransport.FileUploader.DeleteFileInfo(myFileItemId, myFileClassify);
                    string m_DeleteFilePath = myFilePath;

                    if (File.Exists(m_DeleteFilePath) && DeleteResult >= 0)
                    {
                        File.Delete(m_DeleteFilePath);
                    }
                    System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception)
            {
                System.IO.Directory.SetCurrentDirectory(m_CurrentPath);
                return 99;
            }
        }
    }
}

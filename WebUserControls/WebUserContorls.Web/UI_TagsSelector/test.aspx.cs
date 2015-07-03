using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebUserContorls.Web.UI_TagsSelector
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Form.HasKeys())
                {
                    string myFileName = Request.Form["FileName"].ToString();
                    string myFilePath = Request.Form["FilePath"].ToString();
                    try
                    {
                        if (!File.Exists(myFilePath))
                        {
                            Response.ContentType = "text/plain";
                            Response.Clear();
                            Response.Write("{\"Message\":\"该文件不存在!\"}");
                            Response.End();
                        }
                        else
                        {

                            //以字符流的形式下载文件
                            FileStream fs = new FileStream(myFilePath, FileMode.Open);
                            byte[] bytes = new byte[(int)fs.Length];
                            fs.Read(bytes, 0, bytes.Length);
                            fs.Close();
                            Response.Clear();
                            Response.ClearHeaders();
                            Response.Buffer = false;
                            Response.ContentType = "application/octet-stream";
                            //通知浏览器下载文件而不是打开
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(myFileName, System.Text.Encoding.UTF8));
                            Response.BinaryWrite(bytes);
                            Response.Flush();
                            Response.End();

                            //FileInfo m_DownloadFile = new FileInfo(m_FilePath);
                            //Response.Clear();
                            //Response.ClearHeaders();
                            //Response.Buffer = false;
                            //Response.ContentType = "application/octet-stream";
                            ////通知浏览器下载文件而不是打开
                            //Response.AddHeader("Content-Disposition", "inline; filename=" + HttpUtility.UrlEncode(m_FileName, System.Text.Encoding.UTF8));
                            //Response.WriteFile(m_FilePath);
                            //Response.Flush();
                            //Response.End();


                            //FileInfo fileInfo = new FileInfo(myFilePath);
                            //Response.Clear();
                            //Response.ClearContent();
                            //Response.ClearHeaders();
                            //Response.AddHeader("Content-Disposition", "attachment;filename=" + myFileName);
                            //Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                            //Response.AddHeader("Content-Transfer-Encoding", "binary");
                            //Response.ContentType = "application/octet-stream";
                            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                            //Response.WriteFile(fileInfo.FullName);
                            //Response.Flush();
                            //Response.End();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

            }
        }
    }
}
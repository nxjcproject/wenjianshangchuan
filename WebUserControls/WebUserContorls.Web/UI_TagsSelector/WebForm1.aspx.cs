using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebUserContorls.Web.UI_TagsSelector
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal aa = 2342.32234234224243m;
            object bb = (object)aa;
            DataTable m_TestTable = new DataTable("myTable");
            DataColumn m_Column1 = new DataColumn("Id", typeof(String));
            DataColumn m_Column2 = new DataColumn("Value1", typeof(float));
            DataColumn m_Column3 = new DataColumn("Value2", typeof(decimal));
            DataColumn m_Column4 = new DataColumn("Value3", typeof(Double));
            DataColumn m_Column5 = new DataColumn("Value4", typeof(int));
            DataColumn m_Column6 = new DataColumn("Value5", typeof(DateTime));
            m_TestTable.Columns.Add(m_Column1);
            m_TestTable.Columns.Add(m_Column2);
            m_TestTable.Columns.Add(m_Column3);
            m_TestTable.Columns.Add(m_Column4);
            m_TestTable.Columns.Add(m_Column5);
            m_TestTable.Columns.Add(m_Column6);
            m_TestTable.Rows.Add("MyId",322.335386f, 22.253535342342343242342m,4422.234234234234, 3132, DateTime.Now);
            if (m_TestTable.Columns[1].DataType == typeof(System.Single))
            {
                this.TextBox1.Text = string.Format("{0:F4}", m_TestTable.Rows[0][1]);
            }
            else
            {
                this.TextBox1.Text = "errer";
            }
        }
    }
}
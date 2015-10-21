using Fashion.Code.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fashion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string sqlConnectionString=ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            //SqlConnection conn = new SqlConnection(sqlConnectionString);
            //conn.Open();
            ////打开数据库连接
            //SqlCommand cmd = new SqlCommand("select LoginId from Login where LoginId=@LoginId and Password=@Password", conn);
            //cmd.ExecuteNonQuery();


            
           // SqlHelper.executeNonquery("select LoginId from Login where LoginId=@LoginId and Password=@Password",new SqlParameter[] {});
           
            

            

        }
    }
}
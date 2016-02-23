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


            string salt = "90d9862b-0788-4cab-a";
            byte[] pwdAndSaltBytes = System.Text.Encoding.UTF8.GetBytes("222" + salt);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(pwdAndSaltBytes);
            //string hashPassword = hashBytes.ToString();
            string hashPassword = Convert.ToBase64String(hashBytes);
            pwd.Text = hashPassword;
            TextBox1.Text = salt;
            

        }
    }
}
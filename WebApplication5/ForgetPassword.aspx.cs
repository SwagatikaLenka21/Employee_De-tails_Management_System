using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Send_Click(object sender, EventArgs e)
        {
            string UserName = "";
            string EncryptedPassword = "";
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "Pro_Retrieve_Pwd";
            cmd.Parameters.AddWithValue("@Email", txt_Email_id.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    UserName = rdr["UserName"].ToString();
                    EncryptedPassword = rdr["Password_"].ToString();
                }
            }
            con.Close();

            if (!string.IsNullOrEmpty(EncryptedPassword))
            {
                string DecryptedPassword = ENCRYPT_DECRYPT.Decrypt(EncryptedPassword);

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("swagatikalenka59@gmail.com");
                msg.To.Add(txt_Email_id.Text);
                msg.Subject = "Recover your Password";
                msg.Body = ("Your Username is:" + UserName + "<br/><br/>" + "Your Password is:" + DecryptedPassword);
                msg.IsBodyHtml = true;
                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntwd = new NetworkCredential();
                ntwd.UserName = "swagatikalenka59@gmail.com";
                ntwd.Password = "cnfh fhci ahzt amgq";
                smt.UseDefaultCredentials = true;
                smt.Credentials = ntwd;
                smt.Port = 587;
                smt.EnableSsl = true;
                smt.Send(msg);
                lblMessage.Text = "Username and Password Sent Successfully";
                lblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            }
        }

        protected void lnk_BacktoLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Drawing;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        void Clear()
        {
            txt_Mobile.Text = "";
            txt_Email.Text = "";
            txtUserName.Text = "";
            txt_PWD.Text = "";
            txt_ConPwd.Text = "";
        }

        protected void Btn_SignUp_Click(object sender, EventArgs e)
        {
            MailMessage msg;
            SqlCommand cmd = new SqlCommand();
            string ActivationUrl = string.Empty;
            string Email = string.Empty;
            string token = Guid.NewGuid().ToString();
            try
            {
                Con.Open();
                cmd = Con.CreateCommand();
                cmd.CommandText = "USP_SignUp";
                cmd.Parameters.AddWithValue("@Mobile", txt_Mobile.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txt_Email.Text.Trim());
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Password_", ENCRYPT_DECRYPT.Encrypt(txt_PWD.Text.Trim()));
                cmd.Parameters.AddWithValue("@ConfirmPassword", ENCRYPT_DECRYPT.Encrypt(txt_ConPwd.Text.Trim()));
                cmd.Parameters.AddWithValue("@Token", token);
                cmd.Parameters.AddWithValue("@Action", 'S');
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                Email = txt_Email.Text.Trim();
                msg.From = new MailAddress("swagatikalenka59@gmail.com");
                msg.To.Add(Email);
                msg.Subject = "Confirmation Email for Account Activation";

                ActivationUrl = "https://localhost:44347/Account_Activation.aspx?token=" + token;
                msg.Body = "Hi " + txtUserName.Text.Trim() + "!\n" + " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account. \nThanks!";
                msg.IsBodyHtml = true;
                smtp.Credentials = new NetworkCredential("swagatikalenka59@gmail.com", "cnfh fhci ahzt amgq");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(msg);
                Clear();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Confirmation Link to Activate your Account has been sent to your Email address');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                return;
            }
            finally
            {
                ActivationUrl = string.Empty;
                Email = string.Empty;
                Con.Close();
                cmd.Dispose();
            }
        }

        protected void Btn_Reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void Lnk_Signin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
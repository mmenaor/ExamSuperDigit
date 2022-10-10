using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ExamSuperDigit
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Funcion(object sender, EventArgs e)
        {
            if(TextBoxPassword.Text == TextBoxConfirmPass.Text)
            {
                string conect = ConfigurationManager.ConnectionStrings["conection"].ConnectionString;
                SqlConnection sqlConection = new SqlConnection(conect);
                SqlCommand cmd = new SqlCommand("AddUser", sqlConection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = TextBoxUser.Text;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = TextBoxPassword.Text;
                cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = "ExamenEkoNeural";
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                Response.Redirect("login.aspx");
            }
            else
            {
                labelError.Text = "Las contraseñas no son iguales";
            }
        }
    }
}
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ExamSuperDigit
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Funcion(object sender, EventArgs e)
        {
            string conect = ConfigurationManager.ConnectionStrings["conection"].ConnectionString;
            SqlConnection sqlConection = new SqlConnection(conect);
            SqlCommand cmd = new SqlCommand("ValidateUser", sqlConection)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = TextBoxUser.Text;
            cmd.Parameters.Add("@Pass", SqlDbType.VarChar, 50).Value = TextBoxPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = "ExamenEkoNeural";
            SqlDataReader dr = cmd.ExecuteReader();
         
            if (dr.Read())
            {
                Session["loginUser"] = dr["IdUsuario"].ToString();
                Response.Redirect("index.aspx");
            }
            else
            {
                labelError.Text = "Error de usuario o contraseña";
            }
            cmd.Connection.Close();
        }

        protected void ButtonRegister_Funcion(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
        }
    }
}
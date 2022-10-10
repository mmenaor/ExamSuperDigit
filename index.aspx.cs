using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace ExamSuperDigit
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        public void Load_Data()
        {
            SqlCommand cmd = Get_Cmd_Procedure("SelectAllUsersDigits");

            // Adapter object for linking and filling the data
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = cmd
            };

            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            // Create dataser object and fill it with the info
            DataSet objdataset = new DataSet();
            adapter.Fill(objdataset);
            cmd.Connection.Close();

            //Link data to GridView
            DigitsTable.DataSource = objdataset;
            DigitsTable.DataBind();
        }

        // -------------------- Buttons' functions --------------------
        protected void ButtonCalculate_Funcion(object sender, EventArgs e)
        {
            // Determine whether the information is valid (a number) or not
            bool isValidNumber = int.TryParse(TextBoxNumber.Text, out int number);
            if (isValidNumber)
            {
                // Determine whether the number given already exists in the database
                int resultIfExist = Get_Result(number);
                if (resultIfExist != -1)
                {
                    Update_DateTime(number);
                    TextBoxResult.Text = resultIfExist.ToString();
                }
                else
                {
                    // If number is less than 10, the super digit is the same
                    // otherwise a calculation is needed
                    if (number < 10)
                    {
                        Add_Digit(number, number);
                        labelError.Text = "";
                        TextBoxNumber.Text = "";
                        TextBoxResult.Text = "";
                    }
                    else
                    {
                        int result = Calculate_Result(number);
                        Add_Digit(number, result);
                        labelError.Text = "";
                        TextBoxNumber.Text = "";
                        TextBoxResult.Text = "";
                    }
                }
            }
            else
            {
                labelError.Text = "Ingresa un número válido";
                TextBoxNumber.Text = "";
                TextBoxResult.Text = "";
            }
        }

        protected void ButtonDeleteAll_Funcion(object sender, EventArgs e)
        {
            SqlCommand cmd = Get_Cmd_Procedure("DeleteAllUsersDigits");
            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Load_Data();
        }

        protected void ButtonDeleteDigit_Funcion(object sender, EventArgs e)
        {
            // Get the number that is being deleted
            int number;
            Button BtnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)BtnConsultar.NamingContainer;
            number = int.Parse(selectedrow.Cells[1].Text);

            SqlCommand cmd = Get_Cmd_Procedure("DeleteDigit");

            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = number;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Load_Data();
        }

        // -------------------- Auxiliar Functions --------------------
        protected int Get_User_Id()
        {
            return int.Parse(Session["loginUser"].ToString()); ;
        }

        // Connect with database
        protected SqlCommand Get_Cmd_Procedure(string procedure)
        {
            string connect = ConfigurationManager.ConnectionStrings["conection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand(procedure, sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            return cmd;
        }

        // Returns the result (super digit) if the given number already exists in database
        // in other case it returns -1
        protected int Get_Result(int digit)
        {
            SqlCommand cmd = Get_Cmd_Procedure("SelectDigit");

            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = digit;
            SqlDataReader dr = cmd.ExecuteReader();
          
            if (dr.Read())
            {
                int result = int.Parse(dr["Resultado"].ToString());
                cmd.Connection.Close();
                return result;
            }
            else
            {
                cmd.Connection.Close();
                return -1;
            }
        }

        // It changes the register information DateTime of a specific number
        protected void Update_DateTime(int digitToUpdate)
        {
            SqlCommand cmd = Get_Cmd_Procedure("UpdateDigit");

            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = digitToUpdate;
            cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Load_Data();
        }
        
        // It adds a new register with the new number, calculation and datetime
        protected void Add_Digit(int digit, int result)
        {
            SqlCommand cmd = Get_Cmd_Procedure("AddDigit");
            cmd.Connection.Open();
            cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Get_User_Id();
            cmd.Parameters.Add("@Numero", SqlDbType.Int).Value = digit;
            cmd.Parameters.Add("@Resultado", SqlDbType.Int).Value = result;
            cmd.Parameters.Add("@FechaHora", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            Load_Data();
        }

        // It calculates the super digit of a given number
        protected int Calculate_Result(int number)
        {
            int lastDigit;
            int auxNumber = number;
            int sum = 0;

            // The loops is running until the number's digits are over
            while (true)
            {
                lastDigit = auxNumber % 10;
                auxNumber /= 10;

                if (auxNumber == 0 && lastDigit == 0)
                {
                    break;
                }
                sum += lastDigit;
            }

            return sum;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDConnected
{
    internal class clsDataAccess
    {
        public static DataSet selectAll()
        {
            DataSet ds = new DataSet();
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
                using (var conn = new SqlConnection(cs))
                {
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = conn;
                    Cm.CommandType = CommandType.StoredProcedure;
                    Cm.CommandText = "dbo.KlijentSelect";

                    SqlDataAdapter Da = new SqlDataAdapter();
                    Da.SelectCommand = Cm;
                    Da.Fill(ds);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ds;
        }

        public int ClientInsert(string naziv, string kontakt, string grad, string zemlja)
        {
            try
            {
                var cs = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
                using (var conn = new SqlConnection(cs))
                {
                    SqlCommand Cm = new SqlCommand();
                    Cm.Connection = conn;
                    Cm.CommandType = CommandType.StoredProcedure;
                    Cm.CommandText = "dbo.KlijentiInsert";

                    Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                    Cm.Parameters.AddWithValue("@Naziv", naziv);
                    Cm.Parameters.AddWithValue("@Kontakt", kontakt);
                    Cm.Parameters.AddWithValue("@Grad", grad);
                    Cm.Parameters.AddWithValue("@Zemlja", zemlja);

                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        Cm.ExecuteNonQuery();
                        conn.Close();

                        return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return (int)MessageBox.Show("Client added", "Client", MessageBoxButtons.OK, MessageBoxIcon.Information, defaultButton: MessageBoxDefaultButton.Button1);
        }
        public int ClientUpdate(int klijentId, string naziv, string kontakt, string grad, string zemlja)
        {
            var cs = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            using (var  conn = new SqlConnection(cs))
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = conn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.KlijentUpdate";

                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                Cm.Parameters.AddWithValue("@klijentId", klijentId);
                Cm.Parameters.AddWithValue("@naziv", naziv);
                Cm.Parameters.AddWithValue("@kontakt", kontakt);
                Cm.Parameters.AddWithValue("@grad", grad);
                Cm.Parameters.AddWithValue("@zemlja", zemlja);

                try
                {
                    if(conn.State == ConnectionState.Closed) { conn.Open(); }
                    Cm.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);

                }catch(Exception ex)
                {
                    throw new Exception("Error " + ex.Message);
                }
            }
        }
        public int ClientDelete(int klijentId)
        {
            var cs = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            using (var conn = new SqlConnection(cs))
            {
                SqlCommand Cm = new SqlCommand();
                Cm.Connection = conn;
                Cm.CommandType = CommandType.StoredProcedure;
                Cm.CommandText = "dbo.KlijentiDelete";
                Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
                Cm.Parameters.AddWithValue("@klijentId", klijentId);
                try
                {
                    if (conn.State == ConnectionState.Closed) { conn.Open(); }
                    Cm.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToInt32(Cm.Parameters["@RETURN_VALUE"].Value);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error " + ex.Message);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BDAdministrator
{
    static public class ConnectionBD
    {
        static SqlConnection con = new SqlConnection();
        static string connectionString = Properties.Settings.Default.ResourcesMonitorDBConnectionString;

        static void Main()
        {
            // Constructor por defecto.
            //ConnectionBD miConexion = new ConnectionBD();
            //miConexion.bdConnection = new SqlConnection(Properties.Settings.Default.ResourcesMonitorDBConnectionString);
        }

        static public Boolean conectarBD()
        {
            try
            {
                con = new SqlConnection();
                    con.ConnectionString = connectionString;
                    con.Open();
                    //bdConnection.Open();
                
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }

        static public SqlDataReader consultarBD(string miConsulta)
        {
            SqlCommand consultaSQL = new SqlCommand(miConsulta, con);
            SqlDataReader resultadoConsulta = consultaSQL.ExecuteReader();
            try
            {
                resultadoConsulta = consultaSQL.ExecuteReader();
                if (resultadoConsulta.HasRows)
                    return resultadoConsulta;
                else
                    return null;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        static public SqlDataReader obtenerUsuario(string emailUsuario)
        {
            try
            {
                SqlCommand consultaSQL = new SqlCommand("SELECT Nombre, Apellidos, Email, Telefono, Empresa FROM Usuarios WHERE Email='" + emailUsuario + "'", con);
                SqlDataReader resultadoConsulta = consultaSQL.ExecuteReader();

                if (resultadoConsulta.HasRows)
                    return resultadoConsulta;

                else
                    return null;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        static public SqlDataReader listarUsuarios()
        {
            try
            {
                SqlCommand consultaSQL = new SqlCommand("SELECT Nombre, Apellidos, Email, Telefono, Empresa, Privilegios FROM Usuarios", con);
                SqlDataReader resultadoConsulta = consultaSQL.ExecuteReader();

                if (resultadoConsulta.HasRows)
                    return resultadoConsulta;

                else
                    return null;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return null;
            }
        }

        static public Boolean insertarBD()
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
        }
    }
}

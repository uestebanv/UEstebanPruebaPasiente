using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;

namespace BL
{
    public class Pasiente
    {
        public static ML.Result Add(ML.Pasiente pasiente)
        {
            ML.Result result = new ML.Result();
           try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "PasienteAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] row = new SqlParameter[7];


                        row[0] = new SqlParameter("Nombre",SqlDbType.VarChar);
                        row[0].Value = pasiente.Nombre;

                        row[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        row[1].Value = pasiente.ApellidoPaterno;

                        row[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        row[2].Value = pasiente.ApellidoMaterno;
                        
                        //pasiente.TipoSangre = new ML.TipoSangre();
                        row[3] = new SqlParameter("IdTipoSangre", SqlDbType.TinyInt);
                        row[3].Value = pasiente.TipoSangre.IdTipoSangre; 

                        row[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        row[4].Value = pasiente.FechaNacimiento;

                        row[5] = new SqlParameter("Sexo", SqlDbType.Char);
                        row[5].Value = pasiente.Sexo;

                        row[6] = new SqlParameter("Diagnostico", SqlDbType.VarChar);
                        row[6].Value = pasiente.Diagnostico;
                        
                        cmd.Connection.Open();

                        cmd.Parameters.AddRange(row);
                        int ok = cmd.ExecuteNonQuery();
                        if(ok > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }
                    //result.Correct = true;
                }
                //result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public ML.Result Update(ML.Pasiente pasiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "PasienteUpdate";

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.ExecuteNonQuery();
                        SqlParameter[] parameters = new SqlParameter[8];


                        parameters[0] = new SqlParameter("IdPasiente", SqlDbType.Int);
                        parameters[0].Value = pasiente.IdPasiente;

                        parameters[1] = new SqlParameter("Nombre", SqlDbType.Text);
                        parameters[1].Value = pasiente.Nombre;

                        parameters[2] = new SqlParameter("ApellidoPaterno", SqlDbType.Text);
                        parameters[2].Value = pasiente.ApellidoPaterno;

                        parameters[3] = new SqlParameter("ApellidoMaterno", SqlDbType.Text);
                        parameters[3].Value = pasiente.ApellidoMaterno;

                        parameters[4] = new SqlParameter("TipoSangre", SqlDbType.Text);
                        parameters[4].Value = pasiente.TipoSangre;

                        parameters[5] = new SqlParameter("FechaNacimiento", SqlDbType.Text);
                        parameters[5].Value = pasiente.FechaNacimiento;

                        parameters[6] = new SqlParameter("Sexo", SqlDbType.Text);
                        parameters[6].Value = pasiente.Sexo;

                        parameters[7] = new SqlParameter("Diagnostico", SqlDbType.Text);
                        parameters[7].Value = pasiente.Diagnostico;



                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Close();

                            result.Correct = true;
                            result.ErrorMessage = "Se inserto el regsitro";
             


                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct =false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public ML.Result Delete(ML.Pasiente pasiente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "PasienteDelete";

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.ExecuteNonQuery();
                        SqlParameter[] parameters = new SqlParameter[1];


                        parameters[0] = new SqlParameter("IdPasiente", SqlDbType.Int);
                        parameters[0].Value = pasiente.IdPasiente;

                        cmd.Parameters.AddRange(parameters);


                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}

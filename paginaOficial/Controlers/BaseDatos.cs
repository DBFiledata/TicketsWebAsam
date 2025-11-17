using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI;
using System.Configuration;

namespace paginaOficial.Controlers
{
    public class BaseDatos
    {
        MySqlConnection Cn;//variable que almacenara la conexion
        MySqlCommand Cmd;//variable que almacenara los comandos
        MySqlDataAdapter Adap;
        DataSet ds;
        public BaseDatos()//constructor que realiza la connexion 
        {
            Cn = new MySqlConnection();//enstanciamos la variable cn
            Cn.ConnectionString = ConfigurationManager.ConnectionStrings["atencion_soportetecnicoConnectionString"].ConnectionString;
            Cmd = new MySqlCommand();
            Cmd.Connection = Cn;
        }


        public bool RegistrarUsuario(string idsusario, string passw, string nombre, string apellido, string email, int telefono, int codigo)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "crearUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", idsusario));
                Cmd.Parameters.Add(new MySqlParameter("@passw", passw));
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@email", email));
                Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", codigo));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }
        }

        public bool RegistrarSolicitante(string idsusario, string nombre, string apellido, string departamento, string email, string telefono)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "crearSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", idsusario));
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@departamento", departamento));
                Cmd.Parameters.Add(new MySqlParameter("@email", email));
                Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool ActualizarUsuario(string idsusario, string idnuevo, string nombre, string apellido, string email, int telefono, int codigo)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", idsusario)); 
                Cmd.Parameters.Add(new MySqlParameter("@idNuevo", idnuevo));
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@email", email));
                Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", codigo));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();


                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }

        public bool ActualizarSolicitante(string idususario, string idnueva, string nombre, string apellido, string departamento, string email, string telefono)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", idususario));
                Cmd.Parameters.Add(new MySqlParameter("@idNuevo", idnueva));
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@departamento", departamento));
                Cmd.Parameters.Add(new MySqlParameter("@email", email));
                Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;

            }

        }

        //agregar eliminar usuarios y solicitantes 


        public bool ActualizarTicket(string idTicket, string descripcion, string problema,  int estus, string tecnico)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarTicket";
                Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
                Cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
                Cmd.Parameters.Add(new MySqlParameter("@problema", problema));
                Cmd.Parameters.Add(new MySqlParameter("@tecnico", tecnico));
                Cmd.Parameters.Add(new MySqlParameter("@programacion", null));
                Cmd.Parameters.Add(new MySqlParameter("@estus", estus));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }
        public bool ActualizarTicketProgramado(string idTicket, string descripcion, string problema, DateTime fecha)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarTicket";
                Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
                Cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
                Cmd.Parameters.Add(new MySqlParameter("@problema", problema));
                Cmd.Parameters.Add(new MySqlParameter("@tecnico", null));
                Cmd.Parameters.Add(new MySqlParameter("@programacion", fecha));
                Cmd.Parameters.Add(new MySqlParameter("@estus", 4));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }
        public bool ActualizarTickeCreado(string idTicket, string descripcion, string problema, string tecnico)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarTicket";
                Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
                Cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
                Cmd.Parameters.Add(new MySqlParameter("@problema", problema));
                Cmd.Parameters.Add(new MySqlParameter("@tecnico", tecnico));
                Cmd.Parameters.Add(new MySqlParameter("@programacion", null));
                Cmd.Parameters.Add(new MySqlParameter("@estus", 1));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }


        public bool EliminarSolicitante(string idususario)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "eliminarSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", idususario));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }
        public bool EliminarUsuario(string idususario)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "eliminarUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", idususario));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }



        public bool ActualizarPassw(string idsusario, string passnueva)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "actualizarPassword";
                Cmd.Parameters.Add(new MySqlParameter("@id", idsusario));
                Cmd.Parameters.Add(new MySqlParameter("@passw", passnueva));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }


        public bool login(string id, string pass)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "loginPagina";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Parameters.Add(new MySqlParameter("@passw", pass));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
                string resultado = Convert.ToString(ds.Tables[0].Rows[0]["idusuarios"]);//se asingna el resultado del dataset 
                if (resultado != null)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }

        }





        public string[] infoCuenta(string id)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                ds = new DataSet();//instancia dataset
                
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
                string[] resultado = new string[7];
                resultado[0] = Convert.ToString(ds.Tables[0].Rows[0]["idusuarios"]);//se asingna el resultado del dataset 
                resultado[1] = Convert.ToString(ds.Tables[0].Rows[0]["nombres"]);
                resultado[2] = Convert.ToString(ds.Tables[0].Rows[0]["apellidos"]);
                resultado[3] = Convert.ToString(ds.Tables[0].Rows[0]["correos"]);
                resultado[4] = Convert.ToString(ds.Tables[0].Rows[0]["telefonos"]);
                resultado[5] = Convert.ToString(ds.Tables[0].Rows[0]["tipos"]);
                resultado[6] = Convert.ToString(ds.Tables[0].Rows[0]["tiposDeUsuarios_codigos"]);


                //int d = Cmd.ExecuteNonQuery();

                if (resultado !=null)
                {
                    return resultado;
                }
                else
                {
                    resultado = null;
                }
                Cmd.Connection.Close();
                return resultado;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return null;

            }

        }

        


        public string[] getDatosSession(string id, string passw)
        {
            try
            {
                string[] ejecucion;
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "loginPagina";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Parameters.Add(new MySqlParameter("@passw", passw));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
                string idc = Convert.ToString(ds.Tables[0].Rows[0]["idusuarios"]);//se asingna el resultado del dataset
                string[] resultado = new string[2];
                resultado[0]= Convert.ToString(ds.Tables[0].Rows[0]["nombres"]);
                resultado[1] = Convert.ToString(ds.Tables[0].Rows[0]["tiposDeUsuarios_codigos"]);
                if (resultado[0] != null | resultado[1] != null)
                {
                    ejecucion = resultado;
                }
                else
                {
                    ejecucion = null;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return null;

            }

        }


        public DataSet ListaTotal()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "listaUsuariosTotal";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet ListaTicketUsuario(string idUser)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarTicketUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", idUser));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }



        public DataSet ListaTicketSolicitante(string idSolicitante)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarTicketSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", idSolicitante));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public DataSet ListaTicketTecnico(string idSolicitante)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarTicketTecnico";
                Cmd.Parameters.Add(new MySqlParameter("@id", idSolicitante));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public DataSet liberarTicketLista(string id)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "liberarTicketLista";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }
        public DataSet ListaTicketEstado(string idEstado)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarTicketEstados";
                Cmd.Parameters.Add(new MySqlParameter("@id", idEstado));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }
        
            public DataSet ListaTicketSinCierre()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "listaTicketsSinCierre";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

       





        //vericar procedure 
        public DataSet filtroUsuario(string nombre, string apellido, int tipo)
        {
            try
            {

                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }
        



        public DataSet filtroTicketUsuario(string idUsuario, int idEstado)
        {
            try
            {

                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "FiltroTicketUsuario";
                Cmd.Parameters.Add(new MySqlParameter("@id", idUsuario));
                Cmd.Parameters.Add(new MySqlParameter("@estado", idEstado));
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            
            return ds;
        }

        public DataSet filtroTicketTecnico(string idUsuario, int idEstado)
        {
            try
            {

                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "FiltroTicketTecnico";
                Cmd.Parameters.Add(new MySqlParameter("@id", idUsuario));
                Cmd.Parameters.Add(new MySqlParameter("@estado", idEstado));
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet filtroTicketSolicitante(string idSolicitante, int idEstado)
        {
            try
            {

                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroTicketSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", idSolicitante));
                Cmd.Parameters.Add(new MySqlParameter("@estado", idEstado));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }




        public DataSet generarTicket(string desc, string problem, string numsol, string user, string tipo)
        {
            try
            {
                DataSet ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "crearTicketss";
                Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
                Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
                Cmd.Parameters.Add(new MySqlParameter("@solicitente", numsol));
                Cmd.Parameters.Add(new MySqlParameter("@usuario", user)); 
                Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
                ds = new DataSet();//instancia dataset


                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
                

                //MAX(idtickets)
                if (ds.Tables.Count > 0)
                {
                    ejecucion = ds;
                }
                else
                {
                    ejecucion = null;
                }
                
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return null;

            }

        }


        public DataSet generarTicketProgramado(string desc, string problem, string numsol, string user, DateTime fecha)
        {
            try
            {
                DataSet ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "crearTicketsProgramados";
                Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
                Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
                Cmd.Parameters.Add(new MySqlParameter("@solicitente", numsol));
                Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
                Cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
                ds = new DataSet();//instancia dataset


                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);


                //MAX(idtickets)
                if (ds.Tables.Count > 0)
                {
                    ejecucion = ds;
                }
                else
                {
                    ejecucion = null;
                }

                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return null;

            }

        }
        public DataSet liberarTicketProgramado(int id, int tipo)
        {
            try
            {
                DataSet ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "liberarTicketProgramado";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
                ds = new DataSet();//instancia dataset
                ds = new DataSet();//instancia dataset


                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);


                if (ds.Tables.Count > 0)
                {
                    ejecucion = ds;
                }
                else
                {
                    ejecucion = null;
                }

                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return null;

            }
        }



        public bool cerrarTicket(int id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "cerrarTickets";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                ds = new DataSet();//instancia dataset
                Cmd.Connection.Open();
                int resultado = Cmd.ExecuteNonQuery();
                
                if (resultado > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;
                return false;

            }
        }

       

        public bool EliminarTicket(int id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "eliminarTicket";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }

        }







        public string[] infoSolicitante(string id)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarSolicitante";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
                string[] resultado = new string[6];
                resultado[0] = Convert.ToString(ds.Tables[0].Rows[0]["idsolicitantes"]);//se asingna el resultado del dataset 
                resultado[1] = Convert.ToString(ds.Tables[0].Rows[0]["nombres"]);
                resultado[2] = Convert.ToString(ds.Tables[0].Rows[0]["apellidos"]);
                resultado[3] = Convert.ToString(ds.Tables[0].Rows[0]["departamentos"]);
                resultado[4] = Convert.ToString(ds.Tables[0].Rows[0]["correos"]);
                resultado[5] = Convert.ToString(ds.Tables[0].Rows[0]["telefonos"]);
                

                //int d = Cmd.ExecuteNonQuery();

                if (resultado != null)
                {
                    return resultado;
                }
                else
                {
                    resultado = null;
                }
                Cmd.Connection.Close();
                return resultado;
            }
            catch (Exception e)
            {
                return null;

            }

        }

        public string[] buscarTicketNum(string id)
        {
            try
            {
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "buscarTicket";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                ds = new DataSet();//instancia dataset
                Adap = new MySqlDataAdapter(Cmd);//adapter se pasa el cmd
                Adap.Fill(ds);//se asigna el dataset al adapter
                string[] resultado = new string[19];
                resultado[0] = Convert.ToString(ds.Tables[2].Rows[0]["idtickets"]); 
                resultado[1] = Convert.ToString(ds.Tables[2].Rows[0]["solicitantes_idsolicitantes"]);
                resultado[2] = Convert.ToString(ds.Tables[2].Rows[0]["nombreSolicitante"]);
                resultado[3] = Convert.ToString(ds.Tables[2].Rows[0]["apellidoSolicitante"]);
                resultado[4] = Convert.ToString(ds.Tables[2].Rows[0]["usuarios_idusuarios"]);
                resultado[5] = Convert.ToString(ds.Tables[2].Rows[0]["nombreUsuario"]);
                resultado[6] = Convert.ToString(ds.Tables[2].Rows[0]["apellidoUsuario"]);
                resultado[7] = Convert.ToString(ds.Tables[2].Rows[0]["@tecnico"]);
                resultado[8] = Convert.ToString(ds.Tables[2].Rows[0]["nombreTecnico"]);
                resultado[9] = Convert.ToString(ds.Tables[2].Rows[0]["apellidoTecnico"]);
                resultado[10] = Convert.ToString(ds.Tables[2].Rows[0]["problemas"]);
                resultado[11] = Convert.ToString(ds.Tables[2].Rows[0]["descripciones"]);
                resultado[12] = Convert.ToString(ds.Tables[2].Rows[0]["tipos"]);
                resultado[13] = Convert.ToString(ds.Tables[2].Rows[0]["fechascreacion"]);
                resultado[14] = Convert.ToString(ds.Tables[2].Rows[0]["fechasatencion"]);
                resultado[15] = Convert.ToString(ds.Tables[2].Rows[0]["fechasfinalizacion"]);
                resultado[16] = Convert.ToString(ds.Tables[2].Rows[0]["fechasprogramacion"]);
                resultado[17] = Convert.ToString(ds.Tables[2].Rows[0]["fechaCierre"]);
                resultado[18] = Convert.ToString(ds.Tables[2].Rows[0]["estados_idestados"]);

                if (resultado != null)
                {
                    return resultado;
                }
                else
                {
                    resultado = null;
                }
                Cmd.Connection.Close();
                return resultado;
            }
            catch (Exception e)
            {
                
                return null;

            }

        }

        public DataSet ListaSinVacaciones()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "muestraSinVacaciones";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet ListaEnVacaciones()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "muestraEnVacaciones";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public bool darVacaciones(string id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "darVacaciones";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }

        }


        public DataSet filtroSinVacaciones(string nombre, string apellido, int tipo)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroSinVacaciones";
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public DataSet filtroEnVacaciones(string nombre, string apellido, int tipo)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroEnVacaciones";
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public bool finalizarVacaciones(string id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "finalizarVacaciones";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        

        public DataSet ListaSinPermiso()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "muestraSinPermiso";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet filtroSinPermiso(int tipo)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroSinPermiso";
                Cmd.Parameters.Add(new MySqlParameter("@codigo",  tipo));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet ListaEnPermiso()
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "muestraEnPermiso";
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public bool darPermisos(string id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "darPermiso";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public DataSet filtroEnPermiso(string nombre, string apellido, int tipo)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroEnPermiso";
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }

        public DataSet filtroSinPermiso(string nombre, string apellido, int tipo)
        {
            try
            {
                ds = new DataSet();
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "filtroSinPermiso";
                Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
                Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
                Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
                Adap = new MySqlDataAdapter(Cmd);
                Adap.Fill(ds);
            }
            catch (Exception e)
            {
                //OError.Write_error(e.Message + "-" + e.StackTrace);
                //OError.Error_msg = error_con;

            }
            return ds;
        }


        public bool finalizarPermisos(string id)
        {
            try
            {
                bool ejecucion;
                Cmd.Parameters.Clear();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "finalizarPermiso";
                Cmd.Parameters.Add(new MySqlParameter("@id", id));
                Cmd.Connection.Open();
                int d = Cmd.ExecuteNonQuery();

                if (d > 0)
                {
                    ejecucion = true;
                }
                else
                {
                    ejecucion = false;
                }
                Cmd.Connection.Close();
                return ejecucion;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        
        public void chart()
        {

        }


    }
}

using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace paginaOficial.Controlers
{
    public class BaseDatos
    {
    	private MySqlConnection Cn;

    	private MySqlCommand Cmd;

    	private MySqlDataAdapter Adap;

    	private DataSet ds;

    	public BaseDatos()
    	{
    		Cn = new MySqlConnection();
    		Cn.ConnectionString = ConfigurationManager.ConnectionStrings["atencion_soportetecnicoConnectionString"].ConnectionString;
    		Cmd = new MySqlCommand();
    		Cmd.Connection = Cn;
    	}

    	public bool RegistrarUsuario(string idsusario, string passw, string nombre, string apellido, string email, string telefono, int codigo)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool RegistrarSolicitante(string idsusario, string nombre, string apellido, string departamento, string email, string telefono)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarUsuario(string idsusario, string idnuevo, string nombre, string apellido, string email, string telefono, int codigo)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarSolicitante(string idususario, string idnueva, string nombre, string apellido, string departamento, string email, string telefono)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarTicket(string idTicket, string descripcion, string problema, int estus, string tecnico)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarTicketProgramado(string idTicket, string descripcion, string problema, DateTime fecha)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarTickeCreado(string idTicket, string descripcion, string problema, string tecnico)
    	{
    		try
    		{
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
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool insertCedidos(string idTicket, string Motivo, string tecnicoAnterior)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "insertCedidos";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
    			Cmd.Parameters.Add(new MySqlParameter("@Motivo", Motivo));
    			Cmd.Parameters.Add(new MySqlParameter("@tecnicoAnterior", tecnicoAnterior));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarTicActualizarATrabajoProgramadokeCreado(string idTicket, string descripcion, string problema)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "ActualizarATrabajoProgramado";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problema));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarAInstalacion(string idTicket, string descripcion, string problema)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "ActualizarAInstalacion";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", descripcion));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problema));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool EliminarSolicitante(string idususario)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "eliminarSolicitante";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idususario));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool eliminarTecnicosTrabajosProgramados(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "eliminarTecnicosTrabajosProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool EliminarUsuario(string idususario)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "eliminarUsuario";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idususario));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ActualizarPassw(string idsusario, string passnueva)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "actualizarPassword";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idsusario));
    			Cmd.Parameters.Add(new MySqlParameter("@passw", passnueva));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool login(string id, string pass)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.CommandText = "loginPagina";
			Cmd.Parameters.Add(new MySqlParameter("id", id));
			Cmd.Parameters.Add(new MySqlParameter("passw", pass));
			ds = new DataSet();
			if (Cmd.Connection.State != ConnectionState.Open)
			    Cmd.Connection.Open();
			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    			{
    			    string resultado = Convert.ToString(ds.Tables[0].Rows[0]["idusuarios"]);
    			    return !string.IsNullOrEmpty(resultado);
    			}
    			return false;
    		}
    		catch (Exception)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
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
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[7]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["idusuarios"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["nombres"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["apellidos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["correos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["telefonos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tipos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tiposDeUsuarios_codigos"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string[] getDatosSession(string id, string passw)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "loginPagina";
    			Cmd.Parameters.Add(new MySqlParameter("id", id));
    			Cmd.Parameters.Add(new MySqlParameter("passw", passw));
    			ds = new DataSet();
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    			if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    			{
    			    string[] resultado = new string[3]
    			    {
    				    Convert.ToString(ds.Tables[0].Rows[0]["nombres"]),
    				    Convert.ToString(ds.Tables[0].Rows[0]["tiposDeUsuarios_codigos"]),
    				    Convert.ToString(ds.Tables[0].Rows[0]["idRoles"])
    			    };
    			    return resultado;
    			}
    			return null;
    		}
    		catch (Exception)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
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
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listatickets()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listatickets";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTrabajosProgramados()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTrabajosProgramados";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTicketsActivos()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketsActivos";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTicketsTecnico(string id)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketTecnico";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTicketTecnico2(string id)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketTecnico2";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroTicketTecnico2(int estado, string nombre, string apellido, string desde, string hasta)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroTicketTecnico2";
    			Cmd.Parameters.Add(new MySqlParameter("@estado", estado));
    			Cmd.Parameters.Add(new MySqlParameter("@nombreSolicitante", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellidoSolicitante", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@desde", desde));
    			Cmd.Parameters.Add(new MySqlParameter("@hasta", hasta));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool asignarStatusTicket(int idTicket, int estatus, string coment)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarStatusTicket";
    			Cmd.Parameters.Add(new MySqlParameter("@id", idTicket));
    			Cmd.Parameters.Add(new MySqlParameter("@estus", estatus));
    			Cmd.Parameters.Add(new MySqlParameter("@coment", coment));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public DataSet listaTicketsActivos1()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketsActivos1";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTicketsRevision()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketsRevision";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTicketSegumiento()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTicketSegumiento";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet liberarTicketLista()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "liberarTicketLista";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtrolistaTicket(int estado, int area, string desde, string hasta)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtrolistaTicket";
    			Cmd.Parameters.Add(new MySqlParameter("@estado", estado));
    			Cmd.Parameters.Add(new MySqlParameter("@area", area));
    			Cmd.Parameters.Add(new MySqlParameter("@desde", desde));
    			Cmd.Parameters.Add(new MySqlParameter("@hasta", hasta));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroTicketRevision(int area)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtrolistaTicket";
    			Cmd.Parameters.Add(new MySqlParameter("@estado", 7)); // Estado 7 = Revisión
    			Cmd.Parameters.Add(new MySqlParameter("@area", area));
    			Cmd.Parameters.Add(new MySqlParameter("@desde", "0000-00-00")); // Sin filtro de fecha
    			Cmd.Parameters.Add(new MySqlParameter("@hasta", "0000-00-00")); // Sin filtro de fecha
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception ex)
    		{
    			// Log del error para debugging
    			System.Diagnostics.Debug.WriteLine("Error en filtroTicketRevision: " + ex.Message);
    		}
    		return ds;
    	}

    	public DataSet filtroTicketSegumiento(int area)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroTicketSegumiento";
    			Cmd.Parameters.Add(new MySqlParameter("@area", area));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

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
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public int ultimoTicket()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "ultimoTicket";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count > 0) ? Convert.ToInt32(ds.Tables[0].Rows[0][0]) : 0;
    		}
    		catch (Exception)
    		{
    			return 0;
    		}
    	}

    	public Tickets ultimoTicketDeTecnico(string userId)
    	{
    		Cmd.Parameters.Clear();
    		Cmd.CommandType = CommandType.StoredProcedure;
    		Cmd.CommandText = "ultimoTicketDeUsuario";
    		Cmd.Connection.Open();
    		Cmd.Parameters.Add(new MySqlParameter("@uid", userId));
    		ds = new DataSet();
    		Adap = new MySqlDataAdapter(Cmd);
    		Adap.Fill(ds);
    		string datos = ds.Tables[0].Rows[0]["idusuarios"]?.ToString() ?? "";
    		Cmd.Connection.Close();
    		if (!string.IsNullOrEmpty(datos))
    		{
    			return new Tickets
    			{
    				idusuarios = (ds.Tables[0].Rows[0]["idusuarios"]?.ToString() ?? ""),
    				email = (ds.Tables[0].Rows[0]["email"]?.ToString() ?? ""),
    				usuario = (ds.Tables[0].Rows[0]["usuario"]?.ToString() ?? ""),
    				idtickets = (ds.Tables[0].Rows[0]["idtickets"]?.ToString() ?? ""),
    				descripciones = (ds.Tables[0].Rows[0]["descripciones"]?.ToString() ?? ""),
    				problemas = (ds.Tables[0].Rows[0]["problemas"]?.ToString() ?? ""),
    				fechascreacion = (ds.Tables[0].Rows[0]["fechascreacion"]?.ToString() ?? ""),
    				solicitante = (ds.Tables[0].Rows[0]["solicitante"]?.ToString() ?? ""),
    				correos = (ds.Tables[0].Rows[0]["correos"]?.ToString() ?? ""),
    				telefonos = (ds.Tables[0].Rows[0]["telefonos"]?.ToString() ?? "")
    			};
    		}
    		return null;
    	}

    	public bool ChangeStatusToAttending(string ticket)
    	{
    		string query = "UPDATE tickets SET estados_idestados = 2, fechasatencion = NOW() where idtickets =" + ticket;
    		try
    		{
    			MySqlCommand cmd = new MySqlCommand();
    			cmd.CommandText = query;
    			Cmd.Connection.Open();
    			cmd.ExecuteNonQuery();
    			Cmd.Connection.Close();
    			return true;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ChangeStatusToFinal(string ticket)
    	{
    		string query = "UPDATE tickets SET estados_idestados = 3, fechasfinalizacion = NOW() where idtickets =" + ticket;
    		try
    		{
    			MySqlCommand cmd = new MySqlCommand();
    			cmd.CommandText = query;
    			Cmd.Connection.Open();
    			cmd.ExecuteNonQuery();
    			Cmd.Connection.Close();
    			return true;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool ChangeStatusToEscalate(string ticket)
    	{
    		string query = "UPDATE tickets SET estados_idestados = 6 where idtickets =" + ticket;
    		try
    		{
    			MySqlCommand cmd = new MySqlCommand();
    			cmd.CommandText = query;
    			Cmd.Connection.Open();
    			cmd.ExecuteNonQuery();
    			Cmd.Connection.Close();
    			return true;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public DataSet generarTicket(string desc, string problem, string numsol, string user, string tipo, string nombre, string apellido, string departamento, string email, string telefono)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "crearTicketss";
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
    			Cmd.Parameters.Add(new MySqlParameter("@solicitente", numsol));
    			Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
    			Cmd.Parameters.Add(new MySqlParameter("@departamento", departamento));
    			Cmd.Parameters.Add(new MySqlParameter("@email", email));
    			Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet crearTicketsArea(string desc, string problem, string numsol, string user, string tipo, string nombre, string apellido, string departamento, string email, string telefono)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "crearTicketsArea";
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
    			Cmd.Parameters.Add(new MySqlParameter("@solicitente", numsol));
    			Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
    			Cmd.Parameters.Add(new MySqlParameter("@departamento", departamento));
    			Cmd.Parameters.Add(new MySqlParameter("@email", email));
    			Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet generarTicketProgramado(string desc, string problem, string numsol, string user, DateTime fecha, string nombre, string apellido, string departamento, string email, string telefono)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "crearTicketsProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
    			Cmd.Parameters.Add(new MySqlParameter("@fecha", fecha));
    			Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
    			Cmd.Parameters.Add(new MySqlParameter("@solicitente", numsol));
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@departamento", departamento));
    			Cmd.Parameters.Add(new MySqlParameter("@email", email));
    			Cmd.Parameters.Add(new MySqlParameter("@telefono", telefono));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet generarTicketTrabajoProgramados(string desc, string problem, string user)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "crearTicketsTrabajoProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
    			Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet generarTicketsInstalaciones(string desc, string problem, string user)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "crearTicketsInstalaciones";
    			Cmd.Parameters.Add(new MySqlParameter("@descripcion", desc));
    			Cmd.Parameters.Add(new MySqlParameter("@problema", problem));
    			Cmd.Parameters.Add(new MySqlParameter("@usuario", user));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public bool asignarTecnicosTrabajoProgamado(int id, string tecnico)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarTecnicosTrabajoProgamado";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@tecnico", tecnico));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool asignarTecnicosInstalaciones(int id, string tecnico)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarTecnicosInstalaciones";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@tecnico", tecnico));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public DataSet liberarTicketProgramado(int id, int tipo)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "liberarTicketProgramado";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet tipoUsuarios()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tipoUsuarios";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet tipoTecnico()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tipoTecnico";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet dListTecnico(int area)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "dListTecnico";
    			Cmd.Parameters.Add(new MySqlParameter("@area", area));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public bool cerrarTicket(int id, string coment)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cerrarTickets";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@coment", coment));
    			ds = new DataSet();
    			Cmd.Connection.Open();
    			int resultado = Cmd.ExecuteNonQuery();
    			bool ejecucion = resultado > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool asignarRevisionTickets(int id, string motivo)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarRevisionTickets";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@motivo", motivo));
    			ds = new DataSet();
    			Cmd.Connection.Open();
    			int resultado = Cmd.ExecuteNonQuery();
    			bool ejecucion = resultado > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool asignarSegumientoTickets(int id, string motivo)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarSegumientoTickets";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@motivo", motivo));
    			ds = new DataSet();
    			Cmd.Connection.Open();
    			int resultado = Cmd.ExecuteNonQuery();
    			bool ejecucion = resultado > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public DataSet reasignarTicketSeguimiento(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "reasignarTicketSeguimiento";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet reasignarTicket(int id, string motivo, string tecnico)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "reasignarTicket";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Parameters.Add(new MySqlParameter("@Motivo", motivo));
    			Cmd.Parameters.Add(new MySqlParameter("@tecnicos", tecnico));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return (ds.Tables.Count <= 0) ? null : ds;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet tecnicosDispinoblesArea(int tipo)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tecnicosDispinoblesArea";
    			Cmd.Parameters.Add(new MySqlParameter("@tipo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	/// <summary>
    	/// Reasigna un ticket a otra área y asigna automáticamente un técnico de esa área
    	/// </summary>
    	/// <param name="idTicket">ID del ticket a reasignar</param>
    	/// <param name="nuevaArea">Código del área destino</param>
    	/// <param name="motivo">Motivo de la reasignación</param>
    	/// <param name="usuarioActual">Usuario que realiza la reasignación</param>
    	/// <returns>DataSet con resultado: Exito, Mensaje, NuevoTecnico, NombreTecnico</returns>
    	public DataSet reasignarTicketArea(int idTicket, int nuevaArea, string motivo, string usuarioActual)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "reasignarTicketArea";
    			Cmd.Parameters.Add(new MySqlParameter("@p_idTicket", idTicket));
    			Cmd.Parameters.Add(new MySqlParameter("@p_nuevaArea", nuevaArea));
    			Cmd.Parameters.Add(new MySqlParameter("@p_motivo", motivo));
    			Cmd.Parameters.Add(new MySqlParameter("@p_usuarioActual", usuarioActual));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return ds;
    		}
    		catch (Exception ex)
    		{
    			System.Diagnostics.Debug.WriteLine("Error en reasignarTicketArea: " + ex.Message);
    			return null;
    		}
    	}

    	/// <summary>
    	/// Obtiene las áreas disponibles para reasignación de tickets
    	/// </summary>
    	/// <returns>DataSet con codigos y tipos de área</returns>
    	public DataSet obtenerAreasReasignacion()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "obtenerAreasReasignacion";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			return ds;
    		}
    		catch (Exception ex)
    		{
    			System.Diagnostics.Debug.WriteLine("Error en obtenerAreasReasignacion: " + ex.Message);
    			return null;
    		}
    	}

    	public bool EliminarTicket(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "eliminarTicket";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public string[] infoTecnico(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "infoTecnico";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[8]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["id"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["nombre"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tokens"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["pass"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["correos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["telefonos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tipos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["estados"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
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
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[6]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["idsolicitantes"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["nombres"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["apellidos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["departamentos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["correos"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["telefonos"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string[] infoSolicitantePadron(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "buscarSolicitantePadron";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[3]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["n1"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["a1"]),
    				null
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string[] infoTicketMail(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "infoTicketMail";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[8]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["Numero"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["solicitante"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["correo"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tecnico"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["agente"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["area"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["motivo"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
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
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[20]
    			{
    				Convert.ToString(ds.Tables[2].Rows[0]["idtickets"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["solicitantes_idsolicitantes"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["nombreSolicitante"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["apellidoSolicitante"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["usuarios_idusuarios"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["nombreUsuario"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["apellidoUsuario"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["@tecnico"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["nombreTecnico"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["apellidoTecnico"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["problemas"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["descripciones"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["tipos"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["fechascreacion"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["fechasatencion"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["fechasfinalizacion"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["fechasprogramacion"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["fechaCierre"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["estados_idestados"]),
    				Convert.ToString(ds.Tables[2].Rows[0]["@area"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet muestraAsignarEstatusTecnico()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "muestraAsignarEstatusTecnico";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet muestraEditarEstatusTecnico()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "muestraEditarEstatusTecnico";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet listaTecnicosTrabajosProgramados(int id)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "listaTecnicosTrabajosProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet tecnicosDisponiblesTrabajosProgramados()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tecnicosDisponiblesTrabajosProgramados";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet tecnicosDisponiblesTrabajosProgramadosPorArea(int rolUsuario)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tecnicosDisponiblesTrabajosProgramadosPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolUsuario", rolUsuario));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet TecnicosAsignadosTrabajosProgramados(int id)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "TecnicosAsignadosTrabajosProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet TecnicosReasignacionTrabajosProgramados(int id)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "TecnicosReasignacionTrabajosProgramados";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool AsignarArea(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "AsignarArea";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool darVacaciones(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "darVacaciones";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool asignarConfirmacionTiempoTickets(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "asignarConfirmacionTiempoTickets";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public string verificarConfirmacionTiempoTickets(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "verificarConfirmacionTiempoTickets";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string resultado = Convert.ToString(ds.Tables[0].Rows[0]["confirmacionTiempo"]);
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string[] infoTicketMailConnfirmacionTiempo(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "infoTicketMailConnfirmacionTiempo";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string[] resultado = new string[11]
    			{
    				Convert.ToString(ds.Tables[0].Rows[0]["Numero"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["solicitante"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["correo"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["tecnico"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["agente"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["area"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["descripcion"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["motivo"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["hora"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["mailDirector"]),
    				Convert.ToString(ds.Tables[0].Rows[0]["mailJefe"])
    			};
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public DataSet filtroAsignarEstatusTecnico(string nombre, string apellido, int tipo)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroAsignarEstatusTecnico";
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroAsignarEstatusTecnicoPorArea(string nombre, string apellido, int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroAsignarEstatusTecnicoPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroEditarEstatusTecnico(string nombre, string apellido, int tipo)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroEditarEstatusTecnico";
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroSinReserva(string nombre, string apellido, int tipo)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroSinReserva";
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet filtroEnReserva(string nombre, string apellido, int tipo)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "filtroEnReserva";
    			Cmd.Parameters.Add(new MySqlParameter("@nombre", nombre));
    			Cmd.Parameters.Add(new MySqlParameter("@apellido", apellido));
    			Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
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
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool finalizarVacaciones(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "finalizarVacaciones";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
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
    		catch (Exception)
    		{
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
    			Cmd.Parameters.Add(new MySqlParameter("@codigo", tipo));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
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
    			Cmd.CommandText = "muestraEnReserva";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool darPermisos(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "darPermiso";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
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
    		catch (Exception)
    		{
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
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool finalizarPermisos(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "finalizarPermiso";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool finalizarTrabajoProgamado(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "finalizarTrabajoProgamado";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public bool eliminarTrabajoProgamado(int id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "eliminarTrabajoProgamado";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

    	public DataSet ListaSinReserva()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "muestraSinRecerva";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet ListaEnReserva()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "muestraEnReserva";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public bool darReserva(string id)
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "darReserva";
    			Cmd.Parameters.Add(new MySqlParameter("@id", id));
    			Cmd.Connection.Open();
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception)
    		{
    			return false;
    		}
    	}

public bool actualizarDisponibilidad(string id, int idDisponibilidad, DateTime? fechaRetorno = null)
	{
		try
		{
			Cmd.Parameters.Clear();
			Cmd.CommandType = CommandType.Text;
			
			string sql = "UPDATE usuarios SET disponibilidad_codigos = @idDisponibilidad, fecha_retorno_disponibilidad = @fechaRetorno WHERE idusuarios = @id";
			
			Cmd.CommandText = sql;
			Cmd.Parameters.Add(new MySqlParameter("@id", id));
			Cmd.Parameters.Add(new MySqlParameter("@idDisponibilidad", idDisponibilidad));
			Cmd.Parameters.Add(new MySqlParameter("@fechaRetorno", (object)fechaRetorno ?? DBNull.Value));
			
    			if (Cmd.Connection.State != ConnectionState.Open)
    			{
    				Cmd.Connection.Open();
    			}
    			int d = Cmd.ExecuteNonQuery();
    			bool ejecucion = d > 0;
    			Cmd.Connection.Close();
    			return ejecucion;
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			{
    				Cmd.Connection.Close();
    			}
    			return false;
    		}
    	}

	public int procesarRetornoAutomaticoDisponibilidad()
	{
		try
		{
			Cmd.Parameters.Clear();
			Cmd.CommandType = CommandType.StoredProcedure;
			Cmd.CommandText = "procesoRetornoAutomaticoDisponibilidad";
			if (Cmd.Connection.State != ConnectionState.Open)
			{
				Cmd.Connection.Open();
			}
			object result = Cmd.ExecuteScalar();
			Cmd.Connection.Close();
			return result != null ? Convert.ToInt32(result) : 0;
		}
		catch (Exception)
		{
			if (Cmd.Connection.State == ConnectionState.Open)
			{
				Cmd.Connection.Close();
			}
			return 0;
		}
	}

	public DataSet EstadisticaAreaTickets()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticaAreaTicketsMensual";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticaEstadosTicketsMensual()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticaEstadosTicketsMensual";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticaEstadosTicketsDiario()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticaEstadosTicketsDiario";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticaAreaTicketsDiario()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticaAreaTicketsDiario";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticaAreaTicketsMeses()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticaAreaTicketsMeses";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticasUsuarioFiltro(string tecnicos, DateTime? desde, DateTime? hasta)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticasUsuarioFiltro";
    			Cmd.Parameters.Add(new MySqlParameter("@tecnicos", tecnicos));
    			Cmd.Parameters.Add(new MySqlParameter("@desde", desde));
    			Cmd.Parameters.Add(new MySqlParameter("@hasta", hasta));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet EstadisticasAreasFiltro(int? area, DateTime? desde, DateTime? hasta)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "EstadisticasAreasFiltro";
    			Cmd.Parameters.Add(new MySqlParameter("@area", area));
    			Cmd.Parameters.Add(new MySqlParameter("@desde", desde));
    			Cmd.Parameters.Add(new MySqlParameter("@hasta", hasta));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadAtencion()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadAtencion";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet tiempoAtencion()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tiempoAtencion";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadCedidos()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadCedidos";
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			// Log error for debugging
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadCedidos: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadPermisos()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadPermisos";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadReservas()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadReservas";
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadSerguimientos()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadSerguimientos";
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadSerguimientos: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadTrabajoProgramado()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadTrabajoProgramado";
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadTrabajoProgramado: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadRevisiones()
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadRevisiones";
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadRevisiones: {ex.Message}");
    		}
    		return ds;
    	}

    	// ========================================================================
    	// Métodos de Productividad Filtrados por Área del Jefe
    	// ========================================================================

    	public DataSet cantidadAtencionPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadAtencionPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet tiempoAtencionPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "tiempoAtencionPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadPermisosPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadPermisosPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadCedidosPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadCedidosPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadCedidosPorArea: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadReservasPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadReservasPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    		}
    		catch (Exception)
    		{
    		}
    		return ds;
    	}

    	public DataSet cantidadRevisionesPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadRevisionesPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadRevisionesPorArea: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadSeguimientosPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadSeguimientosPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadSeguimientosPorArea: {ex.Message}");
    		}
    		return ds;
    	}

    	public DataSet cantidadTrabajoProgramadoPorArea(int rolJefe)
    	{
    		try
    		{
    			ds = new DataSet();
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "cantidadTrabajoProgramadoPorArea";
    			Cmd.Parameters.Add(new MySqlParameter("@rolJefe", rolJefe));
    			if (Cmd.Connection.State != ConnectionState.Open)
    			    Cmd.Connection.Open();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			Cmd.Connection.Close();
    		}
    		catch (Exception ex)
    		{
    			if (Cmd.Connection.State == ConnectionState.Open)
    			    Cmd.Connection.Close();
    			System.Diagnostics.Debug.WriteLine($"Error en cantidadTrabajoProgramadoPorArea: {ex.Message}");
    		}
    		return ds;
    	}

    	public string totalTicketsMes()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "totalTicketsMes";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string resultado = Convert.ToString(ds.Tables[0].Rows[0]["Cantidad"]);
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string totalTicketsDia()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "totalTicketsDia";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string resultado = Convert.ToString(ds.Tables[0].Rows[0]["Cantidad"]);
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}

    	public string totalTickets()
    	{
    		try
    		{
    			Cmd.Parameters.Clear();
    			Cmd.CommandType = CommandType.StoredProcedure;
    			Cmd.CommandText = "totalTickets";
    			ds = new DataSet();
    			Adap = new MySqlDataAdapter(Cmd);
    			Adap.Fill(ds);
    			string resultado = Convert.ToString(ds.Tables[0].Rows[0]["Cantidad"]);
    			if (resultado != null)
    			{
    				return resultado;
    			}
    			resultado = null;
    			Cmd.Connection.Close();
    			return resultado;
    		}
    		catch (Exception)
    		{
    			return null;
    		}
    	}
    }

}

using System;
using System.Web.Http;

namespace paginaOficial.Controlers
{
    public class APIController : ApiController
    {
    	[HttpGet]
    	public object LoginApp(string user, string pass)
    	{
    		BaseDatos con = new BaseDatos();
    		try
    		{
    			string[] datos = con.getDatosSession(user, pass);
    			if (datos.Length != 0)
    			{
    				return new
    				{
    					usuario = datos[0],
    					id = user
    				};
    			}
    		}
    		catch (Exception)
    		{
    		}
    		return BadRequest();
    	}

    	[HttpGet]
    	public object Ticket(string userId)
    	{
    		BaseDatos con = new BaseDatos();
    		try
    		{
    			Tickets ticket = con.ultimoTicketDeTecnico(userId);
    			if (ticket != null)
    			{
    				return ticket;
    			}
    		}
    		catch (Exception)
    		{
    		}
    		return BadRequest();
    	}

    	[HttpGet]
    	[Route("api/Attending")]
    	public bool ChangeStatusToAttending(string idTicked)
    	{
    		BaseDatos con = new BaseDatos();
    		if (con.ChangeStatusToAttending(idTicked))
    		{
    			return true;
    		}
    		return false;
    	}

    	[HttpGet]
    	[Route("Final")]
    	public bool ChangeStatusToFinal(string idTicked)
    	{
    		BaseDatos con = new BaseDatos();
    		if (con.ChangeStatusToFinal(idTicked))
    		{
    			return true;
    		}
    		return false;
    	}

    	[HttpGet]
    	[Route("Escalate")]
    	public bool ChangeStatusToEscalate(string idTicked)
    	{
    		BaseDatos con = new BaseDatos();
    		if (con.ChangeStatusToEscalate(idTicked))
    		{
    			return true;
    		}
    		return false;
    	}
    }

}

using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace paginaOficial.Controlers
{
    public class Mailer
    {
    	public void Notify(string emailSolicitante, int id, string nombreSolicitante, string nombreTecnico, string nombreAgente, string depto, string area, string motivo, int estado)
    	{
    		try
    		{
    			MailAddress receiverEmail = new MailAddress(emailSolicitante, "Receiver");
    			string sub = "";
    			string body = "";
    			if (estado == 1)
    			{
    				string templatePath = HttpContext.Current.Server.MapPath("~/userscontent/modelEmail/creacion.html");
    				sub = "Creación de ticket #" + id + ": ";
    				body = File.ReadAllText(templatePath);
    				body = body.Replace("[id]", id.ToString());
    				body = body.Replace("[area]", area.ToString());
    				body = body.Replace("[motivo]", motivo.ToString());
    				body = body.Replace("[nombreAgente]", nombreAgente.ToString());
    				body = body.Replace("[nombreSolicitante]", nombreSolicitante.ToString());
    				body = body.Replace("[nombreTecnico]", nombreTecnico.ToString());
    				body = body.Replace("[depto]", depto.ToString());
    			}
    			if (estado == 2)
    			{
    				string templatePath2 = HttpContext.Current.Server.MapPath("~/userscontent/modelEmail/enCamino.html");
    				sub = "Técnico en camino ticket #" + id + ": ";
    				body = File.ReadAllText(templatePath2);
    				body = body.Replace("[id]", id.ToString());
    				body = body.Replace("[area]", area.ToString());
    				body = body.Replace("[nombreSolicitante]", nombreSolicitante.ToString());
    				body = body.Replace("[nombreTecnico]", nombreTecnico.ToString());
    				body = body.Replace("[depto]", depto.ToString());
    				body = body.Replace("[motivo]", motivo.ToString());
    			}
    			if (estado == 3)
    			{
    				string templatePath3 = HttpContext.Current.Server.MapPath("~/userscontent/modelEmail/atendido.html");
    				sub = "Confirmacion de atención por tecnico a ticket #" + id + ": ";
    				body = File.ReadAllText(templatePath3);
    				body = body.Replace("[id]", id.ToString());
    				body = body.Replace("[nombreSolicitante]", nombreSolicitante.ToString());
    				body = body.Replace("[nombreTecnico]", nombreTecnico.ToString());
    				body = body.Replace("[depto]", depto.ToString());
    			}
    			if (estado == 4)
    			{
    				string templatePath4 = HttpContext.Current.Server.MapPath("~/userscontent/modelEmail/verificacionAtendido.html");
    				sub = "Notificación de atencion de ticket #" + id + ": ";
    				body = File.ReadAllText(templatePath4);
    				body = body.Replace("[id]", id.ToString());
    				body = body.Replace("[nombreTecnico]", nombreTecnico.ToString());
    				body = body.Replace("[nombreSolicitante]", nombreSolicitante.ToString());
    				body = body.Replace("[depto]", depto.ToString());
    				body = body.Replace("[motivo]", motivo.ToString());
    				body = body.Replace("[hora]", area.ToString());
    			}
    			SmtpClient smtp = GetSmtpClient();
    			using (MailMessage mess = new MailMessage(GetSenderMail(), receiverEmail)
    			{
    				Subject = sub,
    				Body = body,
    				IsBodyHtml = true
    			})
    			{
    				smtp.Send(mess);
    				mess.Dispose();
    			}
    			smtp.Dispose();
    		}
    		catch (Exception)
    		{
    		}
    	}

    	private MailAddress GetSenderMail()
    	{
    		return new MailAddress("notificaciones@asamblea.gob.pa", "Notificaciones - Soprte Tecnico -Asamblea Nacional de Panamá");
    	}

    	private SmtpClient GetSmtpClient()
    	{
    		return new SmtpClient
    		{
    			Host = "correo.asamblea.gob.pa",
    			Port = 587,
    			EnableSsl = false,
    			DeliveryMethod = SmtpDeliveryMethod.Network,
    			UseDefaultCredentials = false,
    			Credentials = new NetworkCredential(GetSenderMail().Address, "Panama2021")
    		};
    	}
    }

}

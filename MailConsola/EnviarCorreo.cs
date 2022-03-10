using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailConsola
{
	public class EnviarCorreo
	{
		public bool Envio(string receptor, string Asunto, string Body)
		{
			bool Exito = false;
			string contra;
			MailMessage correo;
			DatosEnvio(receptor, Asunto, Body, out string remitente, out contra, out correo);

			SmtpClient cliente = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(userName: remitente, contra),
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network

			};
			try
			{
				cliente.Send(correo);
				correo.Dispose();
				Exito = true;

			}
			catch (Exception)
			{

				throw;
			}
			return Exito;

		}

		static void DatosEnvio(string receptor, string Asunto, string Body, out string remitente, out string contra, out MailMessage correo)
		{
			remitente = "sorportep@gmail.com";
			contra = "Integra.01";
			string textoRemitente = "TESTMAIL";

			correo = new MailMessage();
			correo.To.Add(new MailAddress(receptor));
			correo.From = new MailAddress(remitente, textoRemitente);
			// correo.Attachments.Add(new Attachment(Adjunto));
			correo.Sender = new MailAddress(remitente);
			correo.Subject = Asunto;
			correo.Body = Body;
			correo.IsBodyHtml = true;
			correo.Priority = MailPriority.Normal;
		}
	}
}

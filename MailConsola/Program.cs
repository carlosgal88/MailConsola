using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailConsola
{
	internal class Program
	{
		static void Main(string[] args)
		{
			EnviarCorreo enviarCorreo = new EnviarCorreo();

			try
			{
				enviarCorreo.Envio("cgalicia@integra.international", "test", "algo");
			}
			catch (Exception)
			{

				throw;
			}

			
		}
	}
}

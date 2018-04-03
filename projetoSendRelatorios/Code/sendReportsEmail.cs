using System;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using projetoSendRelatorios.Code.DTO;

namespace projetoSendRelatorios.Code
{
    public class sendReportsEmail
    {

        public static void enviarEmail(List<OperariosDTO> operarios){

			List<string> nomeDosOperarios = new List<string>();

            operarios.ForEach(item =>
            {
                nomeDosOperarios.Add(item.Nome);
            });


            Console.WriteLine("Criando listas de emails a enviar relatorios...\n");
            List<string> listaNomeDestinarios = new List<string>();
            List<string> listaEmailDestinatarios = new List<string>();

            Console.WriteLine("Adicionando emails cadastrados a lista de envios...\n");

            listaNomeDestinarios.Add("Gabriel Tamura"); 
            listaEmailDestinatarios.Add("gabriel-tamura@hotmail.com");
            listaNomeDestinarios.Add("Mylena Itmyle");
            listaEmailDestinatarios.Add("mylenaitmyle@gmail.com");

            Console.WriteLine("Iniciando envio dos emails...");
            try {

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Gabriel Tamura", "gabrieltamura17@gmail.com"));

                //GARANTIR QUE AS DUAS LISTAS TEM O MESMO TAMANHO

                for (int i = 0; i < listaEmailDestinatarios.Count; i++){
                    message.To.Add(new MailboxAddress(listaNomeDestinarios[i],listaEmailDestinatarios[i]));
                }

                message.Subject = "Hello ?";

                var bodyBuilder = new BodyBuilder();



                for (var j = 0; j < nomeDosOperarios.Count; j++){
                    bodyBuilder.HtmlBody += "<h1>" + nomeDosOperarios[j] + "</h1>";
                }

                message.Body = bodyBuilder.ToMessageBody();

                using(var client = new SmtpClient()){

                    Console.WriteLine("Criando autenticacao com o servico gmail...");
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    Console.WriteLine("Conectando ao servico smtp do gmail...");
                    client.Connect("smtp.gmail.com", 587, false);

                    Console.WriteLine("Autenticando email de envio...");
                    client.Authenticate("INSERT_EMAIL_HERE", "INSERT_PASSWORD_HERE");

                    Console.WriteLine("Enviando relatorios...");
                    client.Send(message);
                    client.Disconnect(true);
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Relatorios enviados com sucesso!");
                Console.ForegroundColor = ConsoleColor.Black;

                    

            }
            catch (Exception ex){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Erro: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            }

            
        }


        
    }
}

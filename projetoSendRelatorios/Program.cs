using System;
using System.Collections.Generic;
using projetoSendRelatorios.Code.BLL;
using projetoSendRelatorios.Code.DTO;
using projetoSendRelatorios.Code;

namespace projetoSendRelatorios
{
    class MainClass
    {

        OperariosBLL operariosBLL = new OperariosBLL();

        public static void Main(string[] args)
        {

            List<OperariosDTO> nomeDosOperarios = OperariosBLL.buscaDadosDosOperarios();

            //nomeDosOperarios.ForEach(item =>
            //{
            //    Console.ForegroundColor = ConsoleColor.DarkBlue;
            //    Console.WriteLine(item);
            //});
            //Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Black;

            sendReportsEmail.enviarEmail(nomeDosOperarios);
			//chama a funcao de enviar emails

            Console.WriteLine("Processo finalizado!");



            //termina de enviar relatorio
        }
    }
}

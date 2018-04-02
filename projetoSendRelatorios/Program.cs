using System;
using System.Collections.Generic;
using projetoSendRelatorios.Code.BLL;

namespace projetoSendRelatorios
{
    class MainClass
    {

        OperariosBLL operariosBLL = new OperariosBLL();

        public static void Main(string[] args)
        {

            List<string> nomeDosOperarios = OperariosBLL.buscaDadosDosOperarios();

            nomeDosOperarios.ForEach(item =>
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(item);
            });
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Black;


            Console.WriteLine("Processo finalizado!");

            //chama a funcao de enviar email


            //termina de enviar relatorio
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using MongoDB.Driver;  
using MongoDB.Bson;
using projetoSendRelatorios.Code.DTO;
using projetoSendRelatorios.Code.DAL;

namespace projetoSendRelatorios.Code.BLL
{
    
    public class OperariosBLL
    {

        OperariosDAL operariosDal = new OperariosDAL();

        public static List<OperariosDTO> buscaDadosDosOperarios(){

            Console.WriteLine("Criando lista de operarios...\n");
            List<OperariosDTO> nomeDosOperarios = new List<OperariosDTO>();

            string db = "01";
            string collection = "Collection1";

            Console.WriteLine("Fazendo requisicao para o Cosmos DB retornar a lista de operarios...\n");
            nomeDosOperarios = OperariosDAL.buscaDadosOperariosNoBanco(db, collection);

            return nomeDosOperarios;

        }

    }
}

using System;
using MongoDB.Bson;

namespace projetoSendRelatorios.Code.DTO
{
    public class OperariosDTO
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Celula { get; set; }
    }
}

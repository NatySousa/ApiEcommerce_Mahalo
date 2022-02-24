using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Entities
{
    public class Endereco
    {
        [Key] //necessário pois o Entity não reconhece o GUID como chave primária
        public Guid IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Guid IdCliente { get; set; }

        //Relacionamento de Associação =>TER-1 (Endereço tem um cliente) 

        public Cliente Cliente { get; set; }

        //Relacionamento de Associação =>TER-MUITOS (Endereço pode ter muitos pedidos)
        public List<Pedido> Pedidos { get; set; }
    } 
   
}
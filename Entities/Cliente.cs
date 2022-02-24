using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API_Desafio_Angular.Entities
{
    public class Cliente
    {   [Key] //necessário pois o Entity não reconhece o GUID como chave primária
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email{ get; set; }
        public string Senha { get; set; }

        //Relacionamento => Ter muitos
        public List<Pedido> Pedidos { get; set; }

        //Relacionamento => Ter muitos (Cliente pode ter muitos endereços)
        public List<Endereco> Enderecos  { get; set; }
    }
}
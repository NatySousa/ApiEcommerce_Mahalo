using System;
using System.Collections.Generic;

namespace API_Desafio_Angular.Model
{
    public class ClienteGetModel
    {
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public List<EnderecoGetModel> Enderecos { get; set; }
    }
}
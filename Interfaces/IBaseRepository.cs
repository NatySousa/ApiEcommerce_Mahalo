using System;
using System.Collections.Generic;

namespace API_Desafio_Angular.Interfaces
{  
    public interface IBaseRepository <T>  // IBaseRepository => Repositório genérico para fazer o CRUD
        where T : class //<T> Tipo de dado genérico, irá representar qualquer classe de entidade do projeto
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
        List<T> Consultar();
        T ObterPorId(Guid id);
    }
}
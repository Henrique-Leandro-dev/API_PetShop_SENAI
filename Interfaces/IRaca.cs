using API_PetShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface IRaca
    {
        Raca Cadastrar(Raca r);
        List<Raca> LerTodos();
        Raca BuscarPorId(int id);
        Raca Alterar(int id, Raca tp);
        void Excluir(int id);
    }
}

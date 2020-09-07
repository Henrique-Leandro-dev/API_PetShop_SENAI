using API_PetShop.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_PetShop.Interfaces
{
    interface ITipoPet
    {
        TipoPet Cadastrar(TipoPet tp);
        List<TipoPet> LerTodos();
        TipoPet BuscarPorId(int id);
        TipoPet Alterar(int id, TipoPet tp);
        void Excluir(int id);

    }
}

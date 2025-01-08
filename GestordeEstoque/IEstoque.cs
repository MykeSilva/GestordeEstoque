using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeEstoque {
    internal interface IEstoque {

        // Métodos não retornam nada
        void Exibir();
        void AdicionarEntrada();
        void AdicionarSaida();

    }
}

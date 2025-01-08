using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeEstoque {

    [System.Serializable]
    internal class ProdutoFísico: Produto, IEstoque {
        public float frete;
        private int estoque;

        // Gerando Construtor
        // (nome preco)-> Classe Pai (Produto)) (frete e estoque) -> Classe Filha (Produto Físico)
        public ProdutoFísico(string nome, float preco, float frete) {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada() {
            Console.WriteLine($"(ADICIONAR PRODUTOS) {nome}");
            Console.WriteLine("Digite a quantidade de produtos para adicionar:  ");
            int entrada = int.Parse( Console.ReadLine() );
            estoque += entrada;
            Console.WriteLine("Entrada efetuada com sucesso !");
            Console.ReadLine();
        }

        public void AdicionarSaida() {
            Console.WriteLine($"(REMOVER PRODUTOS) {nome}");
            Console.WriteLine("Digite a quantidade de produtos para remover:  ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }

        public void Exibir() {
            Console.WriteLine($"\nProduto Físico: {nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque: {estoque} (UN)");
            Console.WriteLine("=========================");
        }
    }
}

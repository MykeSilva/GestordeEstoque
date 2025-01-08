using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeEstoque {

    [System.Serializable]
    internal class Ebook: Produto, IEstoque {
        
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor) {
            this.nome = nome;
            this.preco = preco; 
            this.autor = autor;
        }

        public void AdicionarEntrada() {
            Console.WriteLine("E-book é um produto digital, não é possivel efetuar cadastros");
            Console.ReadLine();
        }

        public void AdicionarSaida() {
            Console.WriteLine($"(ADICIONAR VENDAS NO E-BOOK) {nome}");
            Console.WriteLine("Digite a quantidade de vendas efetuadas:  ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Saída registrada com sucesso !");
            Console.ReadLine();
        }

        public void Exibir() {
            Console.WriteLine($"\nE-book: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {vendas}");
            Console.WriteLine("=========================");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestordeEstoque {

    [System.Serializable]
    internal class Curso : Produto, IEstoque{
        public string autor;
        private int vagas; // vagas limitadas

        public Curso(string nome, float preco, string autor) {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
            
        }

        public void AdicionarEntrada() {
            Console.WriteLine($"(ADICIONAR VAGAS) {nome}");
            Console.WriteLine("Digite a quantidade de vagas para adicionar:  ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada efetuada com sucesso !");
            Console.ReadLine();
        }

        public void AdicionarSaida() {
            Console.WriteLine($"(ADICIONAR VAGAS) {nome}");
            Console.WriteLine("Digite a quantidade de vagas para remover:  ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }

        public void Exibir() {
            Console.WriteLine($"\nCursos: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas restantes: {vagas}");
            Console.WriteLine("=========================");
        }
    }
}

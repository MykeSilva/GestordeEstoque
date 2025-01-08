using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GestordeEstoque {
    internal class Program {


        // Tudo esta sendo salvo nessa lista, depois irei salvar no arquivo
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saída, Sair}
        static void Main(string[] args) {
            Carregar();
            bool escolheurSair = false;
            while(escolheurSair == false) {

                Console.WriteLine("(SISTEMA DE ESTOQUE)");
                Console.WriteLine("\n1-[LISTAR]\n2-[ADICIONAR]\n3-[REMOVER]\n4-[REGISTRAR ENTRADA]\n5-[REGISTRAR SAÍDA]\n6-[SAIR]");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);
                Menu escolha = (Menu)opInt;

                if(opInt > 0 && opInt < 7) {
                    switch(escolha) {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();  
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saída:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheurSair = true;
                            break;
                    }
                }
                else {
                    escolheurSair = true;
                }
                Console.Clear();
            }  
        }
        // LISTAGEM DE PRODUTOS
        static void Listagem() {
            Console.WriteLine("(LISTA DE PRODUTOS)");
            // Vou percorrer todos os produtos na lista de Produtos
            int i = 0;
            foreach(IEstoque produto in produtos) {
                Console.WriteLine($"ID: {i}");
                produto.Exibir();
            i++;
            }
            Console.ReadLine();
        }
        // REMOVER UM PRODUTO
        static void Remover() {
            Listagem();
            Console.WriteLine("(DIGITE O ID PARA EXCLUIR): ");
            int id = int.Parse(Console.ReadLine()); 
            if(id >= 0 && id < produtos.Count) {
                produtos.RemoveAt(id);
                Salvar();
            }
        }
        // ENTRADA NO ESTOQUE
        static void Entrada() {
            Listagem();
            Console.WriteLine("(DIGITE O ID PARA EFETUAR A QUANTIDADE DE ENTRADA): ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count) {
                produtos[id].AdicionarEntrada(); // Vou acessar o produto pelo id que o usuário digitou e vou chamar o método adicionr entrada
                Salvar();
            }
        }

        // BAIXA NO ESTOQUE
        static void Saida() {
            Listagem();
            Console.WriteLine("(DIGITE O ID PARA EFETUAR A QUANTIDADE DE SAÍDA): ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count) {
                produtos[id].AdicionarSaida(); // Vou acessar o produto pelo id que o usuário digitou e vou chamar o método adicionr entrada
                Salvar();
            }
        }

        // Método Cadastro (OBSERVAÇÃO, PODERIA FAZER COM ENUM, VOU DEIXAR PARA TER 2 FORMAS DE FAZER)
        static void Cadastro() {
            Console.WriteLine("(CADASTRO DE PRODUTO)");
            Console.WriteLine("1-Produto Físico\n2-E-book\n3-Curso");
            string opStr = Console.ReadLine();
            int escolhaInt = int.Parse(opStr);

            switch(escolhaInt) {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }
        }
        // Cadastrar Produto Físico
        static void CadastrarPFisico() {
            Console.WriteLine("CADASTRO DE PRODUTO FÍSICO");
            Console.WriteLine("Produto Físico: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());

            // Classe ProdutoFísico estou fazendo o polimorfismo de tipo
            ProdutoFísico pf = new ProdutoFísico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        // Cadastrar E-book
        static void CadastrarEbook() {
            Console.WriteLine("CADASTRO DE E-BOOK");
            Console.WriteLine("E-book: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();  

            Ebook eb = new Ebook (nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        // Cadastrar Curso
        static void CadastrarCurso() {
            Console.WriteLine("CADASTRO DE CURSOS");
            Console.WriteLine("Cursos: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar() {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();    
            encoder.Serialize(stream, produtos);
            stream.Close(); 
        }

        static void Carregar() {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            // Usar o try cacth para nao parar a execução do programa caso tenha um arquivo vazio
            try {
                produtos = (List<IEstoque>)encoder.Deserialize(stream); // A lista de produtos recebe um dados que vem direto do arquivo
                // Se produtor for nula eu vou criar uma lista do zero
                if(produtos == null) {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception e) {
                produtos = new List<IEstoque>();
            }
            stream.Close ();         
        }
    }
}

/* 
 
Classe Pai usa (HERANÇA)
1- Primeira Classe criada (Produto) -> CLASSE PAI (não vou criar instâncias dela)

2 - Segunda Classe (Produto Físico) -> Herda da CLASSE PAI (Produto).
Na variável (ESTOQUE) eu nao quero que programadores tenham acesso direto, 
essa variável só pode ser alterada atráves de métodos auxiliares
EX: alguem pode alterar para (int estoque = -100), para evitar vou deixá-la privada.

3 - Terceira Classe (E-book) sendo um produto digital, nao vai possuir o atributo estoque,
apenas um atributo privado (vendas)
OBS: Clicar sobre a classe Ebook e gerar o construtor (nao vou inserir a variável vendas)

4 - Quarta classe (Curso)
 
(INTERFACE -> Botão direito adicionar novo item clicar em (INTERFACE)
O padrão é sempre utilizar (I) maiúsculo

Mesmo criando essas classes eu quero evitar a replicação de Lógica, para cada funcionalidade adicionada
eu teria que implementar isso 3 vezes, porque eu tenho 3 tipos de produtos que se comportam diferentemente,
é preciso unificar esses 3 produtos utilizando a (Interface) em um único código fonte.

A premissa dessa clase é definir um contrato que toda classe participante deverá seguir
(Curso, Ebook e Produto Físico deverão respeitar as cláusulas desse contrato)


Depois de ter feito os contratos
Abrir arquivo Program.cs

Após criar a o método (SALVAR), inserir acima de todas as classes [System.Serializable]
eu digo para o C# que as classes (Produto, Curso, Estoque e ProdutoFisicao) podem ser salvos em arquivos

Criar a função (CARREGAR)
Criar a função (LISTAGEM)
Criar a função (REMOVER)
 

Criar um registro de entrada sempre que um novo produto for adicionado na quantidade de estoque
[O E-book não trabalha com estoque e sim com a quantidade de vendas] 

Criar um método (ENTRADA) de produtos 
Criar um método (SAÍDA) de produtos


 
 */
Classe Pai usa (HERANÇA)
1. Primeira Classe (Produto): Criada como Classe Pai (não vou criar instâncias dela).
2. Segunda Classe (Produto Físico): Herda da Classe Pai (Produto). Na variável (ESTOQUE), não quero que programadores tenham acesso direto. Essa variável só pode ser alterada através de métodos auxiliares para evitar valores indesejados, como (int estoque = -100). Para isso, ela será privada.
3. Terceira Classe (E-book): Sendo um produto digital, não possui o atributo ESTOQUE, apenas um atributo privado (vendas). OBS: Clicar sobre a classe E-book e gerar o construtor (não vou inserir a variável vendas).
4. Quarta classe (Curso).

Mesmo criando essas classes, quero evitar a replicação de lógica. Para cada funcionalidade adicionada, eu teria que implementar isso três vezes, pois tenho três tipos de produtos que se comportam de maneira diferente. É preciso unificar esses três produtos utilizando a (Interface) em um único código fonte.
A premissa dessa classe é definir um contrato que toda classe participante deverá seguir. (Curso, Ebook e Produto Físico) deverão respeitar as cláusulas desse contrato.

Após criar o método (SALVAR), inserir acima de todas as classes [System.Serializable] para indicar ao C# que as classes (Produto, Curso, Estoque e ProdutoFísico) podem ser salvas em arquivos.
Criar as funções:
- (CARREGAR)
- (LISTAGEM)
- (REMOVER)
Criar um registro de entrada sempre que um novo produto for adicionado ao estoque. [O E-book] não trabalha com estoque, mas sim com a quantidade de vendas.
Criar métodos:
- (ENTRADA) de produtos.
- (SAÍDA) de produtos.
- 
Conclusão: Desenvolver um sistema de classes bem estruturado com herança e interfaces pode prevenir a replicação de lógica, tornando o código mais limpo e fácil de manter. Além disso, utilizar serialização para salvar e carregar dados garante a persistência do estado dos objetos de maneira eficiente.

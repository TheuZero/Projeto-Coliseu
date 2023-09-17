# Projeto-Coliseu
Projeto Boladão do tcc.

Este é o projeto que fiz como trabalho de conclusão de curso para a Etec de Embu.

O que é o jogo?

É um jogo simples de luta com um pouco de elemento de plataforma. O jogo contém dois modos, o PVP e o Arcade, o PVP é para jogar contra alguém
e o Arcade é um modo infinito onde você acumula pontos eliminando os inimigos.

Controles:
P1:
Z: ataque
X: técnica
C: especial
espaço: pula
setas se movem.

O que esperar desse projeto?

Nada, pois desisti e estou fazendo coisas melhores, mas aqui segue alguns problemas dele

- IA
Mudar a série de ifs para um state-driven design pattern, ou só simplificar com switch statement.

- Referências
  
As referências estão uma bagunça, principalmente as que são sobre informações que transitam entre telas, com uma série de 
GameObject.Find, o que é horrível para a performance e gera lixo na memória. O correto seria centralizar a referência em um G.O
cujo os outros que não transitem pelo menu sejam filhos na hierarchy do editor, assim ficaria mais fácil de acessar.

- Instância de objetos
O correto seria cachear os objetos a serem instanciados em tempo de execução no início, desativar e reativar conforme for necessário (object pooling),
atualmente eu instancio e continuo instanciando, o que é péssimo para a performance também, além de ser uma má prática.

- Controles
Criar uma lista ou um array para conseguir transitar melhor a lista de botões entre objetos. Do jeito que está sendo feito é bem
exaustivo e exige ctrl c ctrl v.

- Animator
Tirando o animation controller do Dr Cronos, os outros dois estão uma bagunça. O fato de ter ignorado o exit e any state nodes para
algumas situações, fez com que ficasse mais bagunçado do que deveria.
Outra forma de se corrigir seria com FSM implementada via código.

- Banco de dados
Foi feito utilizando o mysql. Atualmente se encontra com bug na versão da build, sendo incapaz de fazer qualquer coisa relacionada
ao banco. No editor funciona, mas ainda tenho que subir o script aqui... e eu não tenho mais o script. Esse era só um requisito para a banca aceitar meu projeto.

Considerações finais:

O projeto foi feito em 6 meses e eu programei
sozinho, por enquanto ele só serve como um guia de como não fazer certas coisas.

Sobre a arte dos personagens:

Ela foi feita em 3D, animada e transformada em frames PNG, depois aplicamos uns filtros pra corrigir as cores.

Agradeço ao meu amigo Lucas de Queiroz Silva, pois ele cobriu toda essa parte sozinho, apenas pedindo a minha opinião algumas vezes.
Segue o Perfil dele: https://github.com/TecoTecoChines

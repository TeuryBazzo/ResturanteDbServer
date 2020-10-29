# Introdução

Programa feito para decidir em qual restaurante as pessoas vão almoçar no dia

## Ambiente

Para rodar o projeto é necessário ter o .NET CORE 3.1 instalado e também o VisualStudio 2019

Link para download do VS 2019 [https://visualstudio.microsoft.com/pt-br/vs/](https://visualstudio.microsoft.com/pt-br/vs/)

## Como usar

Esse projeto é um console application então o modo de interagir com ele é com o teclado.

Logo depois de rodar o projeto, a primeira etapa é selecionar qual o usuário irá realizar as operações.

Depois de selecionar o usuário você verá 3 opções
 
1. Para ver o restaurante mais votado
2. Para votar em um restaurante
3. Entrar com outro usuário

Caso digite 1, o programa ira mostrar o restaurante com mais votos

Caso digite 2, ira abrir uma lista de restaurantes para serem votados (Aqui é onde são aplicadas as regras descritas no teste)

Caso digite 3, o atual usuário será desligado e aparecera a lista com os usuários pré-cadastrados novamente

## Destaque
Eu tentei criar uma arquitetura que não esteja muito acoplada e bastante coesa (por isso as interfaces e os modulos bem seperados), tentei respeitar os principio S de solid, assim todo método tem um único motivo para ser alterado.

Foram adicionados testes unitários.

## Melhorias
Seria interressante criar uma API REST para futuramente adicionar uma interface WEB, assim aproveitando as regras de negocios.

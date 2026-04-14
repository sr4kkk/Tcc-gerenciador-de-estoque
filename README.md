📦 TCC - Gerenciador de Estoque
Sistema desktop para controle e gerenciamento de estoque, desenvolvido com foco em organização de produtos, autenticação de acesso e configuração de ambiente, oferecendo uma interface prática para operações do dia a dia.
---
✨ Visão geral
O projeto foi desenvolvido para centralizar rotinas de estoque em uma aplicação única, permitindo:
controle de produtos cadastrados
visualização e acompanhamento do estoque
autenticação de usuários
configuração do sistema
configuração de conexão com banco de dados
---
🚀 Funcionalidades
Login de acesso ao sistema
Cadastro de produtos
Consulta e controle de estoque
Tela de configurações gerais
Configuração de banco de dados
---
🛠️ Tecnologias utilizadas
C#
.NET
Windows Forms
Banco de Dados
Arquitetura em camadas
---
📁 Estrutura do projeto
A aplicação foi organizada para separar responsabilidades e facilitar manutenção, evolução e leitura do código.
```text
Data/
Infra/
Models/
Services/
Telas/
Utils/
Program.cs
```
---
🖼️ Telas do sistema
Login
Tela responsável pela autenticação de acesso ao sistema.
![Tela de Login](./assets/login.png)
---
Cadastro de Produto
Tela utilizada para registrar novos produtos no sistema.
![Tela de Cadastro de Produto](./assets/cadastroproduto.png)
---
Estoque
Tela destinada à visualização e ao gerenciamento dos itens cadastrados.
![Tela de Estoque](./assets/estoque.png)
---
Configurações
Tela com opções gerais de configuração do sistema.
![Tela de Configurações](./assets/config.png)
---
Configuração de Banco de Dados
Tela utilizada para definir e ajustar a conexão com o banco.
![Tela de Configuração de Banco](./assets/config_banco.png)
---
🎯 Objetivo do projeto
Este sistema tem como objetivo melhorar o controle de produtos e a organização do estoque, reduzindo erros manuais e tornando o gerenciamento mais prático e eficiente.
---
▶️ Como executar
1. Clonar o repositório
```bash
git clone https://github.com/sr4kkk/Tcc-gerenciador-de-estoque.git
```
2. Acessar a pasta do projeto
```bash
cd Tcc-gerenciador-de-estoque
```
3. Abrir no Visual Studio ou VS Code
Abra a solução ou o projeto e restaure as dependências necessárias.
4. Executar a aplicação
Compile e rode o projeto no ambiente .NET configurado na sua máquina.
---
👨‍💻 Autor
Flavio Crepaldi
GitHub: sr4kkk
---
📌 Observação
Para que as imagens sejam exibidas corretamente no GitHub, a pasta `assets` deve estar presente na raiz do repositório com estes arquivos:
`assets/cadastroproduto.png`
`assets/config.png`
`assets/config_banco.png`
`assets/estoque.png`
`assets/login.png`

# Projeto - Gerenciador de Tarefas

## Descrição

O sistema é um gerenciador de tarefas que visa organizar e facilitar o acompanhamento das atividades em um ambiente de desenvolvimento. Ele foi desenvolvido como projeto individual de conclusão do curso "Programação Orientada a Objetos I (C#)" do DiverseDev.

### Características Principais

1. **Usuários e Vínculos:**

   - Existem dois tipos de vínculos: `Tech Leader` e `Desenvolvedores`.
   - `Tech Leaders` têm visão global, podendo visualizar tarefas de todos, criar tarefas, assumir tarefas e acessar estatísticas específicas.
   - `Desenvolvedores` podem criar tarefas (sendo automaticamente responsáveis por elas), visualizar apenas suas próprias tarefas ou aquelas relacionadas.

2. **Atribuições do Tech Leader:**

   - Estatísticas: Tarefas em atraso, não iniciadas, concluídas, abandonadas, em progresso, com impedimento e a serem aprovadas para início, além de poder alterar o status de uma tarefa específica.
   - Autorização: Apenas Tech Leaders podem atribuir responsáveis diferentes do criador de uma tarefa ou alterar o responsável.

3. **Atribuições dos Desenvolvedores:**

   - Criação de Tarefas: Desenvolvedores podem criar tarefas, sendo automaticamente responsáveis por elas.
   - Visualização: Desenvolvedores veem apenas suas tarefas ou aquelas relacionadas a elas.

4. **Adição de Desenvolvedores:**

   - Desenvolvedores podem ser adicionados através de um arquivo CSV.

5. **Acesso ao Sistema:**
   - Todos os usuários acessam o sistema por meio de um username e senha.

## Estrutura do Projeto

```
├───Authentication
│       Authentication.cs
│
├───Models
│   ├───Enum
│   │       TaskStatus.cs
│   │
│   ├───Task
│   │       ProjectTask.cs
│   │
│   └───Users
│           Developer.cs
│           IUser.cs
│           TechLead.cs
│           User.cs
│
│
├───Service
│       developers.csv
│       GenerateUniqueId.cs
│       TaskRepository.cs
│       UserRepository.cs
│
└───UI
        Menu.cs
        Title.cs
        Utils.cs
```

### Classes Principais

1. **User:**

   - Classe base para usuários.
   - Contém informações como nome, username e senha.

2. **TechLead:**

   - Representa um Tech Leader.
   - Possui funcionalidades específicas, como estatísticas e autorizações especiais.

3. **Developer:**

   - Representa um Desenvolvedor.
   - Tem funcionalidades limitadas em comparação com Tech Leaders.

4. **ProjectTask:**

   - Representa uma tarefa no sistema.
   - Contém atributos como título, descrição, prazos e status.

5. **Menu:**
   - Facilita a interação com o usuário, exibindo menus e recebendo entradas.

### Funcionalidades

1. **Visualização de Tarefas:**

   - Tech Leaders e Desenvolvedores podem visualizar suas próprias tarefas ou aquelas correlacionadas.

2. **Criação de Tarefas:**

   - Desenvolvedores podem criar tarefas.
   - Tech Leaders podem criar e assumir tarefas.

3. **Estatísticas:**
   - Tech Leaders têm acesso a estatísticas detalhadas sobre o andamento das tarefas.

## Instruções de Uso

1. **Autenticação:**

   - Cada usuário precisa de um username e senha que estão no arquivo `developers.csv` dentro da pasta Service, para entrar no sistema.

2. **Menu Principal:**

   - O sistema apresenta um menu principal com opções específicas para cada tipo de usuário.

3. **Interatividade:**
   - Os menus e interações foram projetados para serem intuitivos, proporcionando uma experiência amigável.

## Conclusão

O Gerenciador de Tarefas é uma aplicação C# que facilita a gestão de atividades em equipes de desenvolvimento. Com funcionalidades diferenciadas para Tech Leads e Desenvolvedores, o sistema oferece uma abordagem modular e organizada. Este projeto representa a conclusão do curso Programação Orientada a Objetos I (C#) do DiverseDev, demonstrando aprendizados em boas práticas de programação e funcionalidades avançadas.

- [Paula Marinho](https://github.com/paulaandrezza)
- [DiverseDev](https://ada.tech/sou-aluno/programas/mercado-eletronico-diversedev)

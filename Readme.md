## ESCOLA PLUS ##
EscolaPlus é um sistema criado para estudo da estrutura ASP.NET 8 MVC e Entity Framework. 
A aplicação consiste num sistema de gestão escolar, que permite o gerenciamento de tarefas, alunos, notas, mensalidades e mais. 

Funcionalidades:
- Cadastro e gerenciamento de:
  - Usuários
  - Alunos
  - Professores
  - Turmas
  - Disciplinas
  - Notas
  - Atividades
  - Comunicados
  - Eventos escolares
- Relacionamentos entre entidades via Entity Framework
- Separação entre Entities e ViewModels
- Estrutura modular e de fácil manutenção

Estrutura Atual do Projeto:
EscolaPlus/
├── Controllers/
├── Data/
│   └── ApplicationDbContext.cs
├── Models/
│   ├── Entities/
│   └── ViewModels/
├── Views/
├── wwwroot/
├── Program.cs
├── Startup.cs
└── EscolaPlus.csproj

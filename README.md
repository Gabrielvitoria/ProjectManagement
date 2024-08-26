## Descrição do projeto 

Projeto para desafio da ferramenta de gerenciamento de projetos. O objetivo é desenvolver uma API que permita aos usuários organizar e monitorar suas tarefas diárias, bem como colaborar com colegas de equipe.

## Funcionalidades

:heavy_check_mark: `Funcionalidade 1:` Listagem de Projetos.

:heavy_check_mark: `Funcionalidade 2:` Criação de Projetos.

:heavy_check_mark: `Funcionalidade 3:` Remoção de Projetos.

:heavy_check_mark: `Funcionalidade 4:` Visualização de Tarefas.

:heavy_check_mark: `Funcionalidade 5:` Criação de Tarefas.

:heavy_check_mark: `Funcionalidade 6:` Atualização de Tarefas.

:heavy_check_mark: `Funcionalidade 7:` Atualização de status da Tarefas.

:heavy_check_mark: `Funcionalidade 8:` Remoção de Tarefas.

:heavy_check_mark: `Funcionalidade 9:` Relatório de performace como o número médio de tarefas concluídas por usuário nos últimos 30 dias.

:heavy_check_mark: `Funcionalidade 10:` Permissão de acesso em relatório apenas para usuário com permissão de "gerente".

:heavy_check_mark: `Funcionalidade 11:` Geração de token de acesso para API's que exegem permissão. 
- Obs. Para gerar token utilizar a API (/api/Authenticate/login) com as credenciais: ` username: master | password: master`

## Ferramentas utilizadas

<a> <img src="https://api.nuget.org/v3-flatcontainer/microsoft.dotnet.web.projecttemplates.8.0/8.0.6/icon" alt="java" width="40" height="40"/> .Net 8 </a> 
</br>
<a> <img src="https://www.mysql.com/common/logos/logo-mysql-170x115.png" width="40" height="40"/> </a> 

## Abrir e rodar o projeto
Após baixar o projeto, você pode abrir com o `visual studio 2022` e executar utilizando docker da seguinte forma:
### Acessar local onde baixou e executar: 
- docker build -t projectmanager-image-api -f Dockerfile .
- docker-compose up -d

## Melhoraria no projeto
- Criar um repositório para utilizar Dapper para os relatórios
- Passar para o appsettings.json a quantidade de tarefas permitidas e utilizar no serviço essa quantidade.
- Tornar a geração de torken com usuário real
- Permtir informar datas como filtro no relatório e caso não informe assumir os 30 dias como padrão

## Refinamento para futuras implementações ou melhorias.
- Possibilidade do relatório ser asyncrono e ser processado fora da aplicação.
- Possibilidade de criar um projeto passando as tarefas
- Possibildiade de um serviço realizar a limpesa da tabela de historico para registros que foram excluidos depois de um tempo
- Notificar o usuário do relatório pronto por email e uma sessão dos relatorio que ele já gerou com um tempo de vida
- Alterar as API's para que tenha segurança com controle acesso.

## Cobertura de teste

<a href="https://drive.google.com/uc?export=view&id=<FILEID>"><img src="https://drive.google.com/uc?export=view&id=11QQalJ0HYMm8kEtFMbi_jxLYVdF7oCzE" style="width: 650px; max-width: 100%; height: auto" title="Click to enlarge picture" />

###
## Desenvolvedores
| [<img src="https://avatars.githubusercontent.com/u/6514350?v=4" width=115><br><sub>Gabriel da Vitória</sub>](https://github.com/Gabrielvitoria)
| :---: | 

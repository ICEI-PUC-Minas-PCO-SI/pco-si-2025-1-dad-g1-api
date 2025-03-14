# Introdução

Nos últimos anos, o mercado de eventos tem experimentado um crescimento expressivo, impulsionado tanto pelo avanço das tecnologias digitais quanto pela crescente demanda por experiências presenciais e híbridas.
A ascensão de plataformas de bilhetagem e gestão de eventos como Sympla demonstra o potencial de inovação no setor, mas também revela lacunas significativas que ainda dificultam a experiência dos organizadores e participantes.
Com a necessidade crescente de otimizar a organização e aumentar a acessibilidade dos eventos, a tecnologia desempenha um papel central na automatização de tarefas como controle de inscrições, processamento de pagamentos e interação com o público. No entanto, muitas das soluções existentes apresentam limitações, seja por custos elevados, falta de integração com outras ferramentas ou experiências fragmentadas para os usuários. Diante desse cenário, surge a oportunidade de desenvolver uma solução inovadora que una praticidade, eficiência e um modelo de negócios acessível para organizadores de eventos de diversos portes.

## Problema

Organizar um evento envolve uma série de desafios que vão desde a divulgação e gestão de inscrições até o controle de acesso e a comunicação com os participantes. Muitos organizadores enfrentam dificuldades para administrar esses processos de forma eficiente, especialmente quando precisam lidar com ferramentas fragmentadas, altos custos de plataformas especializadas e a falta de integração com outros sistemas. Esses obstáculos impactam diretamente a experiência tanto dos organizadores, que precisam investir tempo e recursos extras, quanto dos participantes, que muitas vezes enfrentam dificuldades na inscrição, no pagamento ou no recebimento de informações sobre o evento.
Além disso, o setor de eventos é dinâmico e abrange diversos segmentos, como conferências corporativas, shows, workshops e encontros acadêmicos, cada um com demandas específicas. No entanto, muitas soluções existentes não oferecem a flexibilidade necessária para atender a diferentes tipos de eventos, resultando em plataformas pouco adaptáveis às necessidades dos organizadores. Esse cenário se torna ainda mais crítico em um mundo cada vez mais digitalizado, onde o público espera experiências fluidas e automatizadas, e onde os organizadores precisam de dados precisos para otimizar suas estratégias de engajamento e monetização.

## Objetivos

O objetivo geral deste projeto é desenvolver uma plataforma digital para gestão de eventos que simplifique e automatize processos como inscrições, controle de acesso, comunicação com participantes e integração com sistemas de pagamento. A proposta visa eliminar as dificuldades enfrentadas por organizadores ao administrar eventos, oferecendo uma solução eficiente, acessível e adaptável a diferentes tipos de eventos.

Para alcançar esse objetivo, alguns objetivos específicos foram definidos:

* Criar um sistema intuitivo para gestão de eventos, permitindo que organizadores cadastrem eventos, configurem detalhes como limite de participantes e valores de ingressos, e acompanhem inscrições em tempo real.

* Implementar um módulo de inscrições e controle de acesso, incluindo funcionalidades de check-in digital para facilitar a entrada dos participantes e evitar fraudes.

* Desenvolver um mecanismo de comunicação eficiente, possibilitando o envio de notificações por e-mail ou push para manter os participantes informados sobre atualizações e lembretes do evento.

* Garantir a segurança e confiabilidade dos dados, adotando boas práticas de armazenamento e autenticação para proteger informações dos organizadores e participantes.

## Justificativa

A fragmentação das ferramentas disponíveis e os altos custos de plataformas especializadas dificultam o acesso de pequenos e médios organizadores a soluções eficientes. Eventos corporativos, acadêmicos, culturais e sociais frequentemente demandam funcionalidades específicas, como controle de inscrições, integração com métodos de pagamento e comunicação direta com os participantes. No entanto, muitas soluções existentes não oferecem a flexibilidade necessária ou cobram taxas elevadas que inviabilizam sua adoção por negócios menores. Esse cenário evidencia a necessidade de um sistema acessível, intuitivo e integrado, que otimize o gerenciamento de eventos e reduza a carga operacional dos organizadores.

Além dos desafios para os organizadores, os participantes também enfrentam dificuldades, como processos de inscrição complexos, falta de informações atualizadas sobre os eventos e filas longas para credenciamento. Segundo uma pesquisa da Eventbrite, 66% dos participantes de eventos esperam um processo de check-in rápido e digital, e 72% consideram essencial receber notificações sobre atualizações e lembretes. Isso reforça a importância de desenvolver um sistema que atenda tanto às necessidades dos organizadores quanto às expectativas do público, proporcionando uma experiência mais fluida e interativa.

## Público-Alvo

A aplicação será utilizada por diferentes perfis de usuários, cada um com necessidades e níveis de familiaridade tecnológica distintos. A seguir, destacam-se os principais grupos que poderão se beneficiar da plataforma:

#### Organizadores de Eventos

Esse grupo inclui desde profissionais experientes do setor até pequenos organizadores que realizam eventos de forma independente. Eles podem ser responsáveis por conferências corporativas, workshops, shows, feiras ou encontros acadêmicos. O nível de familiaridade com tecnologia varia, com alguns usuários acostumados a utilizar sistemas complexos de gestão e outros que ainda dependem de métodos manuais, como planilhas e formulários físicos. A aplicação deve, portanto, ser intuitiva e acessível, permitindo que organizadores com diferentes níveis de conhecimento consigam gerenciar seus eventos de maneira eficiente.

#### Participantes 

Os participantes dos eventos abrangem um público diversificado, desde estudantes e profissionais que frequentam congressos e cursos até fãs de shows e festivais. Esse grupo tem expectativas elevadas quanto à facilidade de inscrição, rapidez no check-in e acesso a informações atualizadas. Como muitos utilizam dispositivos móveis para consumir conteúdos e realizar compras, a plataforma deve priorizar uma experiência fluida e responsiva, garantindo que o processo de participação em eventos seja simples e eficiente.



# Especificações do Projeto

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto.

Caso deseje atribuir uma imagem a sua persona, utilize o site https://thispersondoesnotexist.com/

## Personas

Lúcia tem 34 anos, é coordenadora de eventos e trabalha como freelance organizando conferências, workshops e feiras de negócios. Ela está sempre em busca de soluções que a ajudem a gerenciar inscrições, vender ingressos e divulgar seus eventos de forma prática e eficiente. Ela precisa de uma plataforma intuitiva e com ferramentas de pagamento integradas para facilitar a organização de seus eventos e otimizar a experiência dos participantes. 

Carlos tem 29 anos, é empreendedor no ramo cultural e organiza shows, peças de teatro e outras apresentações. Ele quer uma maneira simples e eficaz de vender ingressos online e promover seus eventos. Ele busca uma plataforma que ofereça opções de personalização de ingressos, como assento marcado e ingressos VIP, além de ferramentas para divulgar suas produções nas redes sociais e controlar a capacidade do local. 

Fernanda tem 25 anos, é designer e adora participar de eventos como palestras, cursos e festivais. Ela busca uma plataforma intuitiva onde possa encontrar e se inscrever em eventos de forma rápida e fácil, com opções de pagamento variadas. Ela precisa de acesso a todas as informações necessárias sobre os eventos e espera ser notificada sobre mudanças ou atualizações para aproveitar ao máximo a experiência. 

João tem 40 anos, é gerente de marketing e trabalha em uma grande empresa de tecnologia. Ele organiza eventos internos para capacitação de funcionários, além de promover workshops e seminários para parceiros comerciais. Ele busca uma plataforma que facilite a gestão de inscrições, controle de vagas e distribuição de materiais aos participantes. João precisa de uma ferramenta que integre a venda de ingressos com relatórios detalhados de participação e que seja facilmente personalizada para refletir a identidade corporativa dos eventos.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

| **EU COMO... `PERSONA`**                        | **QUERO/PRECISO ... `FUNCIONALIDADE`**                                                                 | **PARA ... `MOTIVO/VALOR`**                                                                                  |
|-------------------------------------------------|-------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------|
| **Lúcia, coordenadora de eventos**              | **Quero uma interface intuitiva para criar e gerenciar eventos**                                        | **Para facilitar a organização dos eventos e otimizar o processo de inscrição e venda de ingressos.**         |
| **Lúcia, coordenadora de eventos**              | **Preciso de ferramentas de pagamento integradas**                                                     | **Para processar pagamentos de ingressos de forma segura e ágil, garantindo uma experiência prática.**        |
| **Lúcia, coordenadora de eventos**              | **Quero relatórios detalhados sobre as vendas de ingressos e participação**                             | **Para monitorar o desempenho do evento, entender a adesão do público e tomar decisões informadas.**           |
| **Carlos, empreendedor cultural**               | **Preciso de opções de personalização de ingressos (VIP, assento marcado, etc.)**                        | **Para atender às diferentes necessidades dos participantes e maximizar a experiência do público.**           |
| **Carlos, empreendedor cultural**               | **Quero ferramentas para divulgar eventos nas redes sociais diretamente da plataforma**                 | **Para aumentar a visibilidade dos eventos e atrair mais participantes através de canais de comunicação.**     |
| **Carlos, empreendedor cultural**               | **Preciso de uma ferramenta para controlar a capacidade do local e o acesso dos participantes**          | **Para garantir que o evento não ultrapasse a capacidade e evitar problemas no momento da entrada.**           |
| **Fernanda, participante de eventos**           | **Quero encontrar eventos de forma rápida e intuitiva**                                                  | **Para descobrir facilmente eventos de meu interesse sem perder tempo.**                                     |
| **Fernanda, participante de eventos**           | **Preciso de opções de pagamento variadas (cartão, boleto, Pix, etc.)**                                  | **Para garantir que posso pagar de forma prática e segura, de acordo com minha preferência.**                |
| **Fernanda, participante de eventos**           | **Quero receber notificações sobre alterações e atualizações dos eventos**                             | **Para estar sempre informada sobre mudanças de última hora e garantir que não perca detalhes importantes.**    |
| **João, gerente de marketing**                  | **Preciso de ferramentas para gerar relatórios detalhados de participação e engajamento nos eventos**    | **Para avaliar o sucesso do evento e obter insights sobre o comportamento dos participantes.**                |
| **João, gerente de marketing**                  | **Quero uma plataforma que permita personalizar a identidade visual do evento (logo, cores, etc.)**     | **Para garantir que o evento reflita a identidade corporativa da empresa e ofereça uma experiência profissional.** |
| **João, gerente de marketing**                  | **Preciso de controle de inscrições e distribuição de materiais aos participantes**                     | **Para gerenciar de forma eficaz a quantidade de participantes e fornecer materiais relevantes durante o evento.** |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade | 
|------|-----------------------------------------|----| 
|RF-001| A aplicação deve permitir gestão de usuários  | ALTA |  
|RF-002| A aplicação deve permitir gestão de eventos    | ALTA | 
|RF-003| A aplicação deve permitir inscrição de participantes   | ALTA | 
|RF-004| A aplicação deve permitir fazer checkin no evento     | MÉDIA | 
|RF-005| A aplicação deve fazer a notificações e comunicação    | MÉDIA | 
|RF-006| A aplicação deve emitir relatórios e análises    | MÉDIA | 
|RF-007| A aplicação deve ter controle de lista de espera   | MÉDIA | 



### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | MÉDIA | 
|RNF-002| O sistema deve estar disponível com um tempo de inatividade máximo de 1 hora por mês para manutenção. |  BAIXA | 
|RNF-003| Deve ser implementado um sistema de log para registrar erros e eventos relevantes. | BAIXA |
|RNF-004| Deve-se utilizar boas práticas de desenvolvimento | ALTA |
|RNF-005| Todos os dados devem ser transmitidos via HTTPS. | ALTA |

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

# Arquitetura da Solução

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

![arq](https://github.com/user-attachments/assets/b9402e05-8445-47c3-9d47-f11696e38a3d)

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

# Planejamento do projeto

##  Divisão de papéis

> Apresente a divisão de papéis entre os membros do grupo em cada Sprint. O desejável é que, em cada Sprint, o aluno assuma papéis diferentes na equipe. Siga o modelo do exemplo abaixo:

### Sprint 1
- _Scrum master_: AlunaX
- Protótipos: AlunoY
- Testes: AlunoK
- Documentação: AlunaZ

### Sprint 2
- _Scrum master_: AlunaY
- Desenvolvedor _front-end_: AlunoX
- Desenvolvedor _back-end_: AlunoK
- Testes: AlunaZ

##  Quadro de tarefas

> Apresente a divisão de tarefas entre os membros do grupo e o acompanhamento da execução, conforme o exemplo abaixo.

### Sprint 1

Atualizado em: 21/04/2024

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| AlunaX        | Introdução | 01/02/2024     | 07/02/2024 | ✔️    | 05/02/2024      |
| AlunaZ        | Objetivos    | 03/02/2024     | 10/02/2024 | 📝    |                 |
| AlunoY        | Histórias de usuário  | 01/01/2024     | 07/01/2005 | ⌛     |                 |
| AlunoK        | Personas 1  |    01/01/2024        | 12/02/2005 | ❌    |       |

### Sprint 2

Atualizado em: 21/04/2024

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| AlunaX        | Página inicial   | 01/02/2024     | 07/03/2024 | ✔️    | 05/02/2024      |
| AlunaZ        | CSS unificado    | 03/02/2024     | 10/03/2024 | 📝    |                 |
| AlunoY        | Página de login  | 01/02/2024     | 07/03/2024 | ⌛     |                 |
| AlunoK        | Script de login  |  01/01/2024    | 12/03/2024 | ❌    |       |


Legenda:
- ✔️: terminado
- 📝: em execução
- ⌛: atrasado
- ❌: não iniciado


> **Links úteis**:
> - [11 passos essenciais para implantar Scrum no seu projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)
> - [Os papéis do Scrum e a verdade sobre cargos nessa técnica](https://www.atlassian.com/br/agile/scrum/roles)

## Processo

Coloque informações sobre detalhes da implementação do Scrum seguido pelo grupo. O grupo deverá fazer uso do recurso de gerenciamento de projeto oferecido pelo GitHub, que permite acompanhar o andamento do projeto, a execução das tarefas e o status de desenvolvimento da solução.
 
> **Links úteis**:
> - [Planejamento e gestão ágil de projetos](https://pucminas.instructure.com/courses/87878/pages/unidade-2-tema-2-utilizacao-de-ferramentas-para-controle-de-versoes-de-software)
> - [Sobre quadros de projeto](https://docs.github.com/pt/issues/organizing-your-work-with-project-boards/managing-project-boards/about-project-boards)
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Como criar backlogs no GitHub](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial slack](https://slack.com/intl/en-br/)

## Ferramentas

Liste todas as ferramentas que foram empregadas no projeto, justificando a escolha delas, sempre que possível.

Exemplo: os artefatos do projeto são desenvolvidos a partir de diversas plataformas e a relação dos ambientes com seu respectivo propósito é apresentada na tabela que se segue.

| Ambiente                            | Plataforma                         | Link de acesso                         |
|-------------------------------------|------------------------------------|----------------------------------------|
| Repositório de código fonte         | GitHub                             | http://....                            |
| Documentos do projeto               | GitHub                             | http://....                            |
| Projeto de interface                | Figma                              | http://....                            |
| Gerenciamento do projeto            | GitHub Projects                    | http://....                            |
| Hospedagem                          | Vercel                             | http://....                            |
 

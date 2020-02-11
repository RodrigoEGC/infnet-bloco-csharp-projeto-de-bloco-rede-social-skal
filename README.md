### Skal
Uma Rede Social para Degustadores de Cervejas

Este Projeto é pertinente à materia .NET da grade de Engenharia de Computação no Instituto Infnet.
 
 
### Integrantes: 	
* Wander Falcão
* Venícius Setubal
* Rodrigo Araújo
 
### Responsáveis pela escrita dos requisitos:
* RF1, RF2, RF3 e RF4 - Venícius Setubal
* RF5, RF6, RF7 e RF8 - Wander Falcão
* RF9, RF10, RF11 e RF12 - Rodrigo Araújo


## Requisitos Funcionais

```bash 
RF1: Cadastro na Rede Social SKåL
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: O usuário não pode estar cadastrado na rede social SKåL.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário informa os dados de cadastro: Nome, Sobrenome, E-mail, Nome de Usuário, Senha, Confirmar Senha.
3. Usuário executa o cadastro.

Fluxo de Exceção
 3.1. E-mail já existe.
 3.1.1. Deve ser informado que o E-mail já existe.

Pós-condição: Usuário cadastrado na rede social SKåL. 
 
 
RF2: Visualizar os dados do Usuário cadastrados na rede social SKåL.
Ator: Usuário.
Requisitos funcionais relacionados: RF1
Pré condição: O usuário deve estar cadastrado na rede social SKåL.
Fluxo Principal
1. Usuário visualiza o seu cadastro da rede social: Nome, Sobrenome, E-mail, Nome de Usuário.

RF3: O usuário deve poder editar os seus dados cadastrados.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social SKåL e visualizar os seus dados cadastrais (ver RF2) antes de iniciar a edição dos seus dados.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário pode editar qualquer um dos dados cadastrados: Nome, Sobrenome, E-mail, Nome de Usuário, Senha.
3. Usuário executa a atualização de cadastro.

Fluxo de Exceção
2.1. Para editar a senha, será necessário informar: senha atual, nova senha e confirmar nova senha.
2.2. Ao editar o e-mail, deve ser validado se o novo e-mail já está cadastrado para outro usuário e, se estiver, deve ser informado para o usuário.

Pós-condição: Usuário atualiza o cadastrado na rede social SKåL. 
 
RF4: O usuário deve poder apagar os seus dados cadastrados, assim excluindo sua conta da rede social SKåL.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social SKåL e visualizar os seus dados cadastrais (ver RF2) antes de excluir seus dados.
Fluxo Principal
1. Usuário acessa o cadastro da rede social.
2. Usuário executa a exclusão de cadastro.

Fluxo de Exceção
2.1. Antes de confirmar a exclusão do usuário, uma mensagem será exibida com a opção de cancelar esta ação e outra para confirmar.
2.2. Se optar por cancelar a exclusão, o mesmo retornará para a tela de visualização dos dados cadastrais.
2.3. Se optar por confirmar a exclusão, o mesmo será informado que os seus dados foram excluídos do cadastro da rede social SKål e este será redirecionado para a de login na rede.

Pós-condição: Usuário exclui o seu cadastro da rede social SKåL.

RF-5: A rede social deve permitir o cadastro de anunciantes( publicidade de cervejas, e pubs) para promoverem suas marcas.
RF-6:A rede social deve permitir que os anunciantes possam visualizar seus dados cadastrados.
RF-7:A rede social deve permitir que os anunciantes possam editar os seus dados cadastrados.
RF-8:A rede social deve permitir que os anunciantes possam deletar os dados cadastrados.


RF-9: Criação de grupos específicos de cervejas [Tipos, ex: Pilsen, Ale].
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: O usuário deve estar autenticado na rede social SKåL.
Fluxo Principal
1. Usuário logado no seu perfil, acessa a aba de grupos.
2. Para a criação de um grupo, o usuário deve cadastrar dados que identificam sua finalidade, como título e descrição.
3. Usuário após o preenchimento dos dados necessários cria o grupo.

Fluxo de Exceção
3.1. Caso o usuário tente cadastrar um grupo com o nome já existente, deve ser emitido uma mensagem com o seguinte contexto:
"Grupo já existente, por favor, altere nome e descrição, ou clique em seguir para acompanhar grupo já existente".

Pós-condição: Usuário cadastrado na rede social SKåL.

RF-10: Permitir o envio de mensagens entre os usuários cadastrados.
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: 
O usuário deve estar autenticado na rede social SKåL.
A troca de mensagens só é permitida para usuários associados como "amigos" dentro da rede social.
Fluxo Principal
1. Usuário poderá acessar o perfil a qual deseja interação na listagem de "amigos" ou selecionar o contato no chat, caso o mesmo esteja dísponivel.
2. Usuário clica em Mensagens.
3. É aberto uma janela de troca de mensagens, permitindo que aos usuários conversarem entre si.

Fluxo de Exceção

Pós-condição: Usuário cadastrado na rede social SKåL.

RF-11: Configuração de Perfil.
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: 
O usuário deve estar autenticado na rede social SKåL.
Fluxo Principal
1. Após o usuário criar uma conta, por padrão, sua pagina de perfil é composto pelos dados informados nos dados cadastrado (Ver RF 1)
2. Além de adiconar, editar (ver RF1 e RF3), é possível configurar o recurso de foto, avatar.
3. Usuário dispõe de abas ou módulos selecionaveis, onde cada aba apresenta uma lista com campos de perguntas relacionadas à temática da rede.
4. Após o cadastro destes campo, o perfil do usuário é estruturado pelas respostas pertinentes ao seu gosto pessoal.

Fluxo de Exceção

Pós-condição: Usuário cadastrado na rede social SKåL.
 
RF-12: Permitir que usuários cadastrados adicionem outros usuários como membros da sua rede.
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: O usuário deve estar autenticado na rede social SKåL.
Fluxo Principal
1. Usuário logado no seu perfil, dispõe atráves de um campo de busca, uma categoria de usuários que estão na rede.
2. Ao listar o(s) usuário(os) da rede, é permitido as opções seguir e adicionar.
3. Quando a relação é criada, ocorrerá o envio de um e-mail informando que o usuário obteve um novo seguidor ou que o Usuário solicitante deseja adicionar o Usuário2 à sua rede.

Fluxo de Exceção

Pós-condição: Usuário cadastrado na rede social SKåL.
 
```


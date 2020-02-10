# Skal
Uma Rede Social para Degustadores de Cervejas

Projeto de Bloco
 
Integrantes: 	Wander Falcão
Venícius Setubal
Rodrigo Araújo
 
Responsáveis pela escrita dos requisitos:
RF1, RF2, RF3 e RF4 - Venícius Setubal
RF5, RF6, RF7 e RF8 - Wander Falcão
RF9, RF10, RF11 e RF12 - Rodrigo Araújo

Rede Social SKåL
Uma Rede Social para Degustadores de Cervejas
Requisitos Funcionais
RF1: Cadastro na Rede Social SKåL
Ator: Usuário.
Requisitos funcionais relacionados: RF
Pré condição: O usuário não pode estar cadastrado na rede social SKåL.
Fluxo Principal
Usuário acessa o cadastro da rede social.
Usuário informa os dados de cadastro: Nome, Sobrenome, E-mail, Nome de Usuário, Senha, Confirmar Senha.
Usuário executa o cadastro.
Fluxo de Exceção
 3.1. E-mail já existe.
 3.1.1. Deve ser informado que o E-mail já existe.
Pós-condição: Usuário cadastrado na rede social SKåL. 
 
 
RF2: Visualizar os dados do Usuário cadastrados na rede social SKåL.
Ator: Usuário.
Requisitos funcionais relacionados: RF1
Pré condição: O usuário deve estar cadastrado na rede social SKåL.
Fluxo Principal
Usuário visualiza o seu cadastro da rede social: Nome, Sobrenome, E-mail, Nome de Usuário.
RF3: O usuário deve poder editar os seus dados cadastrados.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social SKåL e visualizar os seus dados cadastrais (ver RF2) antes de iniciar a edição dos seus dados.
Fluxo Principal
Usuário acessa o cadastro da rede social.
Usuário pode editar qualquer um dos dados cadastrados: Nome, Sobrenome, E-mail, Nome de Usuário, Senha.
Usuário executa a atualização de cadastro.
Fluxo de Exceção
2.1. Para editar a senha, será necessário informar: senha atual, nova senha e confirmar nova senha.
2.2. Ao editar o e-mail, deve ser validado se o novo e-mail já está cadastrado para outro usuário e, se estiver, deve ser informado para o usuário.
Pós-condição: Usuário atualiza o cadastrado na rede social SKåL. 
 
RF4: O usuário deve poder apagar os seus dados cadastrados, assim excluindo sua conta da rede social SKåL.
Ator: Usuário.
Requisitos funcionais relacionados: RF2
Pré condição: O usuário deve estar logado na rede social SKåL e visualizar os seus dados cadastrais (ver RF2) antes de excluir seus dados.
Fluxo Principal
Usuário acessa o cadastro da rede social.
Usuário executa a exclusão de cadastro.
Fluxo de Exceção
2.1. Antes de confirmar a exclusão do usuário, uma mensagem será exibida com a opção de cancelar esta ação e outra para confirmar.
2.2. Se optar por cancelar a exclusão, o mesmo retornará para a tela de visualização dos dados cadastrais.
2.3. Se optar por confirmar a exclusão, o mesmo será informado que os seus dados foram excluídos do cadastro da rede social SKål e este será redirecionado para a de login na rede.
Pós-condição: Usuário exclui o seu cadastro da rede social SKåL.
RF-5: A rede social deve permitir o cadastro de anunciantes( publicidade de cervejas, e pubs) para promoverem suas marcas.
RF-6:A rede social deve permitir que os anunciantes possam visualizar seus dados cadastrados.
RF-7:A rede social deve permitir que os anunciantes possam editar os seus dados cadastrados.
RF-8:A rede social deve permitir que os anunciantes possam deletar os dados cadastrados.
RF-9: Criação de grupos específicos de cervejas [Tipos, ex: Pilsen, Ale]
RF-10: Permitir o envio de mensagens entre os usuários cadastrados.
RF-11: Avaliação dos usuários e anunciantes.
 
RF-12: Permitir que usuários cadastrados adicionem outros usuários como membros da sua rede.
 
RF-13:  


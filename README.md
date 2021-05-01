# BootCampPB - 2021

**Implementado por Caroline Hukami Feitosa.**

Este repositório apresenta minha solução do projeto de BootCamp da trilha de back end do processo seletivo do Paraná Banco (PB). Abaixo, explico quais foram as alterações e adições necessárias para a conclusão do projeto solicitado, que consiste em um CRUD de interessados (com nome e e-mail dos usuários).

# Arquivos Adicionados/Modificados

Arquivos que foram alterados ou modificados por mim para compor minha solução final.

## Models/Interessado.cs

Foi criada uma nova classe **Interessado** para representar um interessado, contendo os atributos **nome** e **email**, ambos do tipo *string*. 

## Services/IInteresseService.cs

Na interface de interesse, foi alterado o tipo de retorno das funções existentes, deixando de retornar um *object*, para retornar a classe que foi criada (**Interessado**). Além disso, foram adicionados os parâmetros necessários para cada função (*email*, para *ConsultaPorEmail* e *ExcluirPorEmail*, e *nome* e *email*, para *Incluir* e *AtualizarEmail*.

## Services/InteresseService.cs

No serviço de interesse, foi adicionado uma lista de interessados, cujo objetivo é armazenar todos os interessados registrados pela API criada. Além dos métodos já existentes, foram criados os métodos *ImprimeLista*, para debugar a lista de interessados, e *ValidaEmail*, para validar o e-mail passado como parâmetro (utilizando a o módulo nativo *System.Net.Mail.MailAddress*). Para cada método já existente, foi implementada a lógica necessária para realizar cada método:

 - *ConsultarPorEmail*: anda na lista de interessados, buscando o *email* passado como parâmetro. Se o interessado for encontrado, retorna ele. Caso contrário, retorna *null*.
 - *ConsultarTodos*: retorna a lista de interessados.
 - *Incluir*: primeiro, verifica se o *email* passado como parâmetro é válido. Se não for, retorna *null*. Caso contrário, verifica se já existe algum interessado registrado com esse *email*. Se já existir, retorna *null*. Caso contrário, um novo interessado é criado e adicionado a lista.
 - *AtualizarEmail*: verifica se existe um interessado com o *email* passado como parâmetro. Se não existir, retorna *null*. Caso contrário, altera o nome do interessado encontrado utilizando o *nome* passado como parâmetro.
 - *ExcluirPorEmail*: anda na lista de interessados e verifica se o *email* passado como parâmetro pertence a algum interesado. Se encontrar, remove o interessado da lista e retorna *true*. Caso contrário, retorna *false*.

## Controllers/InteresseController.cs

No controlador de interesse, para cada método já criado no projeto base, foram implementadas as lógicas necessárias para o funcionamento das mesmas. Os métodos implementados utilizam o serviço *InteresseService* para gerenciar a lista de usuários. Os seguintes métodos foram modificados:

 - *ConsultarTodosInteresses*: utiliza o método *ConsultarTodos* do serviço e retorna a lista de interessados.
 - *ConsultarInteresse*: utiliza o método *ConsultarPorEmail* do serviço e verifica se o usuário foi encontrado. Se foi, retorna **NotFound**. Caso contrário, retorna **Ok**, com o respetivo interessado.
 - *AdicionarInteresse*: utiliza o método *Incluir* do serviço e verifica se o usuário foi criado. Se foi, retorna **Ok** com os dados do mesmo. Caso contrário, retorna **NotFound**.
 - *AtualizarInteresse*: utiliza o método *AtualizarEmail* do serviço e verifica se o usuário foi atualizado. Se foi, retorna **Ok** com os dados do mesmo. Caso contrário, retorna **NotFound**.
 - *ExcluirInteresse*: utiliza o método *ExcluirInteresse* do servivço e verifica se o usuário foi excluído. Se foi, retorna **Ok**. Caso contrário, retorna **NotFound**.

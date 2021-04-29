using ArquivoBaseBootcamp.Models;
using ArquivoBaseBootcamp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace ArquivoBaseBootcamp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InteresseController : ControllerBase
    {
        private readonly IInteresseService _interesseService;

        public InteresseController(IInteresseService interesseService)
        {
            _interesseService = interesseService;
        }

        /// <summary>
        /// Este endpoint deve consultar as interessadas cadastradas
        /// </summary>
        /// <returns>
        /// Retorna a lista com todas as interessadas cadastradas
        /// </returns>
        [HttpGet]
        public IActionResult ConsultarTodosInteresses()
        {
            // obtem lista de interessados
            List<Interessado> interessados = _interesseService.ConsultarTodos();
            // retorna lista com ok
            return Ok(interessados);
        }

        /// <summary>
        /// Este endpoint deve consultar a interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpGet]
        [Route("consultar/{email}")]
        public IActionResult ConsultarInteresse(String email)
        {
            // procura interessado
            Interessado interessado = (Interessado)_interesseService.ConsultarPorEmail(email);
            // verifica se interessado existe
            if (interessado == null)
            {
                // retorna nao encontrado
                return NotFound();
            }
            else
            {
                // interessado encontrado, retorna ele
                return Ok(interessado);
            }
        }

        /// <summary>
        ///  Este endpoint deve realizar o inclusao de uma interessada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPost]
        [Route("incluir")]
        public IActionResult AdicionarInteresse(String nome, String email)
        {
            // inclui novo interessado e obtem resposta do serviço
            Interessado interessado = (Interessado) _interesseService.Incluir(nome, email);
            // verifica se interessado foi realmente criado
            if (interessado == null)
            {
                // retorna nao encontrado
                return NotFound();
            }
            else
            {
                // interessado encontrado, retorna ele
                return Ok(interessado);
            }
        }

        /// <summary>
        /// Este endpoint deve atualizar os dados da interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpPut]
        [Route("atualizar/{email}")]
        public IActionResult AtualizarInteresse(String email, String nome)
        {
            // obtem interessado e atualiza caso existe
            Interessado interessado = _interesseService.AtualizarEmail(email, nome);
            // verifica se foi atualizado
            if (interessado == null)
            {
                // interessado nao encontrado
                return NotFound();
            }
            else
            {
                // interessado atualizado
                return Ok(interessado);
            }
        }

        /// <summary>
        /// Este endpoint deve excluir a interessada cadastrada
        /// </summary>
        /// <returns>
        /// Retorna 2xx caso sucesso
        /// Retorna 4xx caso erro
        /// </returns>
        [HttpDelete]
        [Route("excluir/{email}")]
        public IActionResult ExcluirInteresse(String email)
        {
            // tenta excluir
            bool encontrado = _interesseService.ExcluirPorEmail(email);
            // verifica se foi excluido
            if (encontrado)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}

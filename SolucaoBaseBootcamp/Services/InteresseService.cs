using ArquivoBaseBootcamp.Models;
using System;
using System.Collections.Generic;

namespace ArquivoBaseBootcamp.Services
{
    public class InteresseService : IInteresseService
    {

        // lista de interessados
        private List<Interessado> interessados = new List<Interessado> { };

        private void ImprimeLista()
        {
            Console.WriteLine("------");
            foreach (Interessado i in this.interessados)
            {
                Console.WriteLine(i.Nome + " " + i.Email);
                Console.WriteLine("++");
            }
        }

        private bool ValidaEmail(String email)
        {
            try
            {
                // cria objeto do tipo MailAddress para validar email
                var mail = new System.Net.Mail.MailAddress(email);
                // verifica se validação é igual ao email no parâmetro
                return mail.Address == email;
            }
            catch
            {
                // se der erro, retorna falso pois deu erro de validação
                return false;
            }

        }

        public Interessado ConsultarPorEmail(String Email)
        {
            // anda na lista de interessados
            foreach (Interessado i in this.interessados)
            {
                // verifica se email = i.email
                if (i.Email == Email)
                {
                    // retorna interessado caso encontrado
                    return i;
                }
            }
            // se chegou até aqui, retorna nulo pois não encontrou nada
            return null;
        }

        public List<Interessado> ConsultarTodos()
        {
            return this.interessados;
        }

        // Obrigatorio nome E email
        // Validar email
        // Nao permitir email duplicado
        public Interessado Incluir(String Nome, String Email)
        {
            // valida email
            if (this.ValidaEmail(Email))
            {
                // verifica se interessado já existe
                Interessado interessado = this.ConsultarPorEmail(Email);
                // se for nulo, não encontrou nada e pode registrar um novo
                if (interessado == null)
                {
                    // cria um novo interessado
                    interessado = new Interessado { Nome = Nome, Email = Email };
                    // adiciona a lista de interessados
                    this.interessados.Add(interessado);
                    // retornar interessado
                    return interessado;
                }
                else
                {
                    // nao cria novo interessado
                    return null;
                }
            }
            else
            {
                // nao cria novo interessado pois email é inválido
                return null;
            }
        }

        public Interessado AtualizarEmail(String Email, String Nome)
        {
            // obtem interessado
            Interessado interessado = this.ConsultarPorEmail(Email);
            // verifica se interessado existe
            if (interessado == null)
            {
                // retorna nulo, não existe
                return null;
            }
            else
            {
                // muda o nome
                interessado.Nome = Nome;
                // retorna initeressado
                return interessado;
            }
        }

        public bool ExcluirPorEmail(String Email)
        {
            // anda na lista de interessados
            foreach (Interessado i in this.interessados)
            {
                // verifica se email = i.email
                if (i.Email == Email)
                {
                    // retorna interessado caso encontrado
                    this.interessados.Remove(i);
                    // retorna verdadeiro pois removeu de lista
                    return true;
                }
            }
            // retorna falso pois nao encontrou
            return false;
        }
    }
}

using ArquivoBaseBootcamp.Models;
using System.Collections.Generic;

namespace ArquivoBaseBootcamp.Services
{
    public interface IInteresseService
    {
        public Interessado ConsultarPorEmail(string Email);
        public List<Interessado> ConsultarTodos();
        public Interessado Incluir(string Nome, string Email);
        public Interessado AtualizarEmail(string Email, string Nome);
        public bool ExcluirPorEmail(string Email);
    }
}

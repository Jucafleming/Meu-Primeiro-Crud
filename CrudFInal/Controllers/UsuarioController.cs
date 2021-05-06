using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Grenciamento.Entidades;
using Infra.Repositorio;

namespace CrudFInal.Controllers
{
    [Route("api/Usuario")] //chama o controller na rota
    [ApiController]

    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio usuarioRepository; //readonly pra nao alterar a classe

        public UsuarioController() //metodo "main" / construtor
        {
            usuarioRepository = new UsuarioRepositorio();
        }
        [HttpGet]
        public IEnumerable<Usuario> Listar()
        {
            return usuarioRepository.GetAll();
        }
        [HttpGet("{cpf}")]
        public Usuario Obter(int cpf)
        {
            return usuarioRepository.GetById(cpf);
        }

        [HttpPost]
        public void Salvar([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Add(usuario);
            }

        }

        [HttpPut("{cpf}")]
        public void Atualizar(int cpf, [FromBody] Usuario usuario)
        {
            usuario.CPF = cpf;
            if (ModelState.IsValid)
            {
                usuarioRepository.Update(usuario);
            }

        }

        [HttpDelete("{cpf}")]
        public void Deletar(int cpf)
        {
            usuarioRepository.Delete(cpf);
        }

    }
}


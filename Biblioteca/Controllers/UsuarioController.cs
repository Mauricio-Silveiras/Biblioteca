using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Biblioteca.Models;
using System.Linq;
using System;


namespace Biblioteca.Controllers
{
    public class UsuarioCotroller : Controller
    {
        public IActionResult ListarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View(new UsuarioService().Listar());
        }

        public IActionResult RegistrarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario novoUser)
        {
            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);
            new UsuarioService().incluirUsuario(novoUser);

            return View("ListarUsuarios");
        }

        public IActionResult NeedAdmin()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View(new UsuarioService().BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            
            new UsuarioService().editarUsuario(userEditado);
            return View();
        }

        public IActionResult ExcluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            new UsuarioService().excluirUsuario(id);
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using SisatemaEscolar.API.Controllers;
using SisatemaEscolar.API.Models;
using SistemaEscolar.Aplication.Interfaces;
using SistemaEscolar.Aplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.TestUnitAPI.Controller
{
    public class UsuarioControllerUnitTests
    {
        private readonly UsuarioController _controller;
        private readonly Mock<IUsuarioService> _usuarioServiceMock;


        public UsuarioControllerUnitTests()
        {
            _usuarioServiceMock = new Mock<IUsuarioService>();
            _controller = new UsuarioController(_usuarioServiceMock.Object);

        }

        [Fact]
        public void CadastrarUsuario_ComParametrosCorretos_ResultadoValido()
        {
            UsuarioViewModel usuarioModel = new UsuarioViewModel();

            //Arrange
            usuarioModel.Nome = "Vinicius Guilherme de Freitas Andrade";
            usuarioModel.Email = "nhçlnl";
            usuarioModel.CEP = "5454555";
            usuarioModel.Cidade = "Paudalho";
            usuarioModel.Estado = "Pernambuco";
            usuarioModel.Perfis = new int[] { 1 };
            usuarioModel.Senha = "1wslsk";
            usuarioModel.Status = true;

            //Act
            var resultadoTask =  _controller.CadastrarUsuario(usuarioModel);
            var result = resultadoTask.Result;
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void CadastrarUsuario_ComParametrosFaaltante_ResultadoValido()
        {
            UsuarioViewModel usuarioModel = new UsuarioViewModel();

            //Arrange
            usuarioModel.Nome = null;
            usuarioModel.Email = "nhçlnl";
            usuarioModel.CEP = "5454555";
            usuarioModel.Cidade = "Paudalho";
            usuarioModel.Estado = "Pernambuco";
            usuarioModel.Perfis = new int[] { 1 };
            usuarioModel.Senha = "1wslsk";
            usuarioModel.Status = true;

            //Act
            var resultadoTask = _controller.CadastrarUsuario(usuarioModel);
            var result = resultadoTask.Result;
            Assert.IsType<BadRequestResult>(result);
        }
    }
}

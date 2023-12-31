﻿using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers {
    [Produces("application/json")]
    [Route("pessoa")]
    public class PessoaController : Controller {
        private IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService) {
            _pessoaService = pessoaService;
        }

        [HttpPost("criar")]
        public IActionResult Criar([FromBody] Pessoa pessoa) {
            try {
                _pessoaService.Criar(pessoa);
                return Json(RetornoApi.Sucesso("Pessoa criada com sucesso!"));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("deletar")]
        public IActionResult Deletar([FromBody] int id) {
            try {
                _pessoaService.Deletar(id);
                return Json(RetornoApi.Sucesso("Pessoa deletada com sucesso!"));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPut("editar")]
        public IActionResult Editar([FromBody] Pessoa pessoa) {
            try {
                _pessoaService.Editar(pessoa);
                return Json(RetornoApi.Sucesso("Pessoa editada com sucesso!"));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("buscarPorId")]
        public IActionResult BuscarPorId([FromHeader] int id) {
            try {
                var pessoa = _pessoaService.BuscarPorId(id);
                return Json(RetornoApi.Sucesso(pessoa));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("buscarLista")]
        public IActionResult BuscarLista() {
            try {
                var listaPessoas = _pessoaService.BuscarLista();
                return Json(RetornoApi.Sucesso(listaPessoas));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("ListaPessoas")]
        [AllowAnonymous]
        public JsonResult ListaPessoas() {
            try {
                var obj = _pessoaService.BuscarLista();
                return Json(RetornoApi.Sucesso(obj));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar([FromBody] Pessoa obj) {
            try {
                _pessoaService.Criar(obj);
                return Json(RetornoApi.Sucesso(true));
            } catch (Exception ex) {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_Sprint5.Data;
using Projeto_Sprint5.Data.Dtos.Cidade;
using Projeto_Sprint5.HttpClients;
using Projeto_Sprint5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sprint5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadeController : ControllerBase
    {
        private CidadeClienteContext _ccContext;
        private CepApiClient _client;
        private IMapper _mapper;

        public CidadeController(CidadeClienteContext ccc, IMapper mapper, CepApiClient client)
        {
            _ccContext = ccc;
            _mapper = mapper;
            _client = client;
        }

        [HttpGet]
        public IActionResult GetRegistros()
        {
            var cidadesDto = _mapper.Map<List<Cidades>, List<LerCidadeDto>>(_ccContext.Cidades.ToList());
            return Ok(cidadesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroPorId(int id)
        {
            var cidade = _ccContext.Cidades.FirstOrDefault(c => c.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            var cidadeDto = _mapper.Map<LerCidadeDto>(cidade);
            return Ok(cidadeDto);
        }

        [HttpPost("{cep}")]
        public async Task<IActionResult> CriarNovaCidade(string cep)
        {
            var CEP = await _client.GetCepAsync(cep);
            if (CEP != null)
            {
                var novaCidade = new Cidades
                {
                    Nome = CEP.Localidade,
                    Estado = CEP.UF,
                };
                _ccContext.Cidades.Add(novaCidade);
                _ccContext.SaveChanges();
                return CreatedAtAction(nameof(GetRegistroPorId), new { id = novaCidade.Id }, novaCidade);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AlterarCidade(int id, [FromBody] AtualizarCidadeDto novaCidadeDto)
        {
            var cidade = _ccContext.Cidades.FirstOrDefault(c => c.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _mapper.Map(novaCidadeDto, cidade);
            _ccContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCidade(int id)
        {
            var cidade = _ccContext.Cidades.FirstOrDefault(c => c.Id == id);
            if (cidade == null)
            {
                return NotFound();
            }
            _ccContext.Remove(cidade);
            _ccContext.SaveChanges();
            return NoContent();
        }
    }
}

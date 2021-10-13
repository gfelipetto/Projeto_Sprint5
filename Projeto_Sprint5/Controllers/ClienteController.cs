using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto_Sprint5.Data;
using Projeto_Sprint5.Data.Dtos.Cliente;
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
    public class ClienteController : ControllerBase
    {
        private CidadeClienteContext _ccContext;
        private CepApiClient _client;
        private IMapper _mapper;

        public ClienteController(CidadeClienteContext ccc, IMapper mapper, CepApiClient client)
        {
            _ccContext = ccc;
            _mapper = mapper;
            _client = client;
        }

        [HttpGet]
        public IActionResult GetRegistros()
        {
            var clientesDto = _mapper.Map<List<Clientes>, List<LerClienteDto>>(_ccContext.Clientes.ToList());
            return Ok(clientesDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistroPorId(int id)
        {
            var cliente = _ccContext.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.ResidenteDe = _ccContext.Cidades.FirstOrDefault(c => c.Id == cliente.CidadeId);
            var clienteDto = _mapper.Map<LerClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoCliente([FromBody] CadastraClienteDto cadastraClienteDto)
        {
            var cepCliente = await _client.GetCepAsync(cadastraClienteDto.Cep);
            var cidade = _ccContext.Cidades.FirstOrDefault(c => c.Nome == cepCliente.Localidade && c.Estado == cepCliente.UF);
            if (cidade != null)
            {
                var novoCliente = new Clientes
                {
                    Nome = cadastraClienteDto.Nome,
                    DataNascimento = cadastraClienteDto.DataNascimento,
                    CidadeId = cidade.Id,
                    Cep = cadastraClienteDto.Cep,
                    Logradouro = cepCliente.Logradouro,
                    Bairro = cepCliente.Bairro,
                };
                _ccContext.Clientes.Add(novoCliente);
                _ccContext.SaveChanges();
                return CreatedAtAction(nameof(GetRegistroPorId), new { id = novoCliente.Id }, novoCliente);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AlterarCliente(int id, [FromBody] AtualizarClienteDto novoClienteDto)
        {
            var cliente = _ccContext.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var cepCliente = await _client.GetCepAsync(novoClienteDto.Cep);
            var cidade = _ccContext.Cidades.FirstOrDefault(c => c.Nome == cepCliente.Localidade && c.Estado == cepCliente.UF);
            if (cidade != null)
            {
                cliente.CidadeId = cidade.Id;
                cliente.Logradouro = cepCliente.Logradouro;
                cliente.Bairro = cepCliente.Bairro;
                cliente.ResidenteDe = cidade;

                _mapper.Map(novoClienteDto, cliente);
                _ccContext.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _ccContext.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            _ccContext.Remove(cliente);
            _ccContext.SaveChanges();
            return NoContent();
        }
    }
}

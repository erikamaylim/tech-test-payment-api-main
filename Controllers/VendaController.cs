using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api_main.Models;
using tech_test_payment_api_main.Context;

namespace tech_test_payment_api_main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        [HttpPost("RegistrarVenda")]
        public IActionResult RegistrarVenda(Venda venda)
        {
            if (venda.ItemVenda == null)
            {
                return BadRequest(new {Erro = "A venda precisa ter pelo menos 1 item"});
            }

            _context.Add(venda);
            _context.SaveChanges();

            return Ok(venda);
        }

        [HttpGet("BuscarVenda")]
        public IActionResult BuscarVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        [HttpPatch("AtualizarVenda")]
        public IActionResult AtualizarVenda(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco.Status == EnumStatusVenda.AguardandoPagamento)
            {
                if (venda.Status == EnumStatusVenda.PagamentoAprovado)
                {
                    vendaBanco.Status = venda.Status;
                }
                else if (venda.Status == EnumStatusVenda.Cancelada)
                {
                    vendaBanco.Status = venda.Status;
                }
                else
                {
                    return BadRequest(new {Erro = "Não é possível realizar esta alteração"});
                }                
            }

            else if (vendaBanco.Status == EnumStatusVenda.PagamentoAprovado)
            {
                if (venda.Status == EnumStatusVenda.EnviadoParaTransportadora)
                {
                    vendaBanco.Status = venda.Status;
                }
                else if (venda.Status == EnumStatusVenda.Cancelada)
                {
                    vendaBanco.Status = venda.Status;
                } 
                else 
                {
                    return BadRequest(new {Erro = "Não é possível realizar esta alteração"});
                }
            }

            else if (vendaBanco.Status == EnumStatusVenda.EnviadoParaTransportadora)
            {
                if (venda.Status == EnumStatusVenda.Entregue)
                {
                    vendaBanco.Status = venda.Status;
                }
                else
                {
                    return BadRequest(new {Erro = "Não é possível realizar esta alteração"});
                }
            }

            else 
            {
                return BadRequest(new {Erro = "Não é possível realizar esta alteração"});
            }
                
            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);


        }
    }

}
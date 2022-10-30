using ContaBancaria.Api.Models;
using ContaBancaria.Api.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        //Atributo do contexto
        private BancoMatheusContext _context;

        //Construtor que recebe o contexto
        public ContaController(BancoMatheusContext context)
        {
            _context = context;
        }

        //GET /api/conta
        [HttpGet]
        public ActionResult<IList<Conta>> Listar()
        {
            return _context.Contas.ToList();
        }

        //GET /api/conta/{id}
        [HttpGet("{id}")]
        public ActionResult<Conta> DetalhePeloId(int id)
        {
            //Pesquisa a conta pelo numero
            var conta = _context.Contas.Find(id);
            //Valida se a conta foi encontrada
            if(conta == null) 
                return NotFound();
            //Retorna a conta
            return conta;
        }

        //POST /api/conta
        [HttpPost]
        public ActionResult<Conta> Criar(Conta conta)
        {
            //Grava a conta no banco
            _context.Contas.Add(conta);
            _context.SaveChanges();
            //Retorna 201 Created - url para acessar o recurso
            return CreatedAtAction("Get", new {id = conta.Numero}, conta);
        }

        //PUT /api/conta/{id}
        [HttpPut("{id}")]
        public ActionResult Atualizar(Conta conta, int id)
        {
            //Pesquisar a conta
            var cc = _context.Contas.Find(id);
            //Validar se existe
            if (cc == null)
                return NotFound();

            //Tirar o objeto "cc" do gerenciamento do DbContext
            _context.Entry(cc).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            //Adicionar id na conta
            conta.Numero = id;
            //Atualizar a conta
            _context.Contas.Update(conta);
            _context.SaveChanges();
            //Retornar NoContent (204)
            return NoContent();

        }

        //DELETE /api/conta/{id}
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            //Pesquisar a conta
            var cc = _context.Contas.Find(id);
            //Validar se existe a conta
            if (cc == null)
                return NotFound();
            //Adicionar alterações no banco
            _context.Contas.Remove(cc);
            _context.SaveChanges();
            //Retorna NoContent (204)
            return NoContent();
        }
    }
}

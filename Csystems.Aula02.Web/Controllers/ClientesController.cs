using Csystems.Aula02.Persistencia.Dados.SQLServer;
using Csystems.Aula02.Web.Views.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Csystems.Aula02.Dominio.Entidades;
using AutoMapper;

namespace Csystems.Aula02.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClientesController : Controller
    {
        PdvDbContexto db = new PdvDbContexto();
        public ClientesController()
        {

        }
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult Lista(int pagina = 1, int registros = 100)
        {
            var model = db.Clientes.OrderBy(c => c.Nome).Skip((pagina-1)*registros).Take(registros);
            return View(model);
        }

        public ActionResult Incluir()
        {
            var model = new ClienteViewModel();
            return View(model);
        }
        // POST: Teste/Create
        [HttpPost]
        public ActionResult Incluir(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cliente dadosCliente = new Cliente()
                    {
                        Nome = cliente.Nome,
                        CPF = cliente.CPF,
                        Fantasia = cliente.Fantasia
                    };

                    //Cliente dadosCliente = Mapper.Map<ClienteViewModel>(cliente);

                    db.Clientes.Add(dadosCliente);
                    db.SaveChanges();
                    return RedirectToAction("Lista");
                }
                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Clientes.First(x => x.ClienteId == id);

            ClienteViewModel view = new ClienteViewModel();
            view.ClienteId = model.ClienteId;
            view.CPF = model.CPF;
            view.Fantasia = model.Fantasia;
            view.Nome = model.Nome;

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(view);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dados = db.Clientes.Find(cliente.ClienteId);
                    dados.CPF = cliente.CPF;
                    dados.Fantasia = cliente.Fantasia;
                    dados.Nome = cliente.Nome;

                    db.Entry(dados).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Lista");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }       

        public ActionResult Detalhes(int id)
        {
            var model = db.Clientes.Where(x => x.ClienteId == id).First();
            return View(model);
        }

        [Authorize]
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = db.Clientes.First(x => x.ClienteId == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            ClienteViewModel view = new ClienteViewModel();
            view.ClienteId = model.ClienteId;
            view.CPF = model.CPF;
            view.Fantasia = model.Fantasia;
            view.Nome = model.Nome;

            return View(view);
        }

        // POST: Teste/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirma(int id)
        {
            try
            {
                var model = db.Clientes.Find(id);
                db.Clientes.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Lista");
            }
            catch
            {
                return View();
            }
        }
    }
}
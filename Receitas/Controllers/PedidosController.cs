using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoM2;
using ProjetoM2.Models;

namespace ProjetoM2.Controllers
{
    public class PedidosController : Controller
    {
        private AppDBContext db = new AppDBContext();
        private static int IdAtual, ReceitaIdAtual, QuantidadeAtual;
        private static float PrecoAtual;

        // GET: Pedidos
        public ActionResult Index(string ordenar)
        {

            /*var pedidos = from a in db.Pedidos
                           select a;

            if (String.IsNullOrEmpty(ordenar))
            {
                ViewBag.OrdenarData = "data";
            }
            else
            {
                if (ordenar.Equals("data"))
                {
                    pedidos = pedidos.OrderBy(a => a.Data);
                    ViewBag.OrdenarData = "data_desc";
                }
                else if (ordenar.Equals("data_desc"))
                {
                    pedidos = pedidos.OrderByDescending(a => a.Data);
                    ViewBag.OrdenarData = "data";
                }
            }


            return View(pedidos);*/
            return View(db.Pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create(int? id)
        {
            if(id != null)
            {
                IdAtual = id.Value;
            }
            ViewBag.ReceitaID = new SelectList(db.Receitas, "Id", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReceitaID,Quantidade,Data")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedidos.Add(pedido);
                pedido.Cliente = db.Clientes.Find(IdAtual);
                pedido.Receita = db.Receitas.Find(pedido.ReceitaID);
                pedido.Preco = db.Receitas.Find(pedido.ReceitaID).Preco * pedido.Quantidade;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ReceitaIdAtual = pedido.ReceitaID;
            PrecoAtual = pedido.Preco;
            QuantidadeAtual = pedido.Quantidade;
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,Finalizado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Preco = PrecoAtual;
                pedido.ReceitaID = ReceitaIdAtual;
                pedido.Quantidade = QuantidadeAtual;
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidos.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidos.Find(id);
            db.Pedidos.Remove(pedido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

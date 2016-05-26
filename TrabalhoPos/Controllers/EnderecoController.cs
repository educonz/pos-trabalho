﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TrabalhoPos.Models;
using Microsoft.AspNet.SignalR;
using TrabalhoPos.Hubs;

namespace TrabalhoPos.Controllers
{
    public class EnderecoController : Controller
    {
        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        private Contexto db = new Contexto();

		// GET: Endereco/GetListJson
        public async Task<ActionResult> GetListJson()
		{
            return View(await db.Enderecos.ToListAsync());
		}

        // GET: Endereco
        public async Task<ActionResult> Index()
        {
            return View(await db.Enderecos.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Logradouro,Cidade")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Enderecos.Add(endereco);
                await db.SaveChangesAsync();
                hubContext.Clients.All.mensagem($@"Foi adicionado uma novo endereço!");
                return RedirectToAction("Index");
            }

            return View(endereco);
        }

        // GET: Endereco/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Logradouro,Cidade")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                await db.SaveChangesAsync();
                hubContext.Clients.All.mensagem($@"Foi editado um endereço!");
                return RedirectToAction("Index");
            }
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = await db.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Endereco endereco = await db.Enderecos.FindAsync(id);
            db.Enderecos.Remove(endereco);
            await db.SaveChangesAsync();
            hubContext.Clients.All.mensagem($@"Foi excluído um endereço!");
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

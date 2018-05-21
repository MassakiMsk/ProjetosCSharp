using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoM2.ViewModel
{
    public class ItemPedidoViewModel
    {
        public AppDBContext db = new AppDBContext();
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public int IdReceita { get; set; }
        public List<SelectListItem> Receitas { get; set; }

        public ItemPedidoViewModel()
        {
            Receitas = CarregaReceitas("");
        }

        public List<SelectListItem> CarregaReceitas(string nome)
        {
            var lista = new List<SelectListItem>();
            var receitas = db.Receitas.ToList();
            
            try
            {
                foreach (var item in receitas)
                {
                    var option = new SelectListItem()
                    {
                        Text = item.Nome,
                        Value = item.Nome,
                        Selected = (item.Nome == nome)
                    };
                    lista.Add(option);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return lista;
        }
    }
}
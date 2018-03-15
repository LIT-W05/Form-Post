using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult SearchProducts()
        {
            return View();
        }

        public ActionResult SearchResults(int? minStock, int? maxStock)
        {
            if (minStock == null)
            {
                minStock = 20;
            }
            if (maxStock == null)
            {
                maxStock = minStock + 10;
            }

            NorthwindManager manager = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = manager.GetProducts(minStock.Value, maxStock.Value);
            SearchResultsViewModel svm = new SearchResultsViewModel
            {
                Products = products,
                MinStock = minStock.Value,
                MaxStock = maxStock.Value
            };
            return View(svm);
        }

        public ActionResult SearchBetter(int? minStock, int? maxStock)
        {
            if (minStock == null && maxStock == null)
            {
                return View(new SearchResultsViewModel());
            }


            NorthwindManager manager = new NorthwindManager(Properties.Settings.Default.ConStr);
            IEnumerable<Product> products = manager.GetProducts(minStock.Value, maxStock.Value);
            SearchResultsViewModel svm = new SearchResultsViewModel
            {
                Products = products,
                MinStock = minStock,
                MaxStock = maxStock
            };
            return View(svm);
        }
    }
}
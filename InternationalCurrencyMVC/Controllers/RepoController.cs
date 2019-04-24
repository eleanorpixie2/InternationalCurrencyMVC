using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InternationalCurrencyMVC.Models;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace InternationalCurrencyMVC.Controllers
{
    public class RepoController : Controller
    {
        // GET: Repo
        public ActionResult Index([FromServices] CurrencyRepo repo)
        {
           // repo.AddCoin(new Penny());
            return View(repo);
        }


        // GET: Repo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string sAmount,[FromServices]CurrencyRepo repo)
        {
            double dAmount;
            try
            {
                dAmount = Convert.ToDouble(sAmount);          
            }
            catch
            {
                dAmount = 0;
            }
            repo.Coins = CurrencyRepo.CreateChange(dAmount).Coins;
            return RedirectToAction(nameof(Index));
        }

        // GET: Repo/Details/5
        public ActionResult Details(int id,[FromServices] CurrencyRepo repo)
        {
            return View(repo.Coins[id]);
        }

        // GET: Repo/Delete/5
        public ActionResult Delete(string id, [FromServices] CurrencyRepo repo)
        {
            return View((USCoin)repo.Coins.Find(c => c.Name == id));
        }

        // POST: Repo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection, [FromServices] CurrencyRepo repo)
        {
            try
            {
                // TODO: Add delete logic here
                repo.RemoveCoin(repo.Coins.Where(c => c.Name == id).FirstOrDefault());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SaveRepo([FromServices] CurrencyRepo repo)
        {
            IFormatter formatter = new BinaryFormatter();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Stream stream = new FileStream(Path.Combine(docPath,"Repo.txt"), FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, repo);
            stream.Close();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult LoadRepo([FromServices] CurrencyRepo repo)
        {
            IFormatter formatter = new BinaryFormatter();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Stream stream = new FileStream(Path.Combine(docPath, "Repo.txt"), FileMode.Open, FileAccess.Read);
            CurrencyRepo temp = (CurrencyRepo)formatter.Deserialize(stream);
            stream.Close();
            //makes sure that the coins are added to the global repo so that the other window/view model can 
            //see the coins add in this window
            repo.Coins = temp.Coins; 
            //reduce the number of coins when the repo is loaded
            repo.ReduceCoins();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult NewRepo([FromServices] CurrencyRepo repo)
        {
            repo.Coins = new List<ICoin>();
            return RedirectToAction(nameof(Index));
        }

        // GET: Repo/Delete/5
        public ActionResult Add([FromServices] CurrencyRepo repo)
        {
            PopulateCoinTypeList();
            return View(repo);
        }

        // POST: Repo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string id, IFormCollection collection, [FromServices] CurrencyRepo repo)
        {
            try
            {
                string selectedValue = Request.Form["selectedCoinToAdd"];
                switch(selectedValue)
                {
                    case "Penny":
                        repo.AddCoin(new Penny());
                        break;
                    case "Nickel":
                        repo.AddCoin(new Nickel());
                        break;
                    case "Dime":
                        repo.AddCoin(new Dime());
                        break;
                    case "Quarter":
                        repo.AddCoin(new Quarter());
                        break;
                    case "Half Dollar":
                        repo.AddCoin(new HalfDollar());
                        break;
                    case "Dollar Coin":
                        repo.AddCoin(new DollarCoin());
                        break;
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        void PopulateCoinTypeList()
        {
            List<string> types = new List<string>()
            {
                new Penny().Name,
                new Nickel().Name,
                new Dime().Name,
                new Quarter().Name,
                new HalfDollar().Name,
                new DollarCoin().Name
            };
            ViewBag.CoinTypes = types;
            //ViewBag.selectedCoin = types[0];
        }
    }
}
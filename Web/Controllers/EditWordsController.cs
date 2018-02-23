using Anagram.Business;
using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class EditWordsController : Controller
    {

        IWordsService WordsService;
        LogActivity LogActivities;

        public EditWordsController(IWordsService wordsService, IUserLogService usersLogService)
        {
            WordsService = wordsService;
            LogActivities = new LogActivity(usersLogService);
        }

        // GET: EditWords
        public ActionResult Index()
        {
            return View();
        }

        //add word to all words list
        public ActionResult AddWord(String word)
        {
            if (word != null && word.Length > 1)
            {
                try
                {
                    WordsService.AddNewWord(word);
                    ViewBag.Added = true;
                    Task.Run(() => LogActivities.LogWordAdded(word));
                }
                catch
                {
                    ViewBag.Added = false;
                }
            }
            return View("Index");
        }


        //delete word from all words list
        public ActionResult DeleteWord(String word)
        {
            try
            {
                WordsService.DeleteWord(word);
                ViewBag.Deleted = true;
                Task.Run(() => LogActivities.LogWordDeleted(word));
            }
            catch
            {
                ViewBag.Deleted = false;
            }
            return View("Index");
        }

        //update word in all words list
        public ActionResult UpdateWord(String oldWord, String newWord)
        {
            try
            {
                WordsService.UpdateWord(oldWord, newWord);
                ViewBag.Updated = true;
                Task.Run(() => LogActivities.LogWordUpdated(newWord));
            }
            catch
            {
                ViewBag.Updated = false;
            }
            return View("Index");
        }
    }
}
﻿using Implementation.AnagramSolver;
using Implementation.AnagramSolver.Database;
using Implementation.AnagramSolver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Utils;

namespace Web.Controllers
{
    public class EditWordsController : Controller
    {

        WordsService WordsService;
        LogActivity LogActivities;

        public EditWordsController(WordsService wordsService, UserLogService usersLogService)
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
                    LogActivities.LogWordAdded(word);
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
                LogActivities.LogWordDeleted(word);
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
                LogActivities.LogWordUpdated(newWord);
            }
            catch
            {
                ViewBag.Updated = false;
            }
            return View("Index");
        }
    }
}
using Ajax_sample_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax_sample_1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> data = new List<string>() { "alican", "yilmaz", "asp", ".net", "mvc", "calisiyor" };

            Session["my_list"] = data;

            return View();
        }

        [HttpGet]
        public ActionResult Index2()
        {

            List<TodoItem> list = null;

            if (Session["todolist"] != null)
            {
                list = Session["todolist"] as List<TodoItem>;
            }
            else
            {
                list = new List<TodoItem>();
            }

            ViewBag.List = list;

            return View(new TodoItem());
        }

        [HttpPost]
        public PartialViewResult Index2(TodoItem model)
        {
            List<TodoItem> list = null;

            if(Session["todolist"]!=null)
            {
                list=Session["todolist"] as List<TodoItem>;
            }
            else
            {
                list = new List<TodoItem>();
            }
            model.Id = Guid.NewGuid();
            list.Add(model);
            Session["todolist"] = list;

            System.Threading.Thread.Sleep(3000);

            return PartialView("_TodoItemPartialView", model);
        }


        public PartialViewResult LoadData()
        {
            List<string> data = Session["my_list"] as List<string>;  

            System.Threading.Thread.Sleep(3000);  

            return PartialView("_DataListPartialView", data);
        }


        public MvcHtmlString RemoveData(int id)
        {
            List<string> data = Session["my_list"] as List<string>;

            data.RemoveAt(id);

            Session["my_list"] = data;

            System.Threading.Thread.Sleep(3000);  

            return MvcHtmlString.Empty;
        } 
    }
}
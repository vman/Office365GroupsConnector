using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Office365Groups.Connector.Controllers
{
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostMessage(string webHookUrl)
        {
            var client = new RestClient(webHookUrl);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            
            request.RequestFormat = DataFormat.Json;    
            request.AddBody(new
            {
                title = "Outlook Custom Connector Webhooks Demo",
                text = "Message posted from my ASP.NET MVC Appplication",
                themeColor = "DB4C3F"
            });

            var response = client.Execute(request);
            
            var content = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return View("Success");
            }
            else
            {
                return View();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_management.Models;
using Inventory_management.Controllers;

namespace Login.Controllers
{
    public class LoginController : Controller
    {


        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {


            login userModel = new login();
            userModel.status_ = "";
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Inventory_management.Models.login userModel)
        {

            using (inventorymgtEntities dbModel = new inventorymgtEntities())
            {
                var pass = userModel.password_ != null ? userModel.password_.ToString() : "";
                var usrname = userModel.username != null ? userModel.username.ToString(): "";
                if (pass != null && usrname != null)
                {
                    var userDetails = dbModel.users.Where(x => x.email == usrname && x.password_ == pass).FirstOrDefault();

                    if (userDetails != null && userDetails.email != null && userDetails.password_ != null && userDetails.email.Equals("akaamzain@hotmail.com") && userDetails.password_.Equals("1202"))
                    {
                        Session["userID"] = userDetails.regId;
                        Session["user"] = userDetails.fname;
                        Session["occupation"] = userDetails.ocp;

                        return RedirectToAction("Index", "Search");
                    }
                    else if (userDetails == null)
                    {
                        userModel.status_ = "Invalid User Credentials.";

                        return View("Login", userModel);
                    }
                    else
                    {
                        Session["userID"] = userDetails.regId;
                        Session["user"] = userDetails.fname;
                        Session["occupation"] = userDetails.ocp;
                        return View("Welcome");
                    }
                }
                else
                {
                    userModel.status_ = "Invalid User Credentials.";

                    return View("Login", userModel);
                }

            }


        }

        public ActionResult Welcome()
        {
            return View("Welcome");
        }

        public ActionResult LogOut()
        {
            if (Session["userID"] != null)
            {
                int userId = (int)Session["userID"];
                Session.Abandon();
            }
            return View("Login");
        }


    }
}
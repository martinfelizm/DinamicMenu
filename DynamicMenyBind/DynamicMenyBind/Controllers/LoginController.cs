using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DynamicMenyBind.Models;

namespace DynamicMenyBind.Controllers
{
    public class LoginController : Controller
    {
        WebTestContext db = new WebTestContext();
        
        // GET: /Login/
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //var list = from l in db.Login
            //           select new LoginC 
            //           { UsuID=l.UsuID,
            //           UserName=l.UserName,
            //           UserPass=l.UserPass,
            //           RolID=l.RolID};
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModels _login)
        {
            if (ModelState.IsValid) //validating the user inputs  
            {
                bool isExist = false;
                using (WebTestContext _entity = new WebTestContext())  // out Entity name is "SampleMenuMasterDBEntites"  
                {
                    isExist = _entity.Login.Where(x => x.UserName.Trim().ToLower() == _login.UserName.Trim().ToLower()).Any(); //validating the user name in tblLogin table whether the user name is exist or not  
                    if (isExist)
                    {
                        LoginModels _loginCredentials = _entity.Login.Where(x => x.UserName.Trim().ToLower() == _login.UserName.Trim().ToLower()).Select(x => new LoginModels
                        {
                            //string s = _entity.Roles.Where(r => r.RolID==x.RolID).Select(r=>r.RolDescripcion).FirstOrDefault()
                            UserName = x.UserName,
                            RoleName = _entity.Roles.Where(r => r.RolID==x.RolID).Select(r=>r.RolDescripcion).FirstOrDefault(),
                            RolID = x.RolID,
                            UsuID = x.UsuID
                        }).FirstOrDefault();  // Get the login user details and bind it to LoginModels class  
                        List<MenuModels> _menus = _entity.SubMenu.Where(x => x.RolID == _loginCredentials.RolID).Select(x => new MenuModels
                        {
                            MainMenuId = x.MenuID,
                            MainMenuName = _entity.MainMenu.Where(r => r.MenuID == (int?)x.MenuID).Select(r => r.MenuName).FirstOrDefault(),
                            SubMenuId = x.SmID,
                            SubMenuName = x.SmName,
                            ControllerName = x.SmController,
                            ActionName = x.SmAction,
                            RoleId = x.RolID,
                            RoleName = _entity.Roles.Where(r => r.RolID == x.RolID).Select(r => r.RolDescripcion).FirstOrDefault()
                        }).ToList(); //Get the Menu details from entity and bind it in MenuModels list.  

                        FormsAuthentication.SetAuthCookie(_loginCredentials.UserName, false); // set the formauthentication cookie  
                        Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session  
                        Session["MenuMaster"] = _menus; //Bind the _menus list to MenuMaster session  
                        Session["UserName"] = _loginCredentials.UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please enter the valid credentials!...";
                        return View();
                    }
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        } 
	}
}
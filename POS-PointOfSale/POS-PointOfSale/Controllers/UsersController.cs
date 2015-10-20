using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using POS_PointOfSale.Models;
using POS_PointOfSale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace POS_PointOfSale.Controllers
{
    public class UsersController : Controller
    {

        //conectar a la base
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            //
            var usersView = new List<UserView>();
            //recorrer lista
            foreach (var user in users)
            {
                var userView = new UserView
                {
                    EMail = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };
                usersView.Add(userView);
            }
            return View(usersView);
        }
        public ActionResult Roles(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);


            if (user == null)
            {
                return HttpNotFound();
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();

            var rolesView = new List<RoleView>();
            if (user.Roles != null)
            {
                foreach (var item in user.Roles)
                {

                    //nombre del rol
                    var role = roles.Find(r => r.Id == item.RoleId);


                    var roleView = new RoleView
                    {
                        RoleID = role.Id,
                        Name = role.Name
                    };
                    rolesView.Add(roleView);
                }
            }


            var userView = new UserView
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View(userView);
        }

        //GET
        public ActionResult AddRole(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);


            if (user == null)
            {
                return HttpNotFound();
            }
            var userView = new UserView
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id
            };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var lista = (roleManager.Roles.ToList());
            lista.Add(new IdentityRole { Id = "", Name = "[Seleccione un rol]" });
            lista = lista.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(lista, "Id", "Name");

            return View(userView);

        }
        [HttpPost]
        public ActionResult AddRole(string userID, FormCollection form)
        {
            var roleID = Request["RoleID"];
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            var userView = new UserView
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id
            };



            if (string.IsNullOrEmpty(roleID))
            {
                ViewBag.Error = "Tiene que seleccionar un rol";


                var lista = (roleManager.Roles.ToList());
                lista.Add(new IdentityRole { Id = "", Name = "[Seleccione un rol]" });
                lista = lista.OrderBy(r => r.Name).ToList();
                ViewBag.RoleID = new SelectList(lista, "Id", "Name");

                return View(userView);
            }


            var roles = roleManager.Roles.ToList();
            var role = roles.Find(r => r.Id == roleID);

            if (!userManager.IsInRole(userID, role.Name))
            {
                userManager.AddToRole(userID, role.Name);
            }



            var rolesView = new List<RoleView>();
            if (user.Roles != null)
            {
                foreach (var item in user.Roles)
                {

                    //nombre del rol
                    role = roles.Find(r => r.Id == item.RoleId);


                    var roleView = new RoleView
                    {
                        RoleID = role.Id,
                        Name = role.Name
                    };
                    rolesView.Add(roleView);
                }
            }


            userView = new UserView
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };


            return View("Roles", userView);

        }

        public ActionResult Delete(string userID, string roleID)
        {
            if (string.IsNullOrEmpty(userID) || string.IsNullOrEmpty(roleID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.Users.ToList().Find(u => u.Id == userID);
            var role = roleManager.Roles.ToList().Find(r => r.Id == roleID);
            ///borrar usuario del rol
            if (userManager.IsInRole(user.Id, role.Name))
            {
                userManager.RemoveFromRole(user.Id, role.Name);
            }

            ///vista de retorno

            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                //nombre del rol
                role = roles.Find(r => r.Id == item.RoleId);
                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };
                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                EMail = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View("Roles", userView);

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PhotoSharingApplication.Models;

namespace PhotoSharingApplication.Controllers
{
	[Authorize]
    public class AccountController : Controller
    {
		// GET: Account
		[AllowAnonymous]
		public ActionResult Login(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult Login(login model, string returnUrl) {
			if (ModelState.IsValid) {
				if (Membership.ValidateUser(model.UserName, model.Password)) {
					FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
					if (Url.IsLocalUrl(returnUrl)) {
						return Redirect(returnUrl);
					} else {
						return RedirectToAction("Index", "Home");
					}
				} else {
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}
			}

			return View(model);
		}
		public ActionResult LogOff() {
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
		public ActionResult Register() {
			return View();
		}
	}
}
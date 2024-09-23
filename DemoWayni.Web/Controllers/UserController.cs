using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoWayni.Application.Services.Interfaces;
using DemoWayni.Application.ViewModels;

namespace DemoWayni.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var usersDTO = await userService.GetAll();
            return View(usersDTO);
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new Exception();
                }

                var userDTO = await userService.Get(id);

                if (userDTO is null)
                {
                    return Json(new { success = false, message = "El usuario no existe en la base de datos" });
                }

                return Json(new { success = true, data = userDTO });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error. Inténtelo más tarde" });
            }
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Dni")] UserDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userDTO);
                }

                if (await VerifyDni(userDTO.Dni)) return View(userDTO);

                var success = await userService.Create(userDTO);
                if (success)
                {
                    TempData["success"] = "El usuario se guardó exitosamente";
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch (ArgumentNullException ex) { return RedirectToAction(nameof(Index)); }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrió un error. Inténtelo más tarde";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return await GetUser(id, nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Dni")] UserDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(userDTO);
                }

                if (await VerifyDni(userDTO.Dni)) return View(userDTO);

                var success = await userService.Update(userDTO);
                if (success)
                {
                    TempData["success"] = "El usuario se actualizó exitosamente";
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch (ArgumentNullException ex) { return RedirectToAction(nameof(Index)); }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrió un error. Inténtelo más tarde";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: User/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id is null)
                {
                    throw new Exception();
                }
                
                var userDTO = await userService.Get(id);

                if (userDTO is null)
                {
                    return Json(new { success = false, message = "El usuario no existe en la base de datos" });
                }

                var success = await userService.Remove(id.Value);

                if (success)
                {
                    TempData["success"] = "El usuario fue eliminado exitosamnente";
                    return Json(new { success = true, toRedirect = "/User/Index", message = "El usuario fue eliminado exitosamnente" });
                }

                throw new Exception();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Ocurrió un error. Inténtelo más tarde" });
            }
        }

        [NonAction]
        public async Task<IActionResult> GetUser(int? id, string view)
        {
            try
            {
                var userDTO = await userService.Get(id);

                if (userDTO is null)
                {
                    TempData["error"] = "El usuario no existe en la base de datos";
                    return RedirectToAction(nameof(Index));
                }

                return View(view, userDTO);
            }
            catch (ArgumentNullException ex) { return RedirectToAction(nameof(Index)); }
            catch (Exception ex)
            {
                TempData["error"] = "Ocurrió un error. Inténtelo más tarde";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<bool> VerifyDni(string dni)
        {
            var exists = await userService.DniExists(dni);
            if (exists) {
                TempData["error"] = "El DNI ingresado ya existe en la base de datos";
            }

            return exists;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoIdentity.Models;

namespace ProyectoIdentity.Controllers
{
    [Authorize]
    public class CuentasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _roleManager = roleManager;
        }

        // INDEX
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // GET REGISTRO
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Registro(string returnurl = null)
        {
            //Para la creación de roles
            if (!await _roleManager.RoleExistsAsync("Administrador"))
            {
                //Creación del rol Administrador
                await _roleManager.CreateAsync(new IdentityRole("Administrador"));
            }

            //Para la creación de roles
            if (!await _roleManager.RoleExistsAsync("Lider"))
            {
                //Creación del rol Lider
                await _roleManager.CreateAsync(new IdentityRole("Lider"));
            }

            //Para la creación de roles
            if (!await _roleManager.RoleExistsAsync("Colaborador"))
            {
                //Creación del rol Colaborador
                await _roleManager.CreateAsync(new IdentityRole("Colaborador"));
            }

            ViewData["ReturnUrl"] = returnurl;
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }

        // Formulario POST REGISTRO
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid) {
                var usuario = new AppUsuario {
                    UserName = rgViewModel.Email,
                    Email = rgViewModel.Email,
                    Nombre = rgViewModel.Nombre,
                    Url = rgViewModel.Url,
                    CodigoPais = rgViewModel.CodigoPais,
                    Telefono = rgViewModel.Telefono,
                    Pais = rgViewModel.Pais,
                    Ciudad = rgViewModel.Ciudad,
                    Dirección = rgViewModel.Dirección,
                    FechaNacimiento = rgViewModel.FechaNacimiento,
                    Estado = rgViewModel.Estado
                };

                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Password);

                if (resultado.Succeeded)
                {
                    //Asignación Automática del USUARIO a su ROL LIDER
                    await _userManager.AddToRoleAsync(usuario, "Lider");


                    await _singInManager.SignInAsync(usuario, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }
                ValidarErrores(resultado);
            }
            return View(rgViewModel);
        }

        //Error Manager
        [AllowAnonymous]
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors) {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        //Método vista formulario de ACCESO
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Acceso(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        //Formulario ACCESO
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Acceso(AccesoViewModel accViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var resultado = await _singInManager.PasswordSignInAsync(
                    accViewModel.Email, accViewModel.Password, accViewModel.RememberMe, lockoutOnFailure: true);

                if (resultado.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }
                if (resultado.IsLockedOut)
                {
                    return View("Bloqueado");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Acceso inválido");
                    return View(accViewModel);
                }
            }
            return View(accViewModel);
        }

        //Método para cerrar sesión LOGOUT
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> SalirAplicacion()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //Método mostrar Olvido de Contraseña
        [HttpGet]
        [AllowAnonymous]
        public IActionResult OlvidoPassword()
        {
            return View();
        }

        //Método mostrar Acceso Denegado
        [HttpGet]
        [AllowAnonymous]
        public IActionResult denegado(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            return View();
        }

    }
}

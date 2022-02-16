using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using SecSaudeAH.Models.Login;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Controllers
{
    public class HomeController : Controller
    {
        public readonly DBSaudeAHContext _context;
        public IHttpContextAccessor _http { get; set; }

        public HomeController(DBSaudeAHContext context, IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginVM model)
        {


            var user = _context.Profissionais.Include(c => c.Secretaria).Where(c => c.Login.Equals(model.Username.ToLower()) && c.Senha == model.Password);

            if (user.Count() == 0)
            {
                TempData["Erro"] = "Error";
                return RedirectToAction("Index");
            }
            else
            {
                var createCookies = new CreateCookies(_http);
                await createCookies.Autenticar(user.First());

                var logado = _context.Profissionais.FirstOrDefault(c => c.Id == user.First().Id);
                logado.LastLogin = DateTime.Now;
                _context.Update(logado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home", new { area = "SecSaude" });
            }

            return RedirectToAction("Index");
        }

        public IActionResult ConfirmarEmail()
        {


            return View();
        }

        public IActionResult Cadastro()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(LoginVM model)
        {
            var profi = new Profissional { Login = model.Login, Nome = model.Nome, Tipo = 1, Senha = "123", SecretariaId = 1, Email = $"{model.Login}@com.br", Telefone = "(62) 9 0000-0000", Funcao = "Administrativo" };
            _context.Add(profi);
            _context.SaveChanges();

            return RedirectToAction("Cadastro");
        }


        //[HttpPost]
        //public IActionResult ConfirmarEmail(LoginVM model)
        //{
        //    var random = new Random();
        //    int randomNumber = random.Next(1000, 9999);

        //    SmtpClient smtp = new SmtpClient("mail.devroyale.com", 8889);
        //    smtp.EnableSsl = false;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new NetworkCredential("postmaster@devroyale.com", "Deusemais@100");
        //    var msg = new MailMessage();
        //    msg.To.Add(model.Email);
        //    msg.From = new MailAddress("postmaster@devroyale.com", "nao-responder@dataSecSaudeAH.com");

        //    msg.Subject = "Redefinir senha.";
        //    msg.Body = $"Seu código de verificação é <b>{randomNumber}</b> <br>Use-o para redefinir sua senha no sistema de gestão SecSaudeAHlogica.";
        //    msg.IsBodyHtml = true;
        //    smtp.Send(msg);

        //    ViewData["Email"] = model.Email;

        //    var reset = new ResetSenha()
        //    {
        //        Email = model.Email,
        //        Numero = randomNumber
        //    };
        //    _context.Add(reset);
        //    _context.SaveChanges();

        //    return RedirectToAction(nameof(RedefinirSenha));
        //}

        //public IActionResult RedefinirSenha()
        //{

        //    return View();
        //}

        //public bool ValidaEmail(string email)
        //{
        //    var emails = _context.Usuarios.Where(c => c.IsAtivo && c.Email != null).Select(c => c.Email);

        //    return emails.Contains(email);

        //}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}

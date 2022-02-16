
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;

namespace SecSaudeAH.Models.Login
{
    public  class CreateCookies
    {
        public IHttpContextAccessor _http { get; set; }

        public CreateCookies(IHttpContextAccessor http)
        {
            _http = http;
        }

        public async Task<Profissional> Autenticar(Profissional user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Nome),
                new Claim(ClaimTypes.Role, user.Tipo.ToString()),
                new Claim("Endereco", user.Secretaria.Endereco),
                new Claim("Consultorio", user.Secretaria.Nome),
                new Claim("Email", user.Email),
                new Claim("Tipo", user.Tipo.ToString()),
                new Claim("ClinicaId", user.SecretariaId.ToString()),
                new Claim("Img",  user.Extensao != null ? $"{user.Id}_{user.Extensao}": ""),
                new Claim("Especialidade", user.Funcao ?? ""),                
                new Claim("Telefone", user.Secretaria.Telefone ?? "")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(120),
                AllowRefresh = true
            };

            await _http.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);

            return user;

        }
    }
}

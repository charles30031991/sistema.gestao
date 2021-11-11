using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Sistema.Gestao.API.Controllers
{
    public class ControladorBase : ControllerBase
    {
        protected int IdUsuarioLogado => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        protected string NomeUsuarioLogado => User.FindFirst(ClaimTypes.Name).Value;
    }
}

using Microsoft.AspNetCore.Mvc;
using System;

namespace ModelagemDeDominiosRicos.WebAPI.Controllers
{
    public abstract class BaseController : Controller
    {
        // Atributo usado para simular o ID que viria pela claim do JWT
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
    }
}

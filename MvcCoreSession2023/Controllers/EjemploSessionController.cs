﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreSession2023.Helpers;
using MvcCoreSession2023.Models;

namespace MvcCoreSession2023.Controllers
{
    public class EjemploSessionController : Controller
    {
        private int numero = 1;

        public IActionResult EjemploSimple()
        {
            ViewData["NUMERO"] = this.numero;
            return View();
        }

        [HttpPost]
        public IActionResult EjemploSimple(string accion, string usuario)
        {
            //PREGUNTAMOS SI QUEREMOS GUARDAR DATOS DE SESSION
            if (accion.ToLower() == "almacenar")
            {
                this.numero += 1;
                //GUARDAMOS LOS DATOS EN SESSION
                HttpContext.Session.SetString("NUMERO", numero.ToString());
                HttpContext.Session.SetString("USUARIO", usuario);
                HttpContext.Session.SetString("HORA", DateTime.Now.ToLongTimeString());
                ViewData["MENSAJE"] = "Datos almacenados en Session";
            }else if (accion.ToLower() == "mostrar")
            {
                //RECUPERAMOS LOS DATOS DE SESSION
                ViewData["NUMERO"] = HttpContext.Session.GetString("NUMERO");
                ViewData["USUARIO"] = HttpContext.Session.GetString("USUARIO");
                ViewData["HORA"] = HttpContext.Session.GetString("HORA");
            }
            return View();
        }

        public IActionResult SessionPersonas()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SessionPersonas(Persona persona)
        {
            //CUANDO PULSE UN BOTON GUARDAMOS UNA PERSONA
            HttpContext.Session.SetObject("PERSONA", persona);
            ViewData["MENSAJE"] = "Persona almacenada en Session";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1Rest.Models;
using Test1Rest.Models.Personas;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1Rest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public string ListaPersonas()
        {
            LeerPersonas servicio = new LeerPersonas();
            List<Persona> lista = new List<Persona>();
            string json;
            try
            {
                foreach (var item in servicio.ListaPersonas())
                {
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                Respuesta respuesta = new Respuesta
                {
                    CodError = 500,
                    Error = "True",
                    Mensaje = error
                };
                json = JsonConvert.SerializeObject(respuesta);

                return json;
            }
            json = JsonConvert.SerializeObject(lista);

            return json;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}/{tipoPersona}")]
        public string PersonaById(int id, int tipoPersona)
        {
            string json;
            if (tipoPersona != 1)
            {
                Respuesta respuesta = new Respuesta
                {
                    CodError = 403,
                    Error = "True",
                    Mensaje = "Acceso Prohibido"
                };

                json = JsonConvert.SerializeObject(respuesta);

                return json;
            }
            LeerPersonaById servicio = new LeerPersonaById(id);
            Persona persona = new Persona();
            
            persona = servicio.GetPersonaById();

            if(persona.Nombre == null)
            {
                Respuesta respuesta = new Respuesta
                {
                    CodError = 404,
                    Error = "True",
                    Mensaje = "Esa persona no existe"
                };
                json = JsonConvert.SerializeObject(respuesta);
                return json;
            }
            else
            {
                json = JsonConvert.SerializeObject(persona);
                return json;
            }

            
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

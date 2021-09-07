using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RpgMvc.Models;   


namespace RpgMvc.Controllers
{
    public class PersonagemHabilidadesController : Controller
    {
        public string uriBase = "http://MN-RPG.somee.com/RpgApi/PersonagemHabilidades/";
        
        [HttpGet("PersonagemHabilidades/{id}")]
        public async Task<ActionResult> IndexAsync(int id)
        {
            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString());

            string serialized = await response.Content.ReadAsStringAsync();

            List<PersonagemHabilidadeViewModel> lista = await Task.Run(() =>
            JsonConvert.DeserializeObject<List<PersonagemHabilidadeViewModel>>(serialized));

            return View(lista);
        }

        [HttpGet]
        public async Task<ActionResult> DeleteAsync(int habilidadeId, int personagemId)
        {
            HttpClient httpClient = new HttpClient();
            string uriComplentar = "DeletePersonagemHabilidade";

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            PersonagemHabilidadeViewModel ph = new PersonagemHabilidadeViewModel();
            ph.HabilidadeId = habilidadeId;
            ph.PersonagemId = personagemId;

            var content = new StringContent(JsonConvert.SerializeObject(ph));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplentar, content);

            string serialized = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            TempData["Mensagem"] = serialized;
            else
            TempData["MensagemErro"] = serialized;

            return RedirectToAction("Index", "Personagens");
        }

        [HttpGet]
        public async Task<ActionResult> Create(int id, string nome)
        {
            string uriComplentar = "GetHabilidades";
            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplentar);

            string serialized = await response.Content.ReadAsStringAsync();
            List<HabilidadeViewModel> habilidades = await Task.Run(() => 
            JsonConvert.DeserializeObject<List<HabilidadeViewModel>>(serialized));

            ViewBag.ListaHabilidades = habilidades;

            PersonagemHabilidadeViewModel ph = new PersonagemHabilidadeViewModel();
            ph.Personagem = new PersonagemViewModel();
            ph.Habilidade = new HabilidadeViewModel();
            ph.PersonagemId = id;
            ph.Personagem.Nome = nome;

            return View(ph);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(PersonagemHabilidadeViewModel ph)
        {
            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = new StringContent(JsonConvert.SerializeObject(ph));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBase, content);

            string serialized = await response.Content.ReadAsStringAsync();

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            TempData["Mensagem"] = "Habilidade cadastrada com sucesso";
            else 
            TempData["MensagemErro"] = serialized;

            return RedirectToAction("Index", "PersonagemHabilidades", new {id = ph.PersonagemId});
        }
    }
}
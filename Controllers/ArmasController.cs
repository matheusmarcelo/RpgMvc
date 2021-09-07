

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;

namespace RpgMvc.Controllers
{
    public class ArmasController : Controller
    {
        public string uriBaseArma = "http://MN-RPG.somee.com/RpgApi/Armas/";


        public async Task<IActionResult> IndexAsync()
        {
            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBaseArma);

            string serialized = await response.Content.ReadAsStringAsync();

            List<ArmaViewModel> listaArmas = await Task.Run(() =>
                JsonConvert.DeserializeObject<List<ArmaViewModel>>(serialized));

            return View(listaArmas);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string uriBuscaPersonagens = "http://MN-RPG.somee.com/RpgApi/Personagem/GetAll";
            HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);
            string serialized = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<PersonagemViewModel> listaPersonagens = await Task.Run(() =>
                    JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized));
                ViewBag.ListaPersonagens = listaPersonagens;
            }
            else
                TempData["MensagemErro"] = serialized;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(ArmaViewModel a)
        {
            HttpClient httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(a));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uriBaseArma, content);

            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] = string.Format("Arma {0} salva com sucesso!", a.Nome);

                await Task.Run(() =>
                JsonConvert.DeserializeObject<List<ArmaViewModel>>(serialized));
            }
            else
                TempData["MensagemErro"] = serialized;


            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> DetailsAsync(int id)
        {
            string uriComplementar = string.Format("{0}", id);

            HttpClient httpClient = new HttpClient();

            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await httpClient.GetAsync(uriBaseArma + uriComplementar);

            string serialized = await response.Content.ReadAsStringAsync();

            ArmaViewModel a = await Task.Run(() =>
                JsonConvert.DeserializeObject<ArmaViewModel>(serialized));

            return View(a);
        }


        public async Task<ActionResult> EditAsync(int id)
        {
            HttpClient httpClient = new HttpClient();

            //Busca de Personagens
            string token = HttpContext.Session.GetString("SessionTokenUsuario");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string uriBuscaPersonagens = "http://MN-RPG.somee.com/RpgApi/Personagem/GetAll";
            HttpResponseMessage responsePersonagem = await httpClient.GetAsync(uriBuscaPersonagens);

            string serializedPersonagem = await responsePersonagem.Content.ReadAsStringAsync();

            if (responsePersonagem.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<PersonagemViewModel> listaPersonagens = await Task.Run(() =>
                    JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serializedPersonagem));

                ViewBag.ListaPersonagens = listaPersonagens;
            }
            else
                TempData["MensagemErro"] = serializedPersonagem;
            //Fim da busca de Personagens


            HttpResponseMessage response = await httpClient.GetAsync(uriBaseArma + id.ToString());

            string serialized = await response.Content.ReadAsStringAsync();

            ArmaViewModel a = await Task.Run(() =>
                JsonConvert.DeserializeObject<ArmaViewModel>(serialized));

            return View(a);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(ArmaViewModel a)
        {
            HttpClient httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(a));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uriBaseArma, content);

            TempData["Mensagem"] = string.Format("Arma {0} atualizada com sucesso!", a.Nome);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.DeleteAsync(uriBaseArma + id.ToString());
            string serialized = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["Mensagem"] = string.Format("Arma {0} deletada com sucesso!", id);
            }
            else
                TempData["MensagemErro"] = serialized;


            return RedirectToAction("Index");
        }
    }
}
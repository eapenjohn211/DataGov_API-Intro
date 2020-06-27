using DataGov_API_Intro.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace DataGov_API_Intro.Controllers
{
  public class HomeController : Controller
  {
    HttpClient httpClient;

    static string BASE_URL = "https://developer.nps.gov/api/v1/";
    static string API_KEY = "mdBybOievMdeX3eYSC0MhFu3U7xRV18xHAPG04qb"; //Add your API key here inside ""

    // Obtaining the API key is easy. The same key should be usable across the entire
    // data.gov developer network, i.e. all data sources on data.gov.
    // https://www.nps.gov/subjects/developer/get-started.htm

    public IActionResult Index()
    //this is you are making a reqest to the API, like a browser would. Remove all headers, add the key, then we can accept JSON.
    {
      httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
      httpClient.DefaultRequestHeaders.Accept.Add(
          new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

      string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
      string parksData = "";

      Parks parks = null;

      httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);
        //get me a response by making a request to the API's endpoint. This can take some time.
      try
      {
        HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
          parksData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        if (!parksData.Equals(""))
        {
          // JsonConvert is part of the NewtonSoft.Json Nuget package
          parks = JsonConvert.DeserializeObject<Parks>(parksData);
        }
      }
      catch (Exception e)
      {
        // This is a useful place to insert a breakpoint and observe the error message
        Console.WriteLine(e.Message);
      }

      return View(parks);
    }
  }
}

//paste JSON as classes under edit, professor blew past this part and I still don't know how to do this.


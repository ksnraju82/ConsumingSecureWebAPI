using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MVCWebAPIUsingSecureToken.Models;
using System.Web.Http;
using System.Configuration;
using MVCWebAPIUsingSecureToken.HelperClass;

namespace MVCWebAPIUsingSecureToken.Controllers
{
    public class CinemaWorldMoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            //To reuse the method across multiple databases (like CinemaWorl movies and Filmworld movies), i have created
            //seperate class and reusing the method across controllers.
            var response = GetAPIResponse.GetRequest(ConfigurationManager.AppSettings.GetValues("token")[0].ToString(), ConfigurationManager.AppSettings.GetValues("baseurl")[0].ToString(), ConfigurationManager.AppSettings.GetValues("GetapiCinemaWorldPath")[0].ToString());

            if (response != "")
            {                
                var Movies = (AllMovies)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(AllMovies));
                
                List<Movie> MovieList = Movies.Movies.ToList<Movie>();

                return View(MovieList);
            }
            else
                return View("Error");            
        }

        //Instead of creating a new view of the search results i am using the same view with post action verb.
        [HttpPost]
        public ActionResult Index(string strSearchElement)
        {
            strSearchElement = Convert.ToString(Request["txtSearch"].ToString());

            //To reuse the method across multiple databases (like CinemaWorl movies and Filmworld movies), i have created
            //seperate class and reusing the method across controllers.
            var response = GetAPIResponse.GetRequest(ConfigurationManager.AppSettings.GetValues("token")[0].ToString(), ConfigurationManager.AppSettings.GetValues("baseurl")[0].ToString(), ConfigurationManager.AppSettings.GetValues("GetapiCinemaWorldPath")[0].ToString());

            if (response != "")
            {
                //Since the response from webAPI is an array of objects, i got to create a new class in models folder
                //with list<Movie> property and transforming the result.
                var Movies = (AllMovies)Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof(AllMovies));

                //To pass Movie model to the view, i am converting the array to list and passing the model to view.
                List<Movie> MovieList = Movies.Movies.ToList<Movie>();

                //Fetching the entire list and filter with ID from the text box.
                if (!String.IsNullOrEmpty(strSearchElement))
                    MovieList = MovieList.FindAll(s => s.ID.Contains(strSearchElement));

                return View(MovieList);
            } 
            else
                return View("Error");       
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OMDB_Excercise.Models
{
    public class MovieSearchDAL
    {
        public MovieModel GetMovieSearch(string title)
        {
            string url = $"http://www.omdbapi.com/?apikey=8b5e20ef&t={title}";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);

            return result;
        }
    }
}

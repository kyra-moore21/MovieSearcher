using System.Net;
using Newtonsoft.Json;

namespace SearchingOMDB.Models
{
    public class MovieDAL
    {
        public static MovieModel GetMovie(string title) //Adjust
        {
            //adjust
            //setup
            string url = $"http://www.omdbapi.com/?apikey={Secret.apiKey}&t={title}";

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //adjust
            //Convert to c#
            //Install Newtonsoft.json
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }

        public static SearchModel SearchMovies(string title)
        {
            //adjust
            //setup
            string url = $"http://www.omdbapi.com/?apikey={Secret.apiKey}&s={title}";

            //request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //adjust
            //Convert to c#
            //Install Newtonsoft.json
            SearchModel result = JsonConvert.DeserializeObject<SearchModel>(JSON);
            return result;
        }
    }
}

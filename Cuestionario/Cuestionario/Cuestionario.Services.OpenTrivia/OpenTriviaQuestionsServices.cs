using Cuestionario.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cuestionario.Services.OpenTrivia
{
    public class OpenTriviaQuestionsServices
    {
        public OpenTriviaQuestionsServices(){}

        static HttpClient client = new HttpClient();

        public async Task<RootObject> GetQuestionsAsync(string pPath)
        //public static async Task<RootObject> GetQuestionsAsync(string pPath)
        {
            RootObject question = null;
            HttpResponseMessage response = await client.GetAsync(pPath);
            if (response.IsSuccessStatusCode)
            {
                question = await response.Content.ReadAsAsync<RootObject>();
            }

            return question;
        }
    }
}

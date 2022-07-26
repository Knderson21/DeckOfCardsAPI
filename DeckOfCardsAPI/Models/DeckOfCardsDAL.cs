using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsAPI.Models
{
    public class DeckOfCardsDAL
    {
        public DeckOfCardsModel GetCards() //*** <--ADJUST--
        {
            //***
            //api url <--ADJUST--
            string key = "abvhmcuehcer"; //this API Key should be hidden
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);

            //capture response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();


            //***
            //convert string of JSON into a C# object <--ADJUST--
            DeckOfCardsModel result = JsonConvert.DeserializeObject<DeckOfCardsModel>(JSON);
            return result;
        }

        public void ShuffleCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/abvhmcuehcer/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace TopTrumpsGame
{
    public class TopTrumpsGame
    {
        static TopTrumpsClient topTrumpsClient;
        static TopTrumpsGame()
        {
            topTrumpsClient = new TopTrumpsClient(new Uri("http://localhost:4000"));
        }

        public ITopTrumpsResponse RegisterPlayer(ref TopTrumpsPlayer topTrumpsPlayer)
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.PostRegisterAsync(topTrumpsPlayer).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    RegisterResponse registerResponse = JsonConvert.DeserializeObject<RegisterResponse>(response);
                    topTrumpsPlayer.playerid = registerResponse.playerId;
                    topTrumpsPlayer.cards.Clear();
                    foreach (Card card in registerResponse.cards)
                    {
                        topTrumpsPlayer.cards.Add(card);
                    }
                    topTrumpsResponse = registerResponse;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }

        public ITopTrumpsResponse GetProfile(ref TopTrumpsPlayer topTrumpsPlayer)
        {

            HttpResponseMessage httpResponseMessage = topTrumpsClient.GetProfileAsync(topTrumpsPlayer.playerid).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    PlayerDetails playerDetails = JsonConvert.DeserializeObject<PlayerDetails>(response);
                    topTrumpsPlayer.playerdetails = playerDetails;
                    topTrumpsResponse = playerDetails;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }
        public ITopTrumpsResponse BuyCard(ref TopTrumpsPlayer topTrumpsPlayer)
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.GetBuyCardAsync(topTrumpsPlayer.playerid).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    Card card = JsonConvert.DeserializeObject<Card>(response);
                    topTrumpsResponse = card;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }
        public ITopTrumpsResponse ListCards(ref TopTrumpsPlayer topTrumpsPlayer)
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.GetCardsAsync(topTrumpsPlayer.playerid).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    ListCardsResponse listCardsResponse = JsonConvert.DeserializeObject<ListCardsResponse>(response);
                    topTrumpsPlayer.cards.Clear();
                    foreach(Card card in listCardsResponse)
                    {
                        topTrumpsPlayer.cards.Add(card);
                    }
                    topTrumpsResponse = listCardsResponse;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }
        public ITopTrumpsResponse GetNextCard(TopTrumpsPlayer topTrumpsPlayer)
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.GetNextCardAsync(topTrumpsPlayer.playerid).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    Card card = JsonConvert.DeserializeObject<Card>(response);
                    topTrumpsResponse = card;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }
        public ITopTrumpsResponse Battle(TopTrumpsPlayer topTrumpsPlayer, Characteristic characteristic)
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.PostBattleAsync(topTrumpsPlayer.playerid, characteristic).Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            ITopTrumpsResponse topTrumpsResponse = null;
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    ErrorResponse errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response);
                    topTrumpsResponse = errorResponse;
                    break;
                case HttpStatusCode.OK:
                    BattleResponse battleResponse = JsonConvert.DeserializeObject<BattleResponse>(response);
                    topTrumpsResponse = battleResponse;
                    break;
                default:
                    break;
            }
            return topTrumpsResponse;
        }

        public bool Ping()
        {
            HttpResponseMessage httpResponseMessage = topTrumpsClient.GetPingAsync().Result;
            string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            PingResponse pingResponse = JsonConvert.DeserializeObject<PingResponse>(response);
            if (pingResponse.status == "OK")
                return true;
            else
                return false;
        }
    }

}

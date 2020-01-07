using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TopTrumpsGame
{
    public class TopTrumpsClient
    {
        HttpClient httpClient;
        public TopTrumpsClient(Uri baseAddress)
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = baseAddress;
        }
        public Task<HttpResponseMessage> GetPingAsync()
        {
            return httpClient.GetAsync("ping");
        }
        public Task<HttpResponseMessage> PostRegisterAsync(TopTrumpsPlayer player)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "register");
            message.Content = new StringContent(JsonConvert.SerializeObject(player.playerdetails), Encoding.UTF8, "application/json");
            return httpClient.SendAsync(message);
        }
        public Task<HttpResponseMessage> GetProfileAsync(string playerId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "profile");
            message.Headers.Add("playerid", playerId);
            return httpClient.SendAsync(message);
        }
        public Task<HttpResponseMessage> GetBuyCardAsync(string playerId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "buy-card");
            message.Headers.Add("playerid", playerId);
            return httpClient.SendAsync(message);
        }
        public Task<HttpResponseMessage> GetNextCardAsync(string playerId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "next-card");
            message.Headers.Add("playerid", playerId);
            return httpClient.SendAsync(message);
        }
        public Task<HttpResponseMessage> PostBattleAsync(string playerId, Characteristic characteristic)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "battle");
            message.Headers.Add("playerid", playerId);
            message.Content = new StringContent(JsonConvert.SerializeObject(new { field = characteristic.ToString() }), Encoding.UTF8, "application/json");
            return httpClient.SendAsync(message);
        }
        public Task<HttpResponseMessage> GetCardsAsync(string playerId)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "cards");
            message.Headers.Add("playerid", playerId);
            return httpClient.SendAsync(message);
        }

    }
    public class TopTrumpsPlayer
    {
        public TopTrumpsPlayer(string userName, string eMail, string birthDate)
        {
            playerdetails.username = userName;
            playerdetails.email = eMail;
            playerdetails.birthdate = birthDate;
        }
        public PlayerDetails playerdetails = new PlayerDetails();
        public string playerid;
        public BindingList<Card> cards = new BindingList<Card>();
        public override string ToString()
        {
            return playerdetails.username;
        }
    }

    public class Card : ITopTrumpsResponse {
        public string id;
        public string name { get; set; }
        public string strength { get; set; }
        public string skill { get; set; }
        public string size { get; set; }
        public string popularity { get; set; }
    }

    public interface ITopTrumpsResponse { }

    public class PlayerDetails : ITopTrumpsResponse
    {
        public string username;
        public string birthdate;
        public string email;
    }

    public class RegisterResponse : ITopTrumpsResponse
    {
        public string playerId;
        public BindingList<Card> cards;
    }

    public class ErrorResponse : ITopTrumpsResponse
    {
        public string errorCode;
        public string message;
    }

    public class BattleResponse : ITopTrumpsResponse
    {
        public string outcome;
        public Card card;
        public Card opponentCard;
    }
    public class PingResponse : ITopTrumpsResponse
    {
        public string status;
    }
    public class ListCardsResponse :  BindingList<Card>, ITopTrumpsResponse
    {
        
    }
    public enum Characteristic { strength, skill, size, popularity }
}

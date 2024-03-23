using OpenAI_API;
using OpenAI_API.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GenCode
{
    public class GenCode
    {
        IOpenAIAPI api;
        string? _API_KEY;
        private static string Lang = "C#";
        /// <summary>
        /// Initializes a new instance of the <see cref="GenCode"/> class.
        /// </summary>
        /// <param name="API_KEY">The API key for OpenAI (optional).</param>
        /// <param name="ApiUrlFormat">The API URL format (optional).</param>
        public GenCode(string? API_KEY=null,string ApiUrlFormat= "https://api.openai.com/{0}/openai")
         : this(new APIAuthentication(API_KEY), ApiUrlFormat)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GenCode"/> class.
        /// </summary>
        /// <param name="API_KEY">The API key for OpenAI (optional).</param>
        /// <param name="ApiUrlFormat">The API URL format (optional).</param>
        public GenCode(APIAuthentication? API_KEY = null, string ApiUrlFormat = "https://api.openai.com/{0}/{1}")
        {
            _API_KEY = API_KEY.ApiKey;
            api = string.IsNullOrWhiteSpace(_API_KEY) ? new OpenAI_API.OpenAIAPI() : new OpenAI_API.OpenAIAPI(API_KEY);
            api.ApiUrlFormat = ApiUrlFormat;
        }
        


        ///**
        // * if X is true
        // * fill object properties
        // * fill collection properties
        // **/
        //public async Task main()
        //{
        //    Task<ChatResult> result =  api.Chat.CreateChatCompletionAsync(");
        //    Console.WriteLine(result);
        //}
        private string Construct<TObject>(TObject myObject,bool isDeep)
        {
            Type myType = myObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            string ret=string.Empty;
            foreach (var propItem in props)
            {
                ret += "\n" + propItem.Name+" "+ propItem.PropertyType.Name;
                if (isDeep)
                {
                    //Todo
                }
            }
            return ret;
        }
        /// <summary>
        /// Generates a response from the OpenAI API based on user input, object properties.
        /// </summary>
        /// <typeparam name="TObject">The type of the object containing properties to be used in the request.</typeparam>
        /// <typeparam name="TCollection">The type of the collection containing properties to be used in the request.</typeparam>
        /// <param name="userMessage">The user's input message.</param>
        /// <param name="obj">The object containing properties to be used in the request.</param>
        /// <param name="images">The optional array of image inputs for the request.</param>
        /// <returns>A <see cref="ChatResult"/> containing the generated response.</returns>

        public async Task<TObject> FillObject<TObject>(string userMessage, TObject obj)//, params ChatMessage.ImageInput[] images , TCollection
        {
            // Perform any necessary actions based on the input parameters (obj and collection)
            // For example, you can serialize the object and collection properties and include them in the chat message.
            

            var systemMessage = new ChatMessage()
            {
                Role = ChatMessageRole.FromString("system"),
                Content = "Context: You are acting as API that only returns a JSON response with a specific template. at root of the JSON response there should by only and only properties of object. The json to be serialized as C# class with properties "+Construct<TObject>(obj,false)+"\n\n"+ Newtonsoft.Json.JsonConvert.SerializeObject(obj),
                // Add any properties or metadata related to the object and collection here.
            };
            // Create a chat message with the user's input and the serialized object/collection properties.
            var chatMessage = new ChatMessage()
            {
                Role = ChatMessageRole.FromString("user"),
                Content = userMessage,
                // Add any properties or metadata related to the object and collection here.
            };

            // Send the chat message to the API and get the response.
            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest { Messages = new List<ChatMessage> { systemMessage,chatMessage } });
            ChatChoice chatChoice = result.Choices.FirstOrDefault();
            Tuple<bool?, string> apiResponseAsJson = getJson(chatChoice);
            if (apiResponseAsJson.Item1??false)
            {
                //apiResponseAsJson
            }
            return obj;
        }
        private Tuple<bool?,string> getJson(ChatChoice chatChoice)
        {
            return new Tuple<bool?, string>(null, null);
        }
    }
}

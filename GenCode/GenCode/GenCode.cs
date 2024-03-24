using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using static OpenAI.ObjectModels.Models;

namespace GenCode
{
    public class GenCode
    {
        OpenAIService api;
        string? _API_KEY;
        private static string Lang = "C#";
        private static string Model = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="GenCode"/> class.
        /// </summary>
        /// <param name="API_KEY">The API key for OpenAI (optional).Keep in Envionment variable.</param>
        /*/// <param name="ApiUrlFormat">The API URL format (optional).</param>*/
        public GenCode(string? API_KEY = null,string? model=null)//, string ApiUrlFormat = "https://api.openai.com/{0}/{1}"
        {
            _API_KEY = API_KEY;
            api = string.IsNullOrWhiteSpace(_API_KEY) ? new OpenAIService(new OpenAiOptions()) : new OpenAIService(new OpenAiOptions()
            {
                ApiKey = API_KEY
            });
            //api. = ApiUrlFormat;
            //var openAiService = ;
            Model = model ?? Models.Gpt_3_5_Turbo;

            api.SetDefaultModelId(Model);
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
        private string Construct<TObject>(bool isDeep)
        {
            Type myType = typeof(TObject);
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
        /// <param name="userMessage">The user's input message.</param>
        /// <param name="obj">The object containing properties to be used in the request.</param>        
        /// <returns>A <see cref="ChatResult"/> containing the generated response.</returns>

        public async Task<TObject> FillObject<TObject>(string userMessage, TObject obj)
        {
            // Perform any necessary actions based on the input parameters (obj and collection)
            // For example, you can serialize the object and collection properties and include them in the chat message.
            var completionResult = await api.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                        {
                    ChatMessage.FromSystem("Note:Incase of no modification return Empty Response;Context: You are acting as API that only returns a JSON response with a specific template. at root of the JSON response there should by only and only properties of object. The json to be serialized as C# class with properties "+Construct<TObject>(false)+"\n\n"+ Newtonsoft.Json.JsonConvert.SerializeObject(obj)),
                    ChatMessage.FromUser(userMessage)
                        },
                Model = Model,
                //MaxTokens = 50//optional
            });
            if (completionResult.Successful)
            {
                Tuple<bool?, string> apiResponseAsJson = getJson(completionResult.Choices.First().Message.Content);
                if (apiResponseAsJson.Item1 ?? false)
                {
                    var data= Newtonsoft.Json.JsonConvert.DeserializeObject<TObject>( apiResponseAsJson.Item2);
                    return data;
                }
            }
            return default(TObject);
        }

        /// <summary>
        /// Generates a response from the OpenAI API based on user input, collection properties.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection containing properties to be used in the request.</typeparam>
        /// <param name="userMessage">The user's input message.</param>
        /// <param name="collection">The collection containing properties to be used in the request.</param>        
        /// <returns>A collection of <see cref="ChatResult"/> containing the generated responses.</returns>
        public async Task<IEnumerable<TCollection>> FillCollection<TCollection>(string userMessage, IEnumerable<TCollection> collection)
        {
            // Perform any necessary actions based on the input parameters (collection)
            // For example, you can serialize the collection properties and include them in the chat message.
            var completionResult = await api.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
        {
            ChatMessage.FromSystem("Note:In case of no modification return Empty Response;Context: You are acting as API that only returns a JSON response with this specific template.return same json collection with instructed modification. The json to be serialized as C# list of a class, class with properties "+Construct<TCollection>(false)+"\n\n"+ Newtonsoft.Json.JsonConvert.SerializeObject(collection)),
            ChatMessage.FromUser(userMessage)
        },
                Model = Model,
                //MaxTokens = 50//optional
            });

            if (completionResult.Successful)
            {
                var responses = new List<TCollection>();
                foreach (var choice in completionResult.Choices)
                {
                    Tuple<bool?, string> apiResponseAsJson = getJson(choice.Message.Content);
                    if (apiResponseAsJson.Item1 ?? false)
                    {
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TCollection>>(apiResponseAsJson.Item2);
                        responses.AddRange(data);
                    }
                }
                return responses;
            }

            return Enumerable.Empty<TCollection>();
        }

        private Tuple<bool?,string> getJson(string? strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return new Tuple<bool?, string>(false, null);  }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return new Tuple<bool?, string>(true, strInput);
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    //Console.WriteLine(jex.Message);
                    return new Tuple<bool?, string>(false, strInput);
                }
                catch (Exception ex) //some other exception
                {
                    //Console.WriteLine(ex.ToString());
                    return new Tuple<bool?, string>(false, strInput);
                    
                }
            }
            else
            {
                return new Tuple<bool?, string>(false, strInput);
            }
        }
    }
}

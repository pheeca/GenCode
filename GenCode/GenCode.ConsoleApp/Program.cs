// See https://aka.ms/new-console-template for more information
using GenCode.ConsoleApp;

using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using System;
using System.Reflection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //// Story 1
        //var story1 = new Story
        //{
        //    Id = 1,
        //    Title = "The Lost Treasure",
        //    Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
        //    CreatedAt = DateTime.Now.AddDays(-30),
        //    UpdatedAt = DateTime.Now.AddDays(-15)
        //};
        //var gencode = new GenCode.GenCode(Environment.GetEnvironmentVariable("DefaultLLM_API_KEY"));
        //Story result = gencode.FillObject<Story>("Update Description to be more datailed", story1).Result;
        //Console.WriteLine(result.Description);


        //string apiKey = Environment.GetEnvironmentVariable("DefaultLLM_API_KEY");

        //// Story 1
        //var story1 = new Story
        //{
        //    Id = 1,
        //    Title = "The Lost Treasure",
        //    Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
        //    CreatedAt = DateTime.Now.AddDays(-30),
        //    UpdatedAt = DateTime.Now.AddDays(-15)
        //};
        //var gencode = new GenCode.GenCode(apiKey);
        //Story result = gencode.FillObject<Story>("how are you feeling", story1).Result;


        // Story 1
        var story1 = new Story
        {
            Id = 1,
            Title = "The Lost Treasure",
            Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
            CreatedAt = DateTime.Now.AddDays(-30),
            UpdatedAt = DateTime.Now.AddDays(-15)
        };
        var story2 = new Story
        {
            Id = 2,
            Title = "The Treasure planet",
            Description = "A futuristic reimagining of Robert Louis Stevenson's classic 'Treasure Island' set in space.",
            CreatedAt = DateTime.Now.AddDays(-70),
            UpdatedAt = DateTime.Now.AddDays(-13)
        };
        var stories = new List<Story>() { story1 , story2 };
        var gencode = new GenCode.GenCode(Environment.GetEnvironmentVariable("DefaultLLM_API_KEY"));
        List<Story> result = gencode.FillCollection<Story>("Update Description to be more datailed", stories.AsEnumerable()).Result.ToList();
        foreach (var resultItem in result)
        {
            Console.WriteLine(resultItem.Description);
        }

    }
}
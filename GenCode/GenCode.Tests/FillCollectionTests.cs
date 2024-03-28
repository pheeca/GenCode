using GenCode;
using GenCode.Tests.Entities;
using NUnit.Framework;

namespace GenCode.Tests
{
    public class FillCollectionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        
    
        [Test]
        public void BasicRun()
        {
            string apiKey = Environment.GetEnvironmentVariable("DefaultLLM_API_KEY");
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
            var stories = new List<Story>() { story1, story2 };
            var gencode = new GenCode(apiKey);
            List<Story> results = gencode.FillCollection<Story>("Update Description to be more datailed", stories.AsEnumerable()).Result.ToList();

            Assert.That(results.Count, Is.EqualTo(stories.Count));
            Story result = results[0];
            Assert.That(results, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Id, Is.EqualTo(story1.Id));
            Assert.That(result.Title, Is.EqualTo(story1.Title));
            Assert.That(result.Title, Is.Not.Null);
            Assert.That(result.CreatedAt, Is.EqualTo(story1.CreatedAt));
            Assert.That(result.CreatedAt, Is.Not.Null);
            Assert.That(result.UpdatedAt, Is.EqualTo(story1.UpdatedAt));
            Assert.That(result.UpdatedAt, Is.Not.Null);
            Assert.That(result.Description, Is.Not.EqualTo(story1.Description));
            Assert.That(result.Description, Is.Not.Null);
            Assert.That(result.Description.Length, Is.GreaterThan(story1.Description.Length));
            result = results[1];
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Id, Is.EqualTo(story2.Id));
            Assert.That(result.Title, Is.EqualTo(story2.Title));
            Assert.That(result.Title, Is.Not.Null);
            Assert.That(result.CreatedAt, Is.EqualTo(story2.CreatedAt));
            Assert.That(result.CreatedAt, Is.Not.Null);
            Assert.That(result.UpdatedAt, Is.EqualTo(story2.UpdatedAt));
            Assert.That(result.UpdatedAt, Is.Not.Null);
            Assert.That(result.Description, Is.Not.EqualTo(story2.Description));
            Assert.That(result.Description, Is.Not.Null);
            Assert.That(result.Description.Length, Is.GreaterThan(story2.Description.Length));

            Assert.Pass();
        }
        
    }
}
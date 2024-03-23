using GenCode;
using GenCode.Tests.Entities;
using NUnit.Framework;

namespace GenCode.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            string apiKey = Environment.GetEnvironmentVariable("API_KEY");

            // Story 1
            var story1 = new Story
            {
                Id = 1,
                Title = "The Lost Treasure",
                Description = "A group of adventurers embarks on a journey to find a lost treasure hidden deep within a mysterious jungle.",
                CreatedAt = DateTime.Now.AddDays(-30),
                UpdatedAt = DateTime.Now.AddDays(-15)
            };
            var gencode = new GenCode(apiKey, "https://api.deepinfra.com/v1/openai");
            Story result =gencode.FillObject<Story>("Update Description to be more datailed", story1).Result;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Id, Is.EqualTo(story1.Id));
            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(story1.Title));
            Assert.That(result.Title, Is.Not.Null);
            Assert.That(result.CreatedAt, Is.EqualTo(story1.CreatedAt));
            Assert.That(result.CreatedAt, Is.Not.Null);
            Assert.That(result.UpdatedAt, Is.EqualTo(story1.UpdatedAt));
            Assert.That(result.UpdatedAt, Is.Not.Null);
            Assert.That(result.Description, Is.Not.EqualTo(story1.Description));
            Assert.That(result.Description, Is.Not.Null);
            Assert.That(result.Description.Length, Is.GreaterThan(story1.Description.Length));

            Assert.Pass();
        }
    }
}
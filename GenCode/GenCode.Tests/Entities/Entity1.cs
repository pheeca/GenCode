using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenCode.Tests.Entities
{
    internal class Story
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public void DisplayStoryDetails()
        {
            Console.WriteLine($"Story Id: {this.Id}");
            Console.WriteLine($"Title: {this.Title}");
            Console.WriteLine($"Description: {this.Description}");
            Console.WriteLine($"Created At: {this.CreatedAt}");
            Console.WriteLine($"Updated At: {(this.UpdatedAt.HasValue ? this.UpdatedAt.ToString() : "Not updated yet")}");
            Console.WriteLine();
        }
    }
}

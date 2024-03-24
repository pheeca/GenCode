using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenCode.ConsoleApp
{
    internal class Story
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

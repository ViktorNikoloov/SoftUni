using System;
using Xunit;

namespace Sis.MvcFramework.Tests
{
    public class SisViewEngineTests
    {
        [Fact]
        public void Test1()
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2021, 05, 10),
                Name = "Doggo Arghentino",
                Price = 12345.67M,

            };

            string view = @"";
        }
    }

    public class TestViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}

using System;
using System.IO;

using Xunit;

using SIS.MvcFramework.ViewEngine;
using System.Collections.Generic;

namespace Sis.MvcFramework.Tests
{
    public class SisViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseForForeach")]
        [InlineData("ViewModel")]

        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2021, 05, 10),
                Name = "Doggo Arghentino",
                Price = 12345.67M,
            };

            IViewEngine viewEngine = new SisViewEngine();

            var view = File.ReadAllText($"ViewTests/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel);
            var expectedResult = File.ReadAllText($"ViewTests/{fileName}.Result.html");

            Assert.Equal(expectedResult, result);
        }

        [Fact]

        public void TestTemplateViewModel()
        {
            IViewEngine viewEngine = new SisViewEngine();

            var actualResult = viewEngine.GetHtml(@"@foreach(var num in Model)
{
<span>@num</span>
}", new List<int> { 1, 2, 3 });
            var expectedResult = @"<span>1</span>
<span>2</span>
<span>3</span>";
            Assert.Equal(expectedResult, actualResult);
        }
    }
}

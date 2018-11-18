using System.Collections.Generic;
using System.Linq;
using bugTracker.Core.DTO.Helpers;
using bugTracker.Core.DTO.ViewModels;
using bugTracker.Core.Entities;
using Xunit;
using Xunit.Abstractions;

namespace bugTracker.Core.Tests
{
    public class BookServiceTests
    {
        private readonly ITestOutputHelper output;

         public BookServiceTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void BugService_GetBookById_ReturnsOneBook()
        {
            // What is this test even testing?
            
            // Arrange
            var idForTest = 1;
            var dbBook = GetTestBookById(idForTest);
            var testViewModel = GetBugViewModels()
                    .FirstOrDefault(b => b.Id == idForTest);
            // Act
            var viewModel = BugViewModelHelpers.ConvertToViewModel(dbBook);
            
            // Assert
            Assert.Equal(testViewModel.Title, viewModel.Title);
            Assert.Equal(testViewModel.Description, viewModel.Description);
        }

        private Bug GetTestBookById(int id)
        {
            return GetTestBugs().FirstOrDefault(b => b.Id == id);
        }
        
        private List<Bug> GetTestBugs()
        {
            var mockData = new List<Bug>();
            mockData.Add(new Bug
            {
                Id = 1,
                Title = "The first in a list",
                Description = "There _may_ be multiple bugs in this list"
            });

            return mockData;
        }

        private List<BugViewModel> GetBugViewModels()
        {
            var viewModels = new List<BugViewModel>();
            viewModels.Add(new BugViewModel
            {
                Id = 1,
                Title = "Test bug",
                Description = "Just like Tom's post on MySpace, this is a test"
            });

            return viewModels;
        }
    }
}
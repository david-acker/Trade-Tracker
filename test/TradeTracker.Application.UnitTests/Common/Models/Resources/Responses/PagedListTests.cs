using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using TradeTracker.Application.Common.Models.Resources.Responses;
using Xunit;

namespace TradeTracker.Application.UnitTests.Common.Models.Resources.Responses
{
    public class PagedListTests
    {
        [Theory]
        [MemberData(nameof(PagedListTestTestData.CreateFromListData),
            MemberType = typeof(PagedListTestTestData))]
        public void Create_FromList_ReturnsCorrectRepresentation(
            List<string> items,
            int pageNumber,
            int pageSize,
            ExpectedPagedListRepresentation<string> expectedRepresentation)
        {
            // Act
            var pagedList = PagedList<string>.Create(items, pageNumber, pageSize);

            // Assert
            using (new AssertionScope())
            {
                pagedList.CurrentPage.Should()
                    .Be(expectedRepresentation.CurrentPage);

                pagedList.TotalPages.Should()
                    .Be(expectedRepresentation.TotalPages);

                pagedList.PageSize.Should()
                    .Be(expectedRepresentation.PageSize);

                pagedList.TotalCount.Should()
                    .Be(expectedRepresentation.TotalCount);
 
                pagedList.HasPrevious.Should()
                    .Be(expectedRepresentation.HasPrevious);
                
                pagedList.HasNext.Should()
                    .Be(expectedRepresentation.HasNext);
                
                pagedList.Should()
                    .BeEquivalentTo(expectedRepresentation.Items);
            }
        }
    }
}
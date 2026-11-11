using BackgroundVerification.API.Controllers;
using BackgroundVerification.API.Models;
using BackgroundVerification.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BackgroundVerification.Tests
{
    public class VerificationControllerTests
    {
        private readonly Mock<IVerificationService> _mockService;
        private readonly VerificationController _controller;

        public VerificationControllerTests()
        {
            _mockService = new Mock<IVerificationService>();
            _controller = new VerificationController(_mockService.Object);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenRecordDoesNotExist()
        {
            // Arrange
            _mockService.Setup(s => s.GetVerificationByIdAsync(99)).ReturnsAsync((VerificationRequest?)null);

            // Act
            var result = await _controller.GetById(99);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAtAction_WhenValid()
        {
            // Arrange
            var candidate = new Candidate { FirstName = "John", LastName = "Doe", Email = "john@example.com" };
            var expectedRequest = new VerificationRequest { VerificationId = 1, CandidateId = 1, Status = "Pending" };
            _mockService.Setup(s => s.CreateVerificationAsync(candidate)).ReturnsAsync(expectedRequest);

            // Act
            var result = await _controller.Create(candidate);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(1, ((VerificationRequest)createdResult.Value!).VerificationId);
        }
    }
}
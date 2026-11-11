using BackgroundVerification.API.Models;
using BackgroundVerification.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundVerification.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerificationController : ControllerBase
    {
        private readonly IVerificationService _verificationService;

        public VerificationController(IVerificationService verificationService)
        {
            _verificationService = verificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requests = await _verificationService.GetAllVerificationsAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = await _verificationService.GetVerificationByIdAsync(id);
            if (request == null) return NotFound(new { message = $"Verification request with ID {id} not found." });
            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _verificationService.CreateVerificationAsync(candidate);
            return CreatedAtAction(nameof(GetById), new { id = result.VerificationId }, result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] StatusUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Status)) return BadRequest(new { message = "Status cannot be empty." });

            var success = await _verificationService.UpdateStatusAsync(id, dto.Status, dto.Comments ?? "");
            if (!success) return NotFound(new { message = "Verification record not found." });

            return NoContent();
        }
    }

    public class StatusUpdateDto
    {
        public string Status { get; set; } = string.Empty;
        public string? Comments { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace BackgroundVerification.API.Models
{
    public class VerificationRequest
    {
        [Key]
        public int VerificationId { get; set; }

        public int CandidateId { get; set; }
        public Candidate? Candidate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending, InProgress, Approved, Rejected

        public string? AssignedAgent { get; set; }
        public string? Comments { get; set; }
        public DateTime SubmittedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
    }
}
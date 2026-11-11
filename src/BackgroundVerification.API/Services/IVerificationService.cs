using BackgroundVerification.API.Models;

namespace BackgroundVerification.API.Services
{
    public interface IVerificationService
    {
        Task<IEnumerable<VerificationRequest>> GetAllVerificationsAsync();
        Task<VerificationRequest?> GetVerificationByIdAsync(int id);
        Task<VerificationRequest> CreateVerificationAsync(Candidate candidate);
        Task<bool> UpdateStatusAsync(int id, string status, string comments);
    }
}
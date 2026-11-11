using BackgroundVerification.API.Data;
using BackgroundVerification.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundVerification.API.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly AppDbContext _context;

        public VerificationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VerificationRequest>> GetAllVerificationsAsync()
        {
            return await _context.VerificationRequests.Include(v => v.Candidate).ToListAsync();
        }

        public async Task<VerificationRequest?> GetVerificationByIdAsync(int id)
        {
            return await _context.VerificationRequests.Include(v => v.Candidate)
                .FirstOrDefaultAsync(v => v.VerificationId == id);
        }

        public async Task<VerificationRequest> CreateVerificationAsync(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            var request = new VerificationRequest
            {
                CandidateId = candidate.CandidateId,
                Status = "Pending",
                SubmittedDate = DateTime.UtcNow
            };

            _context.VerificationRequests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<bool> UpdateStatusAsync(int id, string status, string comments)
        {
            var request = await _context.VerificationRequests.FindAsync(id);
            if (request == null) return false;

            request.Status = status;
            request.Comments = comments;
            request.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
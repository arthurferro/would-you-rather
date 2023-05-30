using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }

    }
}
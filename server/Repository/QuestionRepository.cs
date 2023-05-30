using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuestionContext _context;

        public QuestionRepository(QuestionContext context)
        {
            _context = context;
        }

        public void AddQuestion(Question question)
        {
            _context.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            _context.Remove(question);
        }



        public async Task<Question> FindQuestion(int id)
        {
            return await _context.Questions.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetRandomQuestion()
        {
            var randomQuestion = _context.Questions.FromSql<Question>($"SELECT TOP 1 * FROM [dbWouldYouRather].[dbo].[Questions] ORDER BY NEWID()");
            return await randomQuestion.FirstOrDefaultAsync();
        }

        public void updateQuestion(Question question)
        {
            _context.Update(question);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
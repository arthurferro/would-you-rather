using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Repository
{
    public interface IQuestionRepository
    {
        public Task<IEnumerable<Question>> GetQuestions();
        public Task<Question> FindQuestion(int id);
        public Task<Question> GetRandomQuestion();
        public void AddQuestion(Question question);
        public void updateQuestion(Question question);
        public void DeleteQuestion(Question question);
        public Task<bool> SaveChangesAsync();
    }
}
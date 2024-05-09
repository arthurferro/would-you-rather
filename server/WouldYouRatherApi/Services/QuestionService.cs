using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WouldYouRatherApi.Models;

namespace WouldYouRatherApi.Services
{
    public class QuestionService
    {
        private readonly IMongoCollection<Question> _questionCollections;

        public QuestionService(IOptions<WouldYouRatherDatabaseSettings> questionDatabaseSettings)
        {
            var mongoClient = new MongoClient(questionDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(questionDatabaseSettings.Value.DatabaseName);

            _questionCollections = mongoDatabase.GetCollection<Question>(questionDatabaseSettings.Value.CollectionName);
        }

        public async Task<Question?> GetAsync(string id) =>
            await _questionCollections.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Question newQuestion) =>
            await _questionCollections.InsertOneAsync(newQuestion);

        public async Task UpdateAsync(string id, Question updatedQuestion) =>
            await _questionCollections.ReplaceOneAsync(x => x.Id == id, updatedQuestion);

        public async Task RemoveAsync(string id) =>
            await _questionCollections.DeleteOneAsync(x => x.Id == id);

        public async Task<Question> GetRandomQuestion()
        {
            var question = await _questionCollections
                .Find(_ => true)
                .Limit(1)
                .ToListAsync();
            return question[0];
        }
    }
}
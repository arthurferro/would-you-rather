using MongoDB.Bson.Serialization.Attributes;

namespace WouldYouRatherApi.Models
{
    public class Question
    {
        public Question(string firstQuestion, string secondQuestion)
        {
            FirstQuestion = firstQuestion;
            SecondQuestion = secondQuestion;
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        public int FirstQuestionVotes { get; private set; } = 0;
        public int SecondQuestionVotes { get; private set; } = 0;
        public int TotalVotes
        {
            get
            {
                return FirstQuestionVotes + SecondQuestionVotes;
            }
        }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public object CalculateVotes()
        {
            var firstQuestionPercentage = Math.Round((double)(FirstQuestionVotes * 100 / TotalVotes));
            var secondQuestionPercentage = Math.Round((double)(SecondQuestionVotes * 100 / TotalVotes));
            return new { firstQuestionPercentage, secondQuestionPercentage };
        }

        public void AddVote(int option)
        {
            if (option == 1)
                FirstQuestionVotes++;
            else
                SecondQuestionVotes++;
        }
    }
}
namespace server.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string FirstOption { get; set; }
        public string SecondOption { get; set; }
        public int FirstOptionCount { get; set; } = 0;
        public int SecondOptionCount { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Question(string firstOption, string secondOption)
        {
            FirstOption = firstOption;
            SecondOption = secondOption;
        }

        public object CalculatePercentage()
        {
            var total = FirstOptionCount + SecondOptionCount;
            var firstOptionPercentage = ((double)FirstOptionCount / (double)total) * 100;
            var secondOptionPercentage = ((double)SecondOptionCount / (double)total) * 100;
            return new { firstOptionPercentage = Math.Round(firstOptionPercentage), secondOptionPercentage = Math.Round(secondOptionPercentage) };
        }
    }

}
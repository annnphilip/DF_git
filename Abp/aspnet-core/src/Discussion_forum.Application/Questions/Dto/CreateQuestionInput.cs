using Abp.AutoMapper;


namespace Discussion_forum.Questions.Dto
{
    [AutoMapTo(typeof(QuestionDetails))]
    public class CreateQuestionInput
    {
        public string QuestionsText { get; set; }
        public int TopicId { get; set; }

    }
}
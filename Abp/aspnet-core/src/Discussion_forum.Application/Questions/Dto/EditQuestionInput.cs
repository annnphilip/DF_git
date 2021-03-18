using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions.Dto
{
    [AutoMapTo(typeof(QuestionDetails))]
    public class EditQuestionInput : IEntityDto
    {
        public int Id { get; set; }
        public string QuestionsText { get; set; }
        public int TopicId { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions.Dto
{
    [AutoMapFrom(typeof(QuestionDetails))]
    public class QuestionOutputDto : IEntityDto
    {
       
        public string QuestionsText { get; set; }
        public DateTime CreationTime { get ; set ; }
        public string TopicName { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }

        public int Id { get ; set ; }
    }
}

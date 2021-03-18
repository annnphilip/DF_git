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
    public class QuestionListDto : IEntityDto
    {
        public int Id { get ; set ; }
        public string QuestionsText { get; set; }
        public int TopicId { get; set; }
        public long CreatorUserId { get; set ; }
        public DateTime CreationTime { get ; set ; }
        public long LastModifierUserId { get ; set ; }
        public DateTime LastModificationTime { get ; set ; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer.Dto
{
    [AutoMapFrom(typeof(AnswerDetails))]
    public class AnswerListDto : IEntityDto
    {
        public int Id { get ; set ; }
        public string AnswerText { get; set; }
        public int QuestionId { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long LastModifierUserId { get; set; }
        public DateTime LastModificationTime { get; set; }
    }
}

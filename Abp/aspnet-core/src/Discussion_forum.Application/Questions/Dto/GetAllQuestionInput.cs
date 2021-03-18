using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions.Dto
{
    [AutoMapTo(typeof(QuestionDetails))]
    public class GetAllQuestionInput
    {
        public int Id { get; set; }
    }
}

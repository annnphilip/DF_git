using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer.Dto
{
    [AutoMapTo(typeof(AnswerDetails))]
    public class GetAllAnswerInput
    {
        public int Id { get; set; }
    }
}

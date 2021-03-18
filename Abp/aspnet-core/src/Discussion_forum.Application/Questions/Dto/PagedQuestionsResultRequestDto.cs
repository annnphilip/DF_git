using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions.Dto
{
    public class PagedQuestionsResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }

    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer.Dto
{
    public class PagedAnswersResultInputDto : PagedResultRequestDto
    {
        public int QuestId { get; set; }
        public string Keyword { get; set; }

    }
}

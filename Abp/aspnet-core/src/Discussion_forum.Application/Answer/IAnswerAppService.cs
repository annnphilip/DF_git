using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Discussion_forum.Answer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer
{
    public interface IAnswerAppService : IApplicationService
    {
        Task DeleteAnswer(GetAllAnswerInput input);
        void UpdateAnswer(EditAnswerInput input);
        Task<ListResultDto<AnswerListDto>> GetAllAnswerByID(GetAllAnswerInput input);
        Task<ListResultDto<AnswerListDto>> GetAllAnswer();
        void CreateAnswer(CreateAnswerInput input);
        PagedResultDto<AnswerOutputDto> GetPaginatedAnswers(PagedAnswersResultInputDto input);

    }
}

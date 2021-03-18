using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Discussion_forum.Questions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions
{
    public interface IQuestionAppService : IApplicationService
    {
        Task InsertQuest(CreateQuestionInput input);
        Task DeleteQuestion(GetAllQuestionInput input);
        void UpdateQuestion(EditQuestionInput input);
        Task<ListResultDto<QuestionOutputDto>> GetAllQuestionByID(GetAllQuestionInput input);
        Task<ListResultDto<QuestionListDto>> GetAllQuestion();

        Task<ListResultDto<QuestionOutputDto>> GetAllQuestion_Name();
        //Task CreateQuestion(CreateQuestionInput input);
        PagedResultDto<QuestionOutputDto> GetPaginatedQuestions(PagedQuestionsResultRequestDto input);

    }
}

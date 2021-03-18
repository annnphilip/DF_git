using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Discussion_forum.Answer.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer
{
    public class AnswerAppService : Discussion_forumAppServiceBase, IAnswerAppService
    {
        private readonly IRepository<AnswerDetails> _answerRepository;

        public AnswerAppService(IRepository<AnswerDetails> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async void CreateAnswer(CreateAnswerInput input)
        {
            var Ans = new AnswerDetails
            {
                AnswerText = input.AnswerText,
                QuestionId = input.QuestionId
            };
            await _answerRepository.InsertAsync(Ans);
        }

        public async Task DeleteAnswer(GetAllAnswerInput input)
        {
            await _answerRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<AnswerListDto>> GetAllAnswer()
        {
            var ans = await _answerRepository.GetAllListAsync();
            return new ListResultDto<AnswerListDto>(ObjectMapper.Map<List<AnswerListDto>>(ans));
        }

        public async Task<ListResultDto<AnswerListDto>> GetAllAnswerByID(GetAllAnswerInput input)
        {
            var m = await _answerRepository.GetAll()
                .Where(t => t.Id == input.Id)
                .ToListAsync();
            var ansdto = ObjectMapper.Map<List<AnswerListDto>>(m);
            return new ListResultDto<AnswerListDto>(ansdto);
        }

        public PagedResultDto<AnswerOutputDto> GetPaginatedAnswers(PagedAnswersResultInputDto input)
        {
            var keyword = !input.Keyword.IsNullOrEmpty() ? input.Keyword : "";
            var ans = _answerRepository
            .GetAll()
            .Include(p => p.CreatorUser)
            .Where(p=> p.QuestionId == input.QuestId                )
            .WhereIf(
                !input.Keyword.IsNullOrEmpty(),
                p => p.AnswerText.Contains(input.Keyword)
                || p.CreatorUser.UserName.Contains(input.Keyword)
            )
            .Select(t => new AnswerOutputDto
            {
                Id = t.Id,
                AnswerText= t.AnswerText,
                CreationTime = t.CreationTime,
                PostedBy = t.CreatorUser.UserName,
                PostedById=t.CreatorUser.Id,
                QuestId =t.QuestionId
            });

            var pagedResult = ans.OrderByDescending(p => p.Id)
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount)
             .ToList();
            var totalcount = ans.Count();
            //var questmapped = ObjectMapper.Map<List<QuestionOutputDto>>(pagedResult);
            return new PagedResultDto<AnswerOutputDto>(totalcount, pagedResult);
        }

        public void UpdateAnswer(EditAnswerInput input)
        {
            var quest = _answerRepository.Get(input.Id);
            ObjectMapper.Map(input, quest);
        }

    }
}

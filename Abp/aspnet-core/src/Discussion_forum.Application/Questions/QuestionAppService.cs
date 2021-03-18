using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Discussion_forum.Questions.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions
{
    public class QuestionAppService : Discussion_forumAppServiceBase, IQuestionAppService
    {
        private readonly IRepository<QuestionDetails> _questionRepository;

        public QuestionAppService(IRepository<QuestionDetails> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task DeleteQuestion(GetAllQuestionInput input)
        {
            await _questionRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<QuestionListDto>> GetAllQuestion()
        {
            var quest = await _questionRepository.GetAllListAsync();
            return new ListResultDto<QuestionListDto>(ObjectMapper.Map<List<QuestionListDto>>(quest));
        }

        //public async Task<ListResultDto<CreateQuestionOutput>> GetAllQuestion_Name()
        //{
        //    var quest = _questionRepository.GetAll().Include(q => q.Topic);//.Include(q => q.CreatorUser);
        //    return await Task.FromResult(result: new ListResultDto<CreateQuestionOutput>(ObjectMapper.Map<List<CreateQuestionOutput>>(quest)));
        //}

        public async Task<ListResultDto<QuestionOutputDto>> GetAllQuestionByID(GetAllQuestionInput input)
        {
            var m = await _questionRepository.GetAll()
                .Where(t => t.Id == input.Id)
                .Select(t => new QuestionOutputDto
                {
                    Id = t.Id,
                    QuestionsText = t.QuestionsText,
                    CreationTime = t.CreationTime,
                    TopicName = t.Topic.TopicName,
                    UserName = t.CreatorUser.UserName
                })
                .ToListAsync();

            var questdto = ObjectMapper.Map<List<QuestionOutputDto>>(m);
            return new ListResultDto<QuestionOutputDto>(questdto);
        }

        public async Task InsertQuest(CreateQuestionInput input)
        {
            var quest = new QuestionDetails
            {
                QuestionsText = input.QuestionsText,
                TopicId = input.TopicId
            };
            await _questionRepository.InsertAsync(quest);

        }

        public void UpdateQuestion(EditQuestionInput input)
        {
            var quest = _questionRepository.Get(input.Id);
            ObjectMapper.Map(input, quest);
        }

        public PagedResultDto<QuestionOutputDto> GetPaginatedQuestions(PagedQuestionsResultRequestDto input)
        {
            var quest = _questionRepository
            .GetAll()
            .Include(p=>p.Topic)
            .Include(p=>p.CreatorUser)
            .WhereIf(
                !input.Keyword.IsNullOrEmpty(),
                p => p.QuestionsText.Contains(input.Keyword)    
                || p.Topic.TopicName.Contains(input.Keyword)
                || p.CreatorUser.UserName.Contains(input.Keyword)
            )
            .Select(t=> new QuestionOutputDto
            {
                Id = t.Id,
                QuestionsText = t.QuestionsText,
                CreationTime = t.CreationTime,
                TopicName = t.Topic.TopicName,
                UserName = t.CreatorUser.UserName,
                UserId=t.CreatorUser.Id
            }); 

            var pagedResult = quest.OrderByDescending(p => p.Id)
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount)
             .ToList();
            var totalcount = quest.Count();
            //var questmapped = ObjectMapper.Map<List<QuestionOutputDto>>(pagedResult);
            return new PagedResultDto<QuestionOutputDto>(totalcount, pagedResult);
        }



        public Task<ListResultDto<QuestionOutputDto>> GetAllQuestion_Name()
        {
            throw new NotImplementedException();
        }
    }
}

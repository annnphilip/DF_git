using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Discussion_forum.Topic.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Extensions;
using Abp.Collections.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;

namespace Discussion_forum.Topic
{
    public class TopicAppService : Discussion_forumAppServiceBase, ITopicAppService
    {
        private readonly IRepository<TopicDetails> _topicRepository;

        public TopicAppService(IRepository<TopicDetails> topicRepository)
        {
            _topicRepository = topicRepository;
        }


        public void CreateTopic(CreateTopicInput input)
        {
            //var topic = new TopicDetails
            //{
            //    TopicName = input.TopicName
            //};
            var topic = ObjectMapper.Map<TopicDetails>(input);
            _topicRepository.Insert(topic);
        }

        public void UpdateTopic(EditTopicInput input)
        {
            var topic = _topicRepository.Get(input.Id);
            ObjectMapper.Map(input, topic);
        }

        public async Task<ListResultDto<TopicListDto>> GetAll(GetAllTopicInput input)
        {
            var m = await _topicRepository.GetAll()
                .Where( t => t.Id == input.Id)
                //.WhereIf(!input.TopicName.IsNullOrEmpty(), t => t.TopicName == input.TopicName)
                .ToListAsync();

            var topicdto = ObjectMapper.Map<List<TopicListDto>>(m);
            Console.Write("topicdto");
            Console.Write(topicdto);
            return new ListResultDto<TopicListDto>(topicdto);
        }

        public async Task<ListResultDto<TopicListDto>> GetAllTopics()
        {
            var topics = await _topicRepository.GetAllListAsync();
            return new ListResultDto<TopicListDto>(ObjectMapper.Map<List<TopicListDto>>(topics));
        }

        public async Task DeleteTopic(TopicListDto input)
        {
            await _topicRepository.DeleteAsync(input.Id);
        }
    }
}

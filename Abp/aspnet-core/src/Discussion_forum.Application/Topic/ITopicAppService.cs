using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Discussion_forum.Topic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Topic
{
    public interface ITopicAppService: IApplicationService
    {
        Task DeleteTopic(TopicListDto input);
        void UpdateTopic(EditTopicInput input);
        Task<ListResultDto<TopicListDto>> GetAll(GetAllTopicInput input);
        Task<ListResultDto<TopicListDto>> GetAllTopics();
        void CreateTopic(CreateTopicInput input);
    }
}

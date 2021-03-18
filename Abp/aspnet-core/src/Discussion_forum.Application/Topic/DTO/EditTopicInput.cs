using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Topic.DTO
{
    [AutoMapTo(typeof(TopicDetails))]
    public class EditTopicInput : IEntityDto
    {
        public int Id { get; set; }

        public string TopicName { get; set; }
    }
}

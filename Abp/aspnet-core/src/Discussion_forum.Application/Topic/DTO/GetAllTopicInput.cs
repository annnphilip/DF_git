using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Topic
{
    [AutoMapTo(typeof(TopicDetails))]
    public class GetAllTopicInput //:IEntityDto
    {
        //public string TopicName { get; set; }
        public int Id { get; set; }
    }

}

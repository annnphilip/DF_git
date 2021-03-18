using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Discussion_forum.Topic
{
    [AutoMapFrom(typeof(TopicDetails))] 
    public class TopicListDto : IEntityDto
    {
        public int Id { get; set; }
        public string TopicName { get; set; }

    }
}
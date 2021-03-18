using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Topic.DTO
{
    [AutoMapTo(typeof(TopicDetails))]
    public class CreateTopicInput
    {
            [Required]
            [StringLength(30, MinimumLength = 3)]
            public string TopicName { get; set; }

    }
}

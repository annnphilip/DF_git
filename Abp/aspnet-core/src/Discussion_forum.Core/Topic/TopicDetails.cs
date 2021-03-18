using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Topic
{
    [Table("Topic")]
    public class TopicDetails:Entity
    {
       // public int TopicDetailsId { get; set; }

        public string TopicName { get; set; }
    }
}

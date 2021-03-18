using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Discussion_forum.Authorization.Users;
using Discussion_forum.Topic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Questions
{
    [Table("Question")]
    public class QuestionDetails: Entity, IAudited
    {
        public string QuestionsText { get; set; }
        public TopicDetails Topic { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}

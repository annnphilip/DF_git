using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Discussion_forum.Authorization.Users;
using Discussion_forum.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discussion_forum.Answer
{
    [Table("Answer")]
    public class AnswerDetails : Entity, IAudited
    {
        [Required]
        public QuestionDetails Question { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string AnswerText { get; set; }

        public long? CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        public User CreatorUser { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}

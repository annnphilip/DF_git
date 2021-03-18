using System.ComponentModel.DataAnnotations;

namespace Discussion_forum.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace HOW.Selenium.WebApp.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Each Request needs a Title")]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }

        [Required(ErrorMessage = "Each Request needs a Priority")]
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}

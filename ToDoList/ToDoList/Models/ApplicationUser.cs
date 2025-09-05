namespace ToDoList.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsAdmin { get; set; } = false;
    }
}

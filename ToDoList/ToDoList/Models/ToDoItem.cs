namespace ToDoList.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public bool IsCompleted { get; set; } = false;

        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}

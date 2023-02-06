namespace ToDoListBlazor.Models
{
    public class Task
    {
        public int id { get; set; }
        public string description { get; set; }
        public bool isCompleted { get; set; }
        public int toDoListId { get; set; }
    }
}

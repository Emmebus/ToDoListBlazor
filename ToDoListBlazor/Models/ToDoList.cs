namespace ToDoListBlazor.Models
{
    public class ToDoList
    {
        public int id { get; set; }
        public string title { get; set; }
        public Task[] tasks { get; set; }
    }
}

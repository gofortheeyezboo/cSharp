using System.ComponentModel.DataAnnotations;
using taskMasterinC_.Models;

namespace taskMasterinC_.Models
{
  
  public class ToDoList
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }

  //this will be used to get ToDoTasks by ToDoListId
  public class ToDoTaskByListViewModel : ToDoList
  {
    public int ToDoTaskByListId { get; set; }

  }

}
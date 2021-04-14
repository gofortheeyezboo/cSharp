using System.ComponentModel.DataAnnotations;
using taskMasterinC_.Models;

namespace taskMasterinC_.Models
{
  
  public class ToDoTask
  {
    public int Id { get; set; }
    public string Body { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}
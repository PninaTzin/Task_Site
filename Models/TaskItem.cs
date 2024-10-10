using System;
using System.Collections.Generic;

namespace Web_Api_Project.Models
{
   public class TaskItem 
   {
    public int TaskId { get; set; }
    public string Description { get; set;}
    public bool Status { get; set; }
    public int UserId { get; set; }
   } 
}

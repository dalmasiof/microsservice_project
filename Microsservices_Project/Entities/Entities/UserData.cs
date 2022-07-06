using System;
using System.ComponentModel.DataAnnotations;

public class UserData
{
   
    public long id { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public DateTime birthDate { get; set; }
    public string email { get; set; }

	
}

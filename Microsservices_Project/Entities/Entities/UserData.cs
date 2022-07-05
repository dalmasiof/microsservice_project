using System;
using System.ComponentModel.DataAnnotations;

public class UserData
{
   
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }

	
}

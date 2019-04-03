
using System;

public class Patient
{
    public Patient()
    {
        Identifiable = Guid.NewGuid().ToString();
        CreateDate = DateTime.Now;
    }

    public Patient(string firtName, string lastName, string phone, string email, string gender, string notes)
    {
        Identifiable = Guid.NewGuid().ToString();
        CreateDate = DateTime.Now;
        FirtName = firtName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Gender = gender;
        Notes = notes;
    }

    public string Identifiable { get; set; }
    public string FirtName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string Notes { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LasUpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
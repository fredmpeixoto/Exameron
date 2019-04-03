using Exameron;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

public partial class Account_Manage : System.Web.UI.Page
{
    protected string SuccessMessage
    {
        get;
        private set;
    }

    protected bool Show
    {
        get;
        private set;
    }

    protected bool ShowAdd
    {
        get; set;
    }

    private bool HasPassword(UserManager manager)
    {
        var user = manager.FindById(User.Identity.GetUserId());
        return (user != null && user.PasswordHash != null);
    }

    protected void Page_Load()
    {


        if (!IsPostBack)
        {

            Show = true;

            btnAdd.Visible = true;
            btnUpdate.Visible = false;

        }
        else
        {
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
        }
    }

    protected void CrudPatient_Click(object serder, EventArgs e)
    {
        try
        {
            Save(firtName.Text, lastName.Text, phone.Text, email.Text, gender.Text, note.Text);
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    private void Save(string firtName, string lastName, string phone, string email, string gender, string notes)
    {
        try
        {
            lastName = Encrypter(lastName);
            var patient = new Patient(firtName, lastName, phone, email, gender, notes);
            var record = LoadPatient();
            record.Add(patient);
            RecordXML(record);
            Response.Redirect("~/Patients/PatientList");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private void RecordXML(List<Patient> ListaEquipamentos)
    {
        string caminho = @"c:\exameronXML\output.xml";
        TextWriter filestream = new StreamWriter(caminho);
        try
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<Patient>));

            serialiser.Serialize(filestream, ListaEquipamentos);

            filestream.Close();

        }
        catch (Exception ex)
        {
            filestream.Close();
            throw ex;
        }
    }

    public List<Patient> LoadPatient()
    {
        var element = (@"c:\exameronXML\output.xml");

        return (GetPatient(element));
    }

    public List<Patient> LoadPatientOk()
    {
        try
        {
            var list = LoadPatient().Where(w => !w.IsDeleted).ToList();
            list.ForEach(f => f.LastName = Decrypt(f.LastName));
            return list;

        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private List<Patient> GetPatient(string file)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Patient>));

        if (!File.Exists(file))
            return new List<Patient>();

        FileStream stream = File.OpenRead(file);
        try
        {
            List<Patient> dezerializedList = (List<Patient>)serializer.Deserialize(stream);
            stream.Close();
            return dezerializedList.ToList();
        }
        catch (Exception e)
        {
            stream.Close();
            throw e;
        }
    }

    public void Remove(string Identifiable)
    {
        try
        {
            var record = LoadPatient();
            var remove = record.FirstOrDefault(f => f.Identifiable == Identifiable);
            remove.IsDeleted = true;
            remove.LasUpdatedDate = DateTime.Now;
            RecordXML(record);

            Response.Redirect("~/Patients/PatientList");
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void LoadEdit(string identifiable)
    {
        try
        {

            btnAdd.Visible = false;
            var record = LoadPatient();
            var edit = record.FirstOrDefault(f => f.Identifiable == identifiable);
            #region update
            firtName.Text = edit.FirtName;
            lastName.Text = Decrypt(edit.LastName);
            note.Text = edit.Notes;
            phone.Text = edit.Phone;
            gender.Text = edit.Gender;
            email.Text = edit.Email;
            Identifiable.Text = identifiable;
            #endregion
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    protected void UpdatePatient(object serder, EventArgs e)
    {
        try
        {
            var record = LoadPatient();
            var edit = record.FirstOrDefault(f => f.Identifiable == Identifiable.Text);
            #region update
            edit.FirtName = firtName.Text;
            edit.LastName = Encrypter(lastName.Text);
            edit.Notes = note.Text;
            edit.Phone = phone.Text;
            edit.Gender = gender.Text;
            edit.Email = email.Text;
            #endregion
            edit.LasUpdatedDate = DateTime.Now;
            RecordXML(record);
            ShowAdd = true;
            btnAdd.Visible = true;

            Response.Redirect("~/Patients/PatientList");
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    private string Encrypter(string text)
    {
        try
        {
            var encryp = new HelperEncrypter();
            return encryp.Encrypt(text);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private string Decrypt(string text)
    {
        try
        {
            var decryp = new HelperEncrypter();
            return decryp.Decrypt(text);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
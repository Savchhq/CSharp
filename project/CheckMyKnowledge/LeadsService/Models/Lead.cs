namespace MyApp.Models;

public class Lead
{
    public int ID { get; init; }
    public string Tittle { get; set; } = "";
    public string URL { get; set; } = "";
    public string Status { get; set; } = "";
    public int? Month { get; set; } = DateTime.Now.Month;
}
namespace hometask5.Models;

public partial class Group
{
    public int GrId { get; set; }

    public string GrName { get; set; } = null!;

    public double GrTemp { get; set; }

    public virtual ICollection<Analysis> Analyses { get; set; } = new List<Analysis>();
}

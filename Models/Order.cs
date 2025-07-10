namespace hometask5.Models;

public partial class Order
{
    public int OrdId { get; set; }

    public DateTime OrdDatetime { get; set; }

    public int OrdAn { get; set; }

    public virtual Analysis OrdAnNavigation { get; set; } = null!;
}

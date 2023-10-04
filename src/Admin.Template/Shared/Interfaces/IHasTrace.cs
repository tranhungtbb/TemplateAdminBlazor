namespace Admin.Template.Shared.Interfaces;

public interface IHasTrace
{
    public long? CreateBy { get; set; }

    public string? CreateByName { get; set; }

    public long? ModifyBy { get; set; }

    public string? ModifyByName { get; set; }
}

namespace EasyJamDAL.Entities.Interfaces
{
    public interface IMusicien
    {
        int Id { get; set; }
        string? Instrument1 { get; set; }
        string? Instrument2 { get; set; }
        string? Instrument3 { get; set; }
        bool IsAvailable { get; set; }
        string? Name { get; set; }
    }
}
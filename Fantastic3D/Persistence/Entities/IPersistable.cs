namespace Fantastic3D.Persistence.Entities
{
    /// <summary>
    /// Interface for classes that can be saved into persistence.
    /// All persistable classes need an Id to be queryed.
    /// </summary>
    public interface IPersistable
    {
        public int Id { get; set; }
    }
}
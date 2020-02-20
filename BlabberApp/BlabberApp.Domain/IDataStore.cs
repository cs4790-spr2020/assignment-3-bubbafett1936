namespace BlabberApp.Domain
{
    public interface IDataStore
    {
        bool Create(IDatum datum);
        IDatum Read(int idx);
        bool Update(int idx, IDatum datum);
        bool Delete(int idx);
    }
}

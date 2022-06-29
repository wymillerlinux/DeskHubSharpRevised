namespace DeskHubSharpRevised.DAL;

public interface IDataService
{
    //List<Search> ReadAll();
    //void WriteAll(List<Search> user);
    void SearchRequest();
    void UserRequest();
    void BranchRequest();
}
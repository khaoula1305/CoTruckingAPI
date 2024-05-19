
public interface ICompanyService : IGenericService<CompanyModel>
{
}


public class CompanyService : GenericService<CompanyModel>, ICompanyService
{

    public CompanyService(HttpClient httpClient) : base(httpClient)
    {

    }
}
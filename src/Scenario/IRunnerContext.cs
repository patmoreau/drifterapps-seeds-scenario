namespace DrifterApps.Seeds.Scenario;

public interface IRunnerContext
{
    void SetContextData(string contextKey, object data);
    public T GetContextData<T>(string contextKey);
}

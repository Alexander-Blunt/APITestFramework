using Newtonsoft.Json;

namespace APIFramework;

public abstract class Service
{
    #region Parameters
    public CallManager CallManager { get; set; }
    public Model? Content { get; set; }
    public string? ResponseString { get; set; }
    #endregion

    #region Constructors
    public Service()
    {
        CallManager = new CallManager();
    }
    #endregion

    #region Methods
    public abstract Task MakeRequestAsync(string number);
    #endregion
}

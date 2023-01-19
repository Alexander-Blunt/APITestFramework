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
    public Service(CallManager callManager)
    {
        CallManager = callManager;
    }
    #endregion

    #region Methods
    public abstract Task MakeRandomRequestAsync();

    public abstract Task MakeRequestAsync(int number);
    #endregion
}

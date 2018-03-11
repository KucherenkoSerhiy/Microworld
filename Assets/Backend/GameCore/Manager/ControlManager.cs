using Assets.Backend.Model.Input;

public class ControlManager
{
    #region Singleton

    private static ControlManager _instance;

    public static ControlManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ControlManager();
            }
            return _instance;
        }
    }

    #endregion

    private HumanPlayerControlList _humanPlayerList;
    private BotPlayerControlList _botPlayerList;

    private ControlManager()
    {
        _humanPlayerList = new HumanPlayerControlList();
        _botPlayerList = new BotPlayerControlList();
    }

    public HumanPlayerControlList GetHumanPlayerControlList()
    {
        return _humanPlayerList;
    }

    public BotPlayerControlList GetBotPlayerControlList()
    {
        return _botPlayerList;
    }
}

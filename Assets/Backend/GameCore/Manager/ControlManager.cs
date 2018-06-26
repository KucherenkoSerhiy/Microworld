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

    private ControlManager()
    {
        _humanPlayerList = new HumanPlayerControlList();
    }

    public HumanPlayerControlList GetHumanPlayerControlList()
    {
        return _humanPlayerList;
    }
    
}

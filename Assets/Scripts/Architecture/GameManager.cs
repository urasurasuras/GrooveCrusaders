using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    Config cfg;
    public List<Player> playerList;

    // Start is called before the first frame update
    void Start()
    {
        cfg = GetComponent<Config>();
        playerList = new List<Player>();
    }
    public void RegisterPlayerControl(Player p)
    {
        p.cfg.ch_deadzone = cfg.ch_deadzone;
        p.cfg.ch_fade = cfg.ch_fade;

        playerList.Add(p);
    }
    public void deRegisterPlayerControl(Player p)
    {
        playerList.Remove(p);
    }
}


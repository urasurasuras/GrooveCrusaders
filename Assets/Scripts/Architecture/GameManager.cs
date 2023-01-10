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
    public Config cfg;
    public List<Player> playerList;

    public Plane m_Plane; 

    // Start is called before the first frame update
    void Start()
    {        
        playerList = new List<Player>();
        cfg.cam_tilt = Camera.main.transform.eulerAngles.x-360;
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


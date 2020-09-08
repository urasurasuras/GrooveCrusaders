#if (UNITY_EDITOR)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    #region Singleton
    private static DebugManager _instance;

    public static DebugManager Instance
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

    public List<string> debugVars;

    private void Update()
    {
        debugVars.Clear();
    }


    public void Deboog(string key, object value)
    {
        debugVars.Add(key + ": " + value.ToString());
    }

}

#endif
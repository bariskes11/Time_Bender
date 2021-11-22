using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonCreator<T> : MonoBehaviour where T:MonoBehaviour
{

    private static T _instance;
    public static T instance
    {
        get
        {
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        _instance = this.GetComponent<T>();
        DontDestroyOnLoad(_instance);
    }

}

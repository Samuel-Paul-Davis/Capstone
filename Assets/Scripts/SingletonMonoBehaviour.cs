using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "does not exist in this scene");
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        print(gameObject.GetType());
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
    }
}

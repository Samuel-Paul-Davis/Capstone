using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLong : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        long i = 0;
        while (i < 10000000000)
        {
            i++;
        }
        Debug.Log(i);
    }
}
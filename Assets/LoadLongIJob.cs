using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;


//loadall can only be called from the main thread
/*
public struct LoadingJob : IJob
{
    public void Execute()
    {
//        ObjectArrayContainer objArrCont = results[0];
//        objArrCont.objects = Resources.LoadAll("Textures");
//        results[0] = objArrCont;

        Resources.LoadAll("Textures");
    }
}*/

public struct LoadingJob : IJob
{
    public void Execute()
    {
        long i = 0;
        while (i < 10000000000)
        {
            i++;
        }
        Debug.Log(i);
    }
}

public class LoadLongIJob : MonoBehaviour
{
    private JobHandle handle;

    // Start is called before the first frame update
    void Start()
    {
        LoadingJob loadingJob = new LoadingJob();

        handle = loadingJob.Schedule();
    }

    void Update()
    {
        if (handle.IsCompleted)
        {
            GameObject.Find("PlayerHitBox").GetComponent<MeshRenderer>().material.SetColor("_Color", Color.magenta);
            GameObject.Find("PlayerHitBox").GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.magenta);
        }
    }
}
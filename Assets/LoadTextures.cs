using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextures : MonoBehaviour
{
    public Object[] textures;

    // Start is called before the first frame update
    void Start()
    {
        textures = Resources.LoadAll("Textures");

        Debug.Log(textures.Length);
    }
}

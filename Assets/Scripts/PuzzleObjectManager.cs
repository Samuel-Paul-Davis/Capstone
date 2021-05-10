using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObjectManager : MonoBehaviour
{
    [SerializeField]
    Material[] myMaterials = new Material[2];

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material = myMaterials[0];
    }

    public void UpdateMaterial(bool setToActive)
    {
        if (setToActive)
            GetComponent<MeshRenderer>().material = myMaterials[1];
        else
            GetComponent<MeshRenderer>().material = myMaterials[0];
    }
}
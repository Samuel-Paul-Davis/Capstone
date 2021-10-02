using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlockObject : SlotPartObject
{
    public bool isPowered = false;
    public Material[] activatedMaterials;

    private Material[] originalMaterials;

    /*
     * Add Discover() override?
     *      - could show power flow with correct materials / shaders
     */

    private new void Start()
    {
        base.Start();

        originalMaterials = gameObject.GetComponent<MeshRenderer>().materials;
    }

    private new void Update()
    {
        base.Update();

        if (isPowered)
        {
            gameObject.GetComponent<MeshRenderer>().materials = activatedMaterials;
        } else
        {
            gameObject.GetComponent<MeshRenderer>().materials = originalMaterials;
        }
    }
}
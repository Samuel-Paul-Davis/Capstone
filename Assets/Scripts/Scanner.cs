using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private GameObject beam;

    private void Start()
    {
        beam = transform.Find("BeamContainer/Beam").gameObject;
        beam.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            beam.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            beam.GetComponent<ScannerBeam>().UnpaintAllTargets();

            beam.SetActive(false);
        }
    }
}

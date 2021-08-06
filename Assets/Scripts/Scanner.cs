using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject beam;

    private void Start()
    {
        if (beam == null)
            beam = transform.Find("BeamContainer/Beam").gameObject;
        beam.SetActive(false);

        if (key == KeyCode.None)
            key = KeyCode.F;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            beam.SetActive(true);
        }

        if (Input.GetKeyUp(key))
        {
            beam.GetComponent<ScannerBeam>().UnpaintAllTargets();

            beam.SetActive(false);
        }
    }
}

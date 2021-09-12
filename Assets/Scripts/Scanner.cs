using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;
    [SerializeField]
    private GameObject beam;
    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private Vector3 maxScale = Vector3.one;

    private Vector3 beamScale;
    private bool isScanning = false;

    private void Start()
    {
        if (beam == null)
            beam = transform.Find("BeamContainer/Beam").gameObject;
        beam.SetActive(false);

        if (key == KeyCode.None)
            key = KeyCode.F;

        beamScale = beam.transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
            isScanning = true;

        if (isScanning)
        {
            beam.SetActive(true);
            beam.transform.localScale += Vector3.one * Time.deltaTime * speed;
        }

        if (beam.transform.localScale.sqrMagnitude > maxScale.sqrMagnitude)
        {
            beam.SetActive(false);
            beam.transform.localScale = beamScale;
            isScanning = false;
        }
    }
}

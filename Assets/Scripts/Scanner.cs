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

    private Vector3 beamScale;

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
       if (Input.GetKey(key)) 
        {
            beam.SetActive(true);
            beam.transform.localScale += Vector3.one * Time.deltaTime * speed;
        }

        if (Input.GetKeyUp(key))
        {
            beam.SetActive(false);

            beam.transform.localScale = beamScale;
        }
    }
}

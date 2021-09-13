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
    [SerializeField]
    private float timeout;
    [Header("UI Bar")]
    [SerializeField]
    private UnityEngine.UI.Slider slider;
    [SerializeField]
    private float fadeInOutTime = .5f;

    private Vector3 beamScale;
    private bool isScanning = false;
    private float curTimeout;

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
        if (Input.GetKeyDown(key) && curTimeout == 0)
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
            curTimeout = timeout;
            FadeInScannerBar();
        }

        if (curTimeout > 0)
            curTimeout -= 1000f * Time.deltaTime;
        else
        {
            curTimeout = 0;
            FadeOutScannerBar();
        }

        slider.value = 1 - curTimeout / timeout;
    }

    public void FadeInScannerBar()
    {
        if (slider.GetComponent<CanvasGroup>().alpha != 1)
            slider.GetComponent<CanvasGroup>().LeanAlpha(1, fadeInOutTime);
    }

    public void FadeOutScannerBar()
    {
        if (slider.GetComponent<CanvasGroup>().alpha == 1)
            slider.GetComponent<CanvasGroup>().LeanAlpha(0, fadeInOutTime);
    }
}

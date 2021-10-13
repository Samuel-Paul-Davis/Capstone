using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEndGameScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TempEndGamePanel;
    [SerializeField]
    private string PlayerName;

    // Start is called before the first frame update
    void Awake()
    {
        TempEndGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
        GameObject.Find(PlayerName).SetActive(false);
        TempEndGamePanel.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
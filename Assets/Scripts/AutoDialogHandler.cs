using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AutoDialogHandler : MonoBehaviour
{
    [SerializeField]
    public string rawDialogText = "RawDialogText.txt";
    [SerializeField]
    private int currentDialog = 0;
    private float previousTime = 0.0f;
    private float intervalPeriod = 0;
    private List<DialogSection> dialog = new List<DialogSection>();
    [SerializeField]
    private Text speakerText;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private GameObject dialogPanel;
    private bool isInCutsceen = false;
    private float fTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDialog();
        ShowDialog();
        //dialogPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDialog > dialog.Count)
        {
            isInCutsceen = false;
            Time.timeScale = 1;
            dialogPanel.SetActive(false);
            currentDialog = 0;
        }
        else if (isInCutsceen)
        {           
            fTime = fTime + 1f * Time.deltaTime;

            if (fTime >= intervalPeriod)
            {
                NextDialog();
                ShowDialog();
                fTime = 0;
            }
        }
    }

    void GenerateDialog()
    {
        rawDialogText = Path.Combine(Application.streamingAssetsPath, rawDialogText);
        string rawDialog = string.Join(" ", File.ReadAllLines(rawDialogText));
        string[] rawLines = rawDialog.Split(']');

        foreach (string rawLine in rawLines)
        {
            string[] splitLine = rawLine.Trim().Split('[');

            string[] splitDialog = splitLine[1].Split('@');

            DialogSection dialogSection = new DialogSection(splitLine[0].Trim(), splitDialog[0].Replace('*', '\n'), Int32.Parse(splitDialog[1]));
            dialog.Add(dialogSection);
        }
    }

    public void ShowDialog()
    {
        if (currentDialog < dialog.Count)
        {
            speakerText.text = dialog[currentDialog].Speaker;
            dialogText.text = dialog[currentDialog].Dialog;
            intervalPeriod = dialog[currentDialog].DialogAvailabilityLength;
        }
    }

    public void NextDialog()
    {
        currentDialog++;
    }

    public void PreviousDialog()
    {
        currentDialog--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInCutsceen = true;
            dialogPanel.SetActive(true);
            ShowDialog();
        }      
    }
}
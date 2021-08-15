using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogHandler : MonoBehaviour
{
    public string rawDialogText = "Assets/Recourses/RawDialogText.txt";
    [SerializeField]
    private int currentDialog = 0;
    private List<DialogSection> dialog = new List<DialogSection>();
    [SerializeField]
    private Text speakerText;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private GameObject dialogPanel;
    private bool isInCutsceen = true;

    // Start is called before the first frame update
    void Start()
    {
        GenerateDialog();
        ShowDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInCutsceen)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(currentDialog + " : " + dialog.Count);
                if (currentDialog >= dialog.Count)
                {
                    isInCutsceen = false;
                    dialogPanel.SetActive(false);
                }
                else
                {                   
                    ShowDialog();
                    NextDialog();
                }             
            }
        }
    }

    void GenerateDialog()
    {
        string rawDialog = string.Join(" ", File.ReadAllLines(rawDialogText));
        string[] rawLines = rawDialog.Split(']');

        foreach (string rawLine in rawLines)
        {
            string[] splitLine = rawLine.Trim().Split('[');

            DialogSection dialogSection = new DialogSection(splitLine[0].Trim(), splitLine[1].Replace('*', '\n'));
            dialog.Add(dialogSection);
        }
    }

    public void ShowDialog()
    {
        speakerText.text = dialog[currentDialog].Speaker;
        dialogText.text = dialog[currentDialog].Dialog;
    }

    public void NextDialog()
    {
        currentDialog++;
    }

    public void PreviousDialog()
    {
        currentDialog--;
    }
}

public struct DialogSection
{
    public string Speaker { get; set; }
    public string Dialog { get; set; }

    public DialogSection(string pSpeaker, string pDialog)
    {
        Speaker = pSpeaker;
        Dialog = pDialog;
    }   
}
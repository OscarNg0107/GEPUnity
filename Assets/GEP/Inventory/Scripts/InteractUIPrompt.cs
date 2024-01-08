using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractUIPrompt : MonoBehaviour
{

    [SerializeField] private GameObject uiPanel;
    [SerializeField] private TextMeshProUGUI promptext;

    public bool isDisplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string promptText) 
    {
        promptext.text = promptText;
        uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void Close() 
    {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
Open interface
v1.0.0
08/08/2025
*/

public class OpenUI : MonoBehaviour
{
    public GameObject UIChildWindow;
    public Button OpenChildButton;


    void Start(){
        OpenChildButton.onClick.AddListener(OpenChild);

    }

    private void OpenChild(){
        UIChildWindow.gameObject.SetActive(true);
        Debug.Log("Opened an interface.");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Close interface
v1.0.0
08/08/2025
*/

public class CloseUI : MonoBehaviour
{
    public GameObject UIWindow;
    public Button CloseUIButton;


    void Start(){
        CloseUIButton.onClick.AddListener(CloseChild);
    }

    private void CloseChild(){
        UIWindow.gameObject.SetActive(false);
        Debug.Log("AUI has been closed");
    }
}

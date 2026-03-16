using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
quit app 
08/08/2024
*/

public class QuitApp : MonoBehaviour
{
    public Button ExitButton;

    void Start(){
        ExitButton.onClick.AddListener(ApplicationEnd);
    }

    private void ApplicationEnd(){
        Application.Quit();
    }
}

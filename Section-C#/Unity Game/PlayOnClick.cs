using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Play audio clip when user clicks
v1.0.0
08/08/2025
*/

public class PlayOnClick : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // You drag this in manually
    private Button button;

    private void Awake(){
        button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound(){
        if (audioSource != null){
            audioSource.Play();
        }
    }
}

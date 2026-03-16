using UnityEngine;


/*
Play audio when game object activated
1.0.0
08/08/2025
*/

public class PlayAudioOnActive : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable(){
        if (audioSource != null && !audioSource.isPlaying){
            audioSource.Play();
        }
    }

    private void OnDisable(){
        if (audioSource != null && audioSource.isPlaying){
            audioSource.Stop(); 
        }
    }
}
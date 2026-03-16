using UnityEngine;

/*
object inactive on start
v1.0.0
08/08/2025
*/

public class InactiveOnStart : MonoBehaviour
{
    void Start(){
        gameObject.SetActive(false);
    }
}
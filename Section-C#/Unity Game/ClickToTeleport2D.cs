using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
v1.0.0
14/06/2025

click to teleport for 2D
*/

public class ClickToTeleport2D : MonoBehaviour
{
    public GameObject Player;
    public Transform TargetLoco;
    public Button Trigger;

    void Start(){
        Trigger.onClick.AddListener(Move);
    }

    void Move(){
        Player.transform.position = TargetLoco.position;
        Player.transform.rotation = TargetLoco.rotation;
    }
}
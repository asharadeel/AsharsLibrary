using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
DX1 NAMESAKE USER DATA CLASS PROFILE OBJECT
*/

[System.Serializable]
public class UserData{
    //key details
    public string UserID;
    public int PinID;
    public int level;
    public int xpoints;
    public int tokens;

    //games stats
    public int gamesplayed;
    public int infplayed;
    public int hpplayed;
    public int freeroamplayed;
    public int dronemodeplayed;
    public int gamesWon;

    //garage stats
    public bool F11Owned;
    public bool M1Owned;
    public bool F11Equipped;
    public bool M1Equipped;

    public UserData (HPPlayer player){
        //updates class to match player
        level = player.level;
        UserID = player.UserID;
        PinID = player.PinID;
        xpoints = player.xpoints;
        tokens = player.tokens;

        infplayed = player.infplayed;
        hpplayed = player.hpplayed;
        freeroamplayed = player.freeroamplayed;
        dronemodeplayed = player.dronemodeplayed;
        gamesplayed = player.gamesplayed;
        gamesWon = player.gamesWon;

        F11Owned = player.F11Owned;
        M1Owned = player.M1Owned;
        F11Equipped = player.F11Equipped;
        M1Equipped = player.M1Equipped;
    }
}

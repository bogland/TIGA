using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData2
{
    public string name = "John";
    public int age = 25;
    public string[] item = { "소주", "막걸리", "청하" };
}

public class JsonManager2 : MonoBehaviour {
    PlayerData2 playerData;

    // Use this for initialization
    void Start () {
        playerData = new PlayerData2();
        Ujson<PlayerData2>.Write("GameResources/UserData/Player.json", playerData);
        playerData = Ujson<PlayerData2>.Read("GameResources/UserData/Player.json");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(playerData.name);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiga.Data.Json
{


    public class PlayerData
    {
        public string name = "John";
        public int age = 25;
        public string[] item = { "소주", "막걸리", "청하" };
    }

    public class JsonManager : MonoBehaviour
    {
        PlayerData playerData;

        // Use this for initialization
        void Start()
        {
            playerData = new PlayerData();
            Json<PlayerData>.Write("GameResources/UserData/Player.json", playerData);
            playerData = Json<PlayerData>.Read("GameResources/UserData/Player.json");
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(playerData.name);
        }
    }
}
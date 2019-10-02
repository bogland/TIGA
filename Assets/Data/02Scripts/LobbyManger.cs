using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManger : MonoBehaviour
{
    /// <summary>
    /// 내 인벤토리 버튼.
    /// </summary>
    public void InventoryBtn()
    {
        PlayerController._uniqueInstance.LoadPlayerDataFromJson();
    }
}

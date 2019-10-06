using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct Dialogue
{
    public string character;
    public string dialogueText;
}

public class CSVManager : MonoBehaviour
{
    public Image thumbImg;
    public Text characterName;
    public Text dialogueText;
    List<Dictionary<string, object>> data;
    string sceneName;

    void Awake()
    {
        data = CSVReader.Read("dialog.txt");
 
    }
    private void Start()
    {
        string sceneName = "S1";
        string dialogID = "DLG001";
        List<Dialogue> dialogueList = new List<Dialogue>();
        dialogueList = LoadDialogue(sceneName, dialogID);

        foreach (var i in dialogueList)
        {
            Debug.Log($"{i.character} : {i.dialogueText}");
            AdaptDialogueUI(i);
        }
    }
    public void AdaptDialogueUI(Dialogue dialogue)
    {
        
        //thumbImg.GetComponent<RawImage>().texture = LoadCharacterImage(dialogue.character);
        thumbImg.sprite = LoadCharacterImage(dialogue.character);
        characterName.text = dialogue.character;
        dialogueText.text = dialogue.dialogueText;
    }

    public List<Dialogue> LoadDialogue(string sceneName, string id)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        for (var i = 0; i < data.Count; i++)
        {
            if (data[i]["Scene"].ToString() == sceneName && data[i]["ID"].ToString() == id)
            {
                Dialogue dialog = new Dialogue();
                dialog.character = data[i]["Image"].ToString();
                dialog.dialogueText = data[i]["Dialogue"].ToString();
                dialogueList.Add(dialog);
            }
        }
        return dialogueList;
    }
    
    /// <summary>
    /// 캐릭터 이름을 입력시 지정 경로상에서 캐릭터 이미지를 불러옴
    /// </summary>
    /// <param name="characterName"></param>
    /// <returns></returns>
    private Sprite LoadCharacterImage(string characterName)
    {
        Texture2D texture = new Texture2D(0, 0);
        byte[] byteTexture = System.IO.File.ReadAllBytes(Application.dataPath + "/GameResources/Image/Character/" + characterName + ".jpg");
        if (byteTexture.Length > 0)
        {
            texture.LoadImage(byteTexture);
        }
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 1);
        return sprite;
    }
}

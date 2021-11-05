using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadGame : MonoBehaviour
{
    Text inputName;
    private void Start()
    {
        inputName = GameObject.Find("PlayerNameText").GetComponent<Text>();
    }
    public void Load()
    {
        PlayerData.Instance.playerName = inputName.text;
        SceneManager.LoadScene(1);
    }
}

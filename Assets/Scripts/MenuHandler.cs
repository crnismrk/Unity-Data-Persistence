using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text bestScoreInput;

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            nameInput.text = DataManager.Instance.PlayerName;
            bestScoreInput.text = DataManager.Instance.BesetScoreText;
        }    
    }
    public void StartClickHandler()
    {
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(1);
    }

    public void NameChangeHandler()
    {
       if(DataManager.Instance != null)
        {
            DataManager.Instance.PlayerName = nameInput.text;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UIMenuHandler : MonoBehaviour
{
    private TMP_InputField playerNameInputField;

    private void Awake()
    {
        playerNameInputField = transform.Find("InputFieldPlayerName").GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        playerNameInputField.onEndEdit.AddListener(OnPlayerNameEndEdit);
    }

    private void OnPlayerNameEndEdit(string playerName)
    {
        if (RecordKeeper.Instance != null)
        {
            RecordKeeper.Instance.currentPlayerName = playerName;
        }
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(2);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void VisitTopFive()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }
}

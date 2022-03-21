using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    private GameObject _settingsPanel;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {

    }

    void Start()
    {
        _settingsPanel = transform.GetChildWithTag("SettingsPanel").gameObject;
    }


    void Update()
    {

    }

    #endregion

    #region PublicMethods
    public void OpenSettingsPanel()
    {
        CloseAllChilds();
        _settingsPanel.SetActive(true);
    }

    public void LoadNextScene()
    {
        SceneManagerAdapter.LoadNextLevel();
        CloseAllChilds();
    }

    public void OpenMainMenu()
    {
        CloseAllChilds();
        OpenMainButtons();
    }

    #endregion

    #region PrivateMethods
    private void CloseAllChilds()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    void OpenMainButtons()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("MainButton"))
                child.gameObject.SetActive(true);
        }
    }
    #endregion
}

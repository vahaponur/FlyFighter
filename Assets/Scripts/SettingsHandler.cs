using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    #region Serialized Fields
    public MenuData _data;
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    private void Awake()
    {
        var settingsHandlers = FindObjectsOfType<SettingsHandler>().Length;
        if (settingsHandlers > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region PublicMethods
    public void SetSfxMultiplier(float value)
    {
        _data._sfxMultiplier = value;
    }
    public void SetVoiceMultiplier(float value)
    {
        _data._voiceMultiplier = value;
    }
    public void SetMusicMultiplier(float value)
    {
        _data._musicMultiplier = value;
    }
    #endregion

    #region PrivateMethods

    #endregion
}

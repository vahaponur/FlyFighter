using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerSingleton : MonoBehaviour
{

    #region MonoBehaveMethods
    void Awake()
    {
        var musicPlayerNum = GameObject.FindObjectsOfType<MusicPlayerSingleton>().Length;
        if (musicPlayerNum > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);

    }

    #endregion

}

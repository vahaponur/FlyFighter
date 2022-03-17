using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ParticleExtensions 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

 
    
    #region PublicMethods
    /// <summary>
    /// Plays the particle system if it is not already playing
    /// </summary>
    /// <param name="particleSystem">Source Object</param>
    public static void PlayWithLogic(this ParticleSystem particleSystem)
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
    }
    /// <summary>
    /// Plays the particle system if given key is get, don't play if already playing
    /// </summary>
    /// <param name="particleSystem">Source Object</param>
    /// <param name="keyCode">Key to get</param>
    public static void PlayOnGetKey(this ParticleSystem particleSystem, KeyCode keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            particleSystem.PlayWithLogic();
        }
        else
        {
            particleSystem.Stop();
        }
    }
    #endregion
    
    #region PrivateMethods
    #endregion
}

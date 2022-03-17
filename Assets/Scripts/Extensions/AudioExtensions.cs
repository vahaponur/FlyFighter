using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioExtensions 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    
    
    #region PublicMethods
    
    /// <summary>
    /// Plays the audio source if not already playing
    /// </summary>
    /// <param name="source">Source Object</param>
    public static void PlayWithLogic(this  AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    
    /// <summary>
    /// Plays the audio while get key true (not playing if already playing)
    /// </summary>
    /// <param name="source">Source Object</param>
    /// <param name="keyCode">Key to get</param>
    public static void PlayOnGetKey(this  AudioSource source,KeyCode keyCode)
    {
        if (Input.GetKey(keyCode))
        {
            PlayWithLogic(source);
        }
        else
        {
            source.Stop();
        }
    }
    
    /// <summary>
    /// Plays the given clip if not already playing
    /// </summary>
    /// <param name="source">Source Object</param>
    /// <param name="clip">Clip to Play</param>
    public static void PlayWithLogic(this AudioSource source, AudioClip clip)
    {
        if (source.clip != clip)
        {
            source.clip = clip;
        }
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    
    
    /// <summary>
    /// Plays the audio with given clip while get key true (not playing if already playing)
    /// </summary>
    /// <param name="source">Source Object</param>
    /// <param name="keyCode">Key to get</param>
    /// <param name="clip">Clip To Play</param>
    public static void PlayOnGetKey(this  AudioSource source,KeyCode keyCode,AudioClip clip)
    {
        if (Input.GetKey(keyCode))
        {
            PlayWithLogic(source,clip);
        }
        else
        {
            source.Stop();
        }
    }
    
    #endregion
    
    #region PrivateMethods
    #endregion
}

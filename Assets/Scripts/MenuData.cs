using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MenuData", menuName = "ScriptableObjects/MenuData", order = 1)]
public class MenuData : ScriptableObject
{
    public float _musicMultiplier;
    public float _sfxMultiplier;
    public float _voiceMultiplier;

    private void Reset()
    {
        _musicMultiplier = 1f;
        _sfxMultiplier = 1f;
        _voiceMultiplier = 1f;
    }
}

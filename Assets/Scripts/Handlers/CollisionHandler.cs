using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represent Player Collision Events
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    
    private void OnTriggerEnter(Collider other)
    {
        ProcessCrash();
    }
        
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    /// <summary>
    /// Event sequence after player ship hits an object
    /// </summary>
    void ProcessCrash()
    {
        var controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.enabled = false;
        }
        
        SceneManagerAdapter.ReloadSceneAfter(1);
    }
    #endregion
}

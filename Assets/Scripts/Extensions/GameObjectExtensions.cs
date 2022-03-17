using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents GameObject extension methods
/// </summary>
public static class GameObjectExtensions 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

 
    
    #region PublicMethods
    
    /// <summary>
    /// Disables all gameobject in the array
    /// </summary>
    /// <param name="arr">GameObject array to extend</param>
    public static void DisableAll(this GameObject[] arr)
    {
        foreach (GameObject gameObject in arr)
        {
            gameObject.SetActive(false);
        }
    }
    
    /// <summary>
    /// Enables all gameobject in the array
    /// </summary>
    /// <param name="arr">GameObject array to extend</param>
    public static void EnableAll(this GameObject[] arr)
    {
        foreach (GameObject gameObject in arr)
        {
            gameObject.SetActive(true); 
        }
    }
    
    /// <summary>
    /// Disables all gameobject in the list
    /// </summary>
    /// <param name="list">GameObject list to extend</param>
    public static void DisableAll(this List<GameObject> list)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(false);
        
        }
    }
    
    /// <summary>
    /// Enables all gameobject in the list
    /// </summary>
    /// <param name="arr">GameObject list to extend</param>
    public static void EnableAll(this List<GameObject> list)
    {
        foreach (GameObject gameObject in list)
        {
            gameObject.SetActive(true); 
        }
    }

  
    #endregion
    
    #region PrivateMethods
    #endregion
}

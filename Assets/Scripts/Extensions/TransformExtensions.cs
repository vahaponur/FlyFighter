using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions 
{
    #region Serialized Fields
    #endregion

    #region Private Fields
    #endregion

    #region Public Properties
    #endregion

    
    
    #region PublicMethods
    /// <summary>
    /// Gets the child with tag
    /// </summary>
    /// <param name="father">Object to extend</param>
    /// <param name="tag">Tag on child</param>
    /// <returns></returns>
    /// <exception cref="Exception">Not found exception</exception>
    public static Transform GetChildWithTag(this Transform father,string tag)
    {
        foreach (Transform transform in father)
        {
            if (transform.gameObject.CompareTag(tag))
            {
                return transform;
            }
        }

        throw new Exception("Child couldn't found");
    }
    #endregion
    
    #region PrivateMethods
    #endregion
}

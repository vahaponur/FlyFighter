using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventsHandler : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    private Vector3 _firstScale;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    void Awake()
    {
        _firstScale = transform.localScale;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }

    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods

    void GetBigger()
    {
        var per = Time.time;
        var newScale = _firstScale* (3*Mathf.Sin(per)+5);
        transform.localScale = newScale;
    }
    #endregion
}

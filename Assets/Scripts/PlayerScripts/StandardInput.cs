using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StandardInput : MonoBehaviour
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    protected float _horizontalInput;
    protected float _verticalInput;
    protected float _jump;
    protected float _fire1;
    protected float _fire2;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods
    protected virtual void Awake()
    {
	
    }

    protected virtual void Start()
    {
       

    }

   
    protected virtual void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _jump = Input.GetAxisRaw("Jump");
        _fire1 = Input.GetAxisRaw("Fire1");
        _fire2 = Input.GetAxisRaw("Fire2");

    }
    #endregion
    
    #region PublicMethods
    #endregion
    
    #region PrivateMethods
    #endregion
}

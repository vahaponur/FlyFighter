using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyEventsHandler : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("Particle to instansiate on death")]
    [SerializeField] private GameObject _deathVFX;


    [Tooltip("How much the player score will increase after shooting this gameobject")]
    [SerializeField] private int _increaseAmount = 1;

    [SerializeField] private int _hitPoint = 1;
    #endregion

    #region Private Fields

    private Vector3 _firstScale;
    private ScoreBoard _scoreBoard;
    /// <summary>
    /// VFX Particle instances  parent
    /// </summary>
    private GameObject _parent;

    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods

    void Start()
    {
        //Throw exception if 0 or more than 1
        _scoreBoard = FindObjectsOfType<ScoreBoard>().Single();
        AddRb();
        _parent = GameObject.FindGameObjectWithTag("InstanceCollector");

    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessBulletHit();
        if (_hitPoint < 1)
        {
            ProcessDie();

        }
    }

    #endregion

    #region PublicMethods
    #endregion

    #region PrivateMethods
    /// <summary>
    /// Processes event when enemy dies
    /// </summary>
    void ProcessDie()
    {
        var vfx = Instantiate(_deathVFX, transform.position, Quaternion.identity);
        vfx.transform.SetParent(_parent.transform);
        _scoreBoard.IncreaseScore(_increaseAmount);
        Destroy(gameObject);
    }

    /// <summary>
    /// Processes event when bullet hits the enemy
    /// </summary>
    void ProcessBulletHit()
    {

        _hitPoint--;
        GetComponent<MeshRenderer>().material.color = Color.magenta;

    }
    /// <summary>
    /// Add rigidbody to enemy if not have already
    /// </summary>
    void AddRb()
    {
        var refRb = gameObject.GetComponent<Rigidbody>();
        if (refRb != null)
        {
            refRb.useGravity = false;
            return;
        };

        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    #endregion
}

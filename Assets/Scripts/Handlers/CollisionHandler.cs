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

    private ParticleSystem _explosionVfx;
    private MeshRenderer _meshRenderer;
    private MeshCollider _meshCollider;
    AudioSource _audioSource;
    #endregion

    #region Public Properties
    #endregion

    #region MonoBehaveMethods

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _explosionVfx = transform.GetChildWithTag("ExplosionVFX").GetComponent<ParticleSystem>();
        _audioSource = transform.GetChildWithTag("ExplosionVFX").GetComponent<AudioSource>();
        _meshCollider = transform.Find("Collider").GetComponent<MeshCollider>();

    }

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
        _audioSource.PlayWithLogic();
        var controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        _meshCollider.enabled = false;
        _meshRenderer.enabled = false;

        _explosionVfx.PlayWithLogic();
        SceneManagerAdapter.ReloadSceneAfter(1);
    }
    #endregion
}

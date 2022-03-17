using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static  class SceneManagerAdapter
{
    #region Serialized Fields
    #endregion

    #region Private Fields

    private static CoroutineRunner _coroutineRunner;
    #endregion

    #region Public Properties
    public static CoroutineRunner CoroutineRunner
    {
        get => GetCoroutineRunner();
    }
    #endregion
    
    #region PublicMethods
    /// <summary>
    /// Loads current scene asynchronously
    /// </summary>
    /// <returns>Null</returns>
    public static IEnumerator LoadCurrentScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    /// <summary>
    /// Loads the given scene asynchronously
    /// </summary>
    /// <param name="sceneName">Scene name to load</param>
    /// <returns>Null</returns>
    public static IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    /// <summary>
    /// Loads the given scene asynchronously
    /// </summary>
    /// <param name="sceneIndex">Index of scene on builder</param>
    /// <returns>Null</returns>
    public static IEnumerator LoadSceneAsync(int sceneIndex)
    {
        if (sceneIndex<0)
        {
            throw new Exception("Scene Index cannot be lower than 0");
        }
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    /// <summary>
    /// Reloads the current Level
    /// </summary>
    public static void ReloadLevel()
    {
       CoroutineRunner.StartCoroutine(SceneManagerAdapter.LoadCurrentScene());
    }
    /// <summary>
    /// Loads Next Level by build index
    /// </summary>
    public static void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
       
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        CoroutineRunner.StartCoroutine(SceneManagerAdapter.LoadSceneAsync(nextSceneIndex));
        
    }
    
    /// <summary>
    /// Reloads the current scene after given time
    /// </summary>
    /// <param name="seconds">Wait time</param>
    public static void ReloadSceneAfter(float seconds)
    {
        CoroutineRunner.StartCoroutine(ReloadSceneAfterSeconds(seconds));
    }
    #endregion
    
    #region PrivateMethods
    static CoroutineRunner GetCoroutineRunner()
    {
        GameObject instance = new GameObject();
        instance.isStatic = true;
        _coroutineRunner = instance.AddComponent<CoroutineRunner>();
        return _coroutineRunner;
    }
    
    /// <summary>
    /// Reloads the current scene after given seconds
    /// </summary>
    /// <param name="seconds">Seconds to wait</param>
    /// <returns></returns>
    static IEnumerator ReloadSceneAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    /// <summary>
    /// Reloads the given scene after given seconds
    /// </summary>
    /// <param name="seconds">Seconds to wait</param>
    /// <param name="sceneName">Name of the scene to load</param>
    /// <returns></returns>
    static IEnumerator ReloadSceneAfterSeconds(string sceneName,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    /// <summary>
    /// Reloads the given scene after given seconds
    /// </summary>
    /// <param name="seconds">Seconds to wait</param>
    /// <param name="sceneIndex">Index of the scene to load on builder</param>
    /// <returns></returns>
    static IEnumerator ReloadSceneAfterSeconds(int sceneIndex,float seconds)
    {
        yield return new WaitForSeconds(seconds);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    
    #endregion
}



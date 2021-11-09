using JMRSDK.InputModule;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JMRSDKExampleSnippets
{
    /// <summary>
    /// Loads scene DisabledRay&Pointer after finding disabled gameobjects
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        GameObject laserPointer;
        GameObject controller;
        GameObject cursorPointer;

        private void Start()
        {
            Invoke("FindGameObjects", 2);
        }

        /// <summary>
        /// Load DisabledRay&Pointer scene
        /// </summary>
        public void LoadGameScene()
        {
            SceneManager.LoadSceneAsync("DisabledRay&Pointer");
        }

        /// <summary>
        /// Enable all gameobjects that were disbaled.
        /// </summary>
        /// <remarks>
        /// Called after 2 seconds from start as these take time to get initialized.
        /// </remarks>
        public void FindGameObjects()
        {
            laserPointer = JMRInputManager.Instance.transform.Find("JMRLaserPointer(Clone)").gameObject;
            laserPointer.SetActive(true);

            cursorPointer = JMRInputManager.Instance.transform.Find("JMRPointer(Clone)").gameObject;
            cursorPointer.SetActive(true);

            controller = JMRInputManager.Instance.transform.Find("JioGlassController(Clone)").gameObject;
            controller.SetActive(true);
        }
    }
}
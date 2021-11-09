using UnityEngine;
using JMRSDK.InputModule;//must be included in script in order to access pointer and controller
using UnityEngine.SceneManagement;

namespace JMRSDKExampleSnippets
{
    /// <summary>
    /// Disable ray and controller model.
    /// </summary>
    public class DisableRay : MonoBehaviour, IBackHandler
    {
        GameObject laserPointer;
        GameObject controller;
        GameObject cursorPointer;

        /// <summary>
        /// Add global listener and invoke FindGameObjects after delay.
        /// </summary>
        public void Start()
        {
            JMRInputManager.Instance.AddGlobalListener(gameObject);
            Invoke("FindGameObjects", 2f);
        }

        /// <summary>
        /// Find references to Laser Pointer, Pointer and JioGlass controller model and disable them.
        /// </summary>
        public void FindGameObjects()
        {
            laserPointer = JMRInputManager.Instance.transform.Find("JMRLaserPointer(Clone)").gameObject;
            cursorPointer = JMRInputManager.Instance.transform.Find("JMRPointer(Clone)").gameObject;
			controller = JMRInputManager.Instance.transform.Find("JioGlassController(Clone)").gameObject;

			foreach (Transform item in controller.GetComponentsInChildren<Transform>())
			{
                if(item.gameObject.name == "Model")
				{
                    item.gameObject.SetActive(false);
                    break;
				}
			}
            laserPointer.SetActive(false);
            cursorPointer.SetActive(false);
        }

        /// <summary>
        /// Switch to main menu when back button is pressed.
        /// </summary>
		public void OnBackAction()
		{
            SceneManager.LoadSceneAsync("MenuScene");
        }
	}
}
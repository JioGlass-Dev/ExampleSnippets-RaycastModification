using UnityEngine;

namespace JMRSDKExampleSnippets
{
    /// <summary>
    /// Controls shooting from a ray of controller.
    /// </summary>
    public class BubbleShootControllerRay : MonoBehaviour
    {
        /// <summary>
        /// getting controller ray from JMRPointerManager and disabling any gameobject in its path.
        /// </summary>
        public void Update()
        {
            //getting the controller ray from JMRPointerManager
            Ray ray = JMRSDK.InputModule.JMRPointerManager.Instance.GetCurrentRay();
            RaycastHit raycastHit;
            // if ray collides with any gameobject having collider then hit variable gives RaycastHit details
            if (Physics.Raycast(ray, out raycastHit))//casting the ray 
            {
                Debug.Log(raycastHit.transform.gameObject);
                raycastHit.transform.gameObject.SetActive(false);//disabling gameobject collided gameobject
            }
        }
    }
}

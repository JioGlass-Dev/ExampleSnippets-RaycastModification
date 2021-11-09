using JMRSDK;
using JMRSDK.InputModule;
using UnityEngine;

namespace JMRSDKExampleSnippets
{
    public class BubbleShootHeadRay : MonoBehaviour
    {
        Ray ray = new Ray();
        LineRenderer lineRenderer;

        /// <summary>
        /// Cache the line renderer.
        /// </summary>
        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        /// <summary>
        /// Switch pointer to head, after a small delay.
        /// </summary>
		private void Start()
		{
			Invoke(nameof(SwitchPointerToHead), 1.5f);
		}

        /// <summary>
        /// Method to switch pointer to head ray.
        /// </summary>
		public void SwitchPointerToHead()
		{
			FindObjectOfType<JMRPointerManager>().SwitchPointingSource();
		}

        /// <summary>
        /// Creating controller ray from JMRPointerManager and disabling any gameobject in its path.
        /// </summary>
		public void Update()
        {
            //getting the head trasnform
            Transform t = JMRTrackerManager.Instance.GetHeadTransform();
            lineRenderer.SetPosition(0, t.position);
            lineRenderer.SetPosition(1, t.forward * 100);
            //setting the ray origin and direction
            ray.origin = t.position;//note head position will be always be on ther center of the screen
            ray.direction = t.forward * 100;
            // if ray collides with any gameobject having collider then raycastHit variable gives RaycastHit details
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log(raycastHit.transform.gameObject);
                lineRenderer.SetPosition(1, raycastHit.point);
                raycastHit.transform.gameObject.SetActive(false);//disabling gameobject collided gameobject
            }
        }
    }
}
using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination 
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        public bool CanMove = true;
        public Transform NavIndicator;
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }
    
        void Update()
        {

            if ( !CanMove)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo)&&!isOverUI)
                {

                    if (m_HitInfo.collider.gameObject.tag == "Activities")
                        return;

                    m_Agent.destination = m_HitInfo.point;
                    NavIndicator.gameObject.SetActive(true);
                    NavIndicator.transform.position = m_HitInfo.point;
                }
            }
        }
    }
}
using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    [RequireComponent(typeof(AudioSource))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for


        [SerializeField] private AudioClip m_WindSound;
        private AudioSource m_AudioSource;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }

        private void playwind()
        {
            m_AudioSource.clip = m_WindSound;
            m_AudioSource.Play();
        }

        Boolean onledge()
        {
            if (GameObject.Find("FPSController").transform.position.z < GameObject.Find("Cube").transform.position.z - 2 - GameObject.Find("Cube").transform.localScale.z / 2)
            {
                Debug.Log("number: " + (GameObject.Find("Cube").transform.position.z - 2 - GameObject.Find("Cube").transform.localScale.z / 2));
                return false;
            }
            return true;
        }

        private void Update()
        {

            if (!onledge())
            {
                Debug.Log("im hereererererer\n");
                playwind();
            }

            if (target != null)
                agent.SetDestination(target.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}

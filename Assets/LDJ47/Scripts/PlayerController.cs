using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections.Generic;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _agentNormalSpeed;

    [SerializeField]
    private float _agentDashSpeed;

    [SerializeField]
    private float _agentTimeDashInOut;

    //[SerializeField]
    //private ParticleSystem _particle;

    [SerializeField]
    private AudioSource _footSteps;

    [SerializeField]
    private Animator _playerAnimator;

    private NavMeshAgent _agent;
    private float _initialAgentSpeed;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _initialAgentSpeed = _agentNormalSpeed;
        //_particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0|| _agent.velocity.magnitude > 0.15f)
        {

            //float x = CrossPlatformInputManager.GetAxis("Horizontal");
            //float z = CrossPlatformInputManager.GetAxis("Vertical");
            
            _playerAnimator.SetInteger("state",1);
            
            //Rotate(x, z);
            Move();

        }
        else {

            _playerAnimator.SetInteger("state",0);
            //_particle.Stop();
        }
    }
    

    void Rotate(float x, float z)
    {
        float angle = Mathf.Atan2(x, z)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,angle,0);

    }

    void Move()
    {
        //if (_particle.isPlaying==false)
        //_particle.Play();
        
        transform.position+=  new Vector3(  _agentNormalSpeed* -CrossPlatformInputManager.GetAxis("Vertical")*Time.deltaTime, 
                                            0, 
                                            _agentNormalSpeed * CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime);
        
        if (_footSteps.isPlaying == false)
        {
            _footSteps.Play();
        }
    }
}

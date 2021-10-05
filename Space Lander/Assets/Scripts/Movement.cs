using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocket;
    AudioSource sound;
    [SerializeField] float thrust=1000;
    [SerializeField] float rotation=3;
    [SerializeField] AudioClip engine;
    [SerializeField] ParticleSystem rightBooster;
    [SerializeField] ParticleSystem leftBooster;                 //PARTICLE SYSTEMS
    [SerializeField] ParticleSystem MainBooster;
    
    void Start()
    {
        rocket=GetComponent<Rigidbody>();       
        sound=GetComponent<AudioSource>();
    }

    
    void Update()
    {
        move();
        rotate();
    }
    
    void move()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ThrustUp();
        }

        else
        {
            StopThrusting();
        }
    }
     void rotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
           RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotation();
        }
    }

   

    void ThrustUp()
    {
        rocket.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);

        if (!MainBooster.isPlaying)
            MainBooster.Play();

        if (!sound.isPlaying)
            sound.PlayOneShot(engine);
    }
  
    void StopThrusting()
    {
        sound.Stop();
        MainBooster.Stop();
    }

   

    void StopRotation()
    {
        leftBooster.Stop();
        rightBooster.Stop();
    }

    void RotateRight()
    {
        applyRotation(-rotation);
        if (!rightBooster.isPlaying)
            rightBooster.Play();
    }

    void RotateLeft()
    {
        applyRotation(rotation);
        if (!leftBooster.isPlaying)
            leftBooster.Play();
    }

    void applyRotation(float r)
    {
        rocket.freezeRotation=true;                                     //freezing rotaion caused by other objects in the physics system
        transform.Rotate(Vector3.forward*r*Time.deltaTime);
        rocket.freezeRotation=false;                                    //unfreezing and letting physics system take over after were done conntrolling
    }

    
}

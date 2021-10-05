using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider : MonoBehaviour
{
        Movement move;
        [SerializeField] float delay=1f;
        AudioSource sound;
        [SerializeField] AudioClip finish;
        [SerializeField] AudioClip crash;
        [SerializeField] ParticleSystem finishParticles;
        [SerializeField] ParticleSystem crashParticles;
        
        
        bool CollisionDisabled=false;
        bool isTransitioning=false;
        void Start() 
        {
            move=GetComponent<Movement>();
            sound=GetComponent<AudioSource>();
            
            
        }
        void Update() 
        {
            CheatCode();
        }
    
        
    void OnCollisionEnter(Collision other)
    {
        if(isTransitioning || CollisionDisabled)
            return;

        switch(other.gameObject.tag)
        {
            case "Finish":
                FinishSequence();
                Debug.Log("Good job!!");
                break;
            case "Respawn":
                Debug.Log("Respawned");
                break;
            default: 
                CrashSequence();
                Debug.Log("You Blew Up"); 
                break;
        }  
    }
    void CrashSequence()
    {
        isTransitioning=true;
        crashParticles.Play();
        sound.Stop();
        move.enabled=false;
        sound.PlayOneShot(crash);
        Invoke("Respawn",delay);
        
    }
    void FinishSequence()
    {
        isTransitioning=true;
        finishParticles.Play();
        sound.Stop();
        move.enabled=false;
        sound.PlayOneShot(finish);
        Invoke("NextLevel",delay);
    }
    void Respawn()
    {
        int CurrentScene=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
               
    }

    void NextLevel()
    {
        

        int CurrentScene=SceneManager.GetActiveScene().buildIndex;
        int NextScene=CurrentScene+1;

        if(NextScene==SceneManager.sceneCountInBuildSettings)
            NextScene=0;

        SceneManager.LoadScene(NextScene);
    }

    void CheatCode()
    {
        if(Input.GetKeyDown(KeyCode.K))
            NextLevel();
        if(Input.GetKeyDown(KeyCode.C))
            CollisionDisabled=!CollisionDisabled;
    }
}

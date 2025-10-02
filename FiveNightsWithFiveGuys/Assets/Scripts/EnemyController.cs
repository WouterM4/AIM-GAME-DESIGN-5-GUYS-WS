using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent ai;
    private GameObject player;
    private AudioSource audioSource;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        ai = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.destination = player.transform.position;
        if (ai.remainingDistance < 3f && !audioSource.isPlaying)
        { 
            audioSource.Play();
        }
    }
}

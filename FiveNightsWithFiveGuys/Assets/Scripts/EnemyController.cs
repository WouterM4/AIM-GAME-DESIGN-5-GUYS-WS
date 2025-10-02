using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent ai;
    private GameObject player;
    private AudioSource audioSource;

    [SerializeField] private GameState gameState;
    private bool isStopped = false;
    
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
    
    private void OnEnable()
    {
        if (gameState != null) gameState.OnVictory += HandleVictory;
    }

    private void OnDisable()
    {
        if (gameState != null) gameState.OnVictory -= HandleVictory;
    }
    
    private void HandleVictory()
    {
        isStopped = true;
        
        // additional stop logic: zero velocity, disable AI, animations etc.
        var rb = GetComponent<Rigidbody>();
        if (rb != null) rb.linearVelocity = Vector3.zero;
        var cc = GetComponent<CharacterController>();
        if (cc != null) { /* nothing needed; just stop moving in Update */ }
        var animator = GetComponent<Animator>();
        if (animator != null) animator.enabled = false;
    }
}

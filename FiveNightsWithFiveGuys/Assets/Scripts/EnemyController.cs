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
        if (gameState.IsVictory) return;

        ai.destination = player.transform.position;
        if (ai.remainingDistance < 3f && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    
    private void OnEnable()
    {
        if (gameState != null) gameState.OnVictory += OnVictory;
    }

    private void OnDisable()
    {
        if (gameState != null) gameState.OnVictory -= OnVictory;
    }

    private void OnVictory()
    {
        isStopped = true;
        if (ai != null) ai.isStopped = true; // stops movement
        if (audioSource != null) audioSource.Stop(); // stop any sound
    }
}
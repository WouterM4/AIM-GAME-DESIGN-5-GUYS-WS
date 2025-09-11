using UnityEngine;

public class PlanetSpinner : MonoBehaviour
{
    [Range(10f, 100f)]
    [SerializeField] private float rotateSpeed;
    public GameObject _object;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}

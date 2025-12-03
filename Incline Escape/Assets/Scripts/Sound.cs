using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    Rigidbody rb;
    bool move = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }
    void Update()
    {
        move = rb.linearVelocity.magnitude > 0f;
        if (move && (!audioSource.isPlaying))
        {
            audioSource.Play();
        }
        else if ((!move) && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}

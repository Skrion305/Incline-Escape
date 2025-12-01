using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    Rigidbody rb;
    bool move = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (audioSource != null)
        {
            audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
        }
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

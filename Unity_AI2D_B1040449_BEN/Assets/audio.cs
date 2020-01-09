using UnityEngine;
using UnityEngine.Events;

public class audio : MonoBehaviour
{
    [Header("音效區域")]
    public AudioClip soundProp;
    [Header("吃東西事件")]
    public UnityEvent onEat;
    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "魚")
        {
            aud.PlayOneShot(soundProp, 1.2f);
            Destroy(collision.gameObject); 
            onEat.Invoke();                
        }
    }
}

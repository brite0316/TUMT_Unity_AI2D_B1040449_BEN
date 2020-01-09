using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum state
    {
        start, notComplete, complete
    }

    public state _state;

    public string sayStart = "能找10隻魚給我嗎";
    public string sayNotComplete = "還沒找到5之魚，等全找到再來找我吧";
    public string sayComplete = "謝了老兄";

    public float speed = 0.1f;

    public bool complete;
    public int countPlayer;
    public int countFinish = 10;

    public GameObject objCanvas;
    public Text textSay;
    public static NPC count;
    public GameObject final;

    public AudioClip soundText;
    private AudioSource aud;

    private void Start()
    {
        count = this;
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "忍者")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "忍者")
            SayClose();
    }

    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish)
        {
            _state = state.complete;

            Invoke("End", 3f);
        } 


        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(sayStart));           
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));     
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));        
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              

        for (int i = 0; i < say.Length; i++)            
        {
            textSay.text += say[i].ToString();
            aud.PlayOneShot(soundText, 0.6f);
            yield return new WaitForSeconds(speed);     
        }
    }

    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countPlayer++;
    }

    void End()
    {
        final.SetActive(true);
    }
}

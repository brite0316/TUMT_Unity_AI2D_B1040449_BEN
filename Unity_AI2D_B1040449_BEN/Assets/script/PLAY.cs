using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PLAY : MonoBehaviour
{
    public int speed = 50;                  
    public float jump = 50f;                        
    public bool pass = false;               
    public bool isGround = false;
    public float hp = 100;
    public UnityEvent onEat;
    private Rigidbody2D r2d;
    private Transform tra;
    public Image hpBar;
    private float hpmax;
    public GameObject final;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();

        hpmax = hp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    private void FixedUpdate()
    {
        Walk();   
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "魚")
        {
            Destroy(collision.gameObject);
            NPC.count.PlayerGet();
            onEat.Invoke();
        }
    }


    void Walk()
    {
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }

    void Turn(int direction)
    {
        tra.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpmax;

        //死亡
        if (hp <= 0) final.SetActive(true);
    }
}

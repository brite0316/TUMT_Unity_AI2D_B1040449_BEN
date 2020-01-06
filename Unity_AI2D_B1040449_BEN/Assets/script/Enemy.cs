using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("忍者")]
    public string foxName = "忍者";
    [Header("速度")]
    public float speed = 5f;
    [Header("傷害")]
    public int damage = 50;

    private Rigidbody2D r2d;
    public Transform checkpoint;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(checkpoint.position, -checkpoint.up * 5);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "忍者")
        {
            Track(collision.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "忍者")
        {
            collision.gameObject.GetComponent<PLAY>().Damage(damage);

            print("123");
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {  
        r2d.AddForce(transform.right * speed);  
        RaycastHit2D hit = Physics2D.Raycast(checkpoint.position, -checkpoint.up, 5, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles =  Vector3.zero;
        }
    }
}

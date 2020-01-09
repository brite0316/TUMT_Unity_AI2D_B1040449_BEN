using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour
{
    public int damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "忍者")
        {
            collision.gameObject.GetComponent<PLAY>().Damage(damage);

            print("123");
        }
    }
}

using UnityEngine;
using System.Collections;
public class metak : MonoBehaviour
{
    public Rigidbody2D metak12;
    void Start()
    {
        //stvranje krutog tijela
        metak12 = GetComponent<Rigidbody2D>();
    }
    //uništavanja metak kad se dogodi kolizija
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.layer == 10)
        {
            Destroy(this.gameObject);
        }
    }
}

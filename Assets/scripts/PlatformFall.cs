using UnityEngine;
using System.Collections;
public class PlatformFall : MonoBehaviour {
    //varijable koje koristimo
    public float fallDelay = 1f;
    private Rigidbody2D rb2d;
    void Start()
    {
        //stvranje krutog tijela
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //kada se dogodi kolizija sa tagom igrač platforma če počet padati kad porođe falldelay
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
        }
        //platforma će se uništiti kad dođe u koliziju za tag-om spike
        if (other.gameObject.CompareTag("spike"))
        {
            Destroy(this.gameObject);
        }
    }
    void Fall()
    {
        //omogućava gravitaciju
        rb2d.isKinematic = false;
    }
}

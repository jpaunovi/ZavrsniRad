using UnityEngine;
using System.Collections;

public class Enemycotroler : MonoBehaviour {
    //varijable koje koristimo u skripti
    public Rigidbody2D rb;
    public Animator anim;
    public bool death1 = false;
    public float bulletspeed = 9f;
    public GameObject clone;
    public bool shootBullet = false;
    public bool faceingRight = false;
    public double move = 0;
    public float maxspeed = 10f;
    public GameObject prefabmetak;
    public GameObject firepozitionEnemy2;
    public double nextFire = 0;
    public double FireRate = 5;
    public GameObject DeathParticel;
    // Use this for initialization
    void Start () {
        //stvranje krutog tijela i animatora
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();       
    }
	void FixedUpdate() {
        //kretanje neprijatenlja
        float move = -1 * (Input.GetAxis("Horizontal"));
        anim.SetFloat("speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxspeed, rb.velocity.y);
        if (move > 0 && !faceingRight)
        {
            flip();
        }
        else if (move < 0 && faceingRight)
        {
            flip();
        }  
    }
    void Update()
    {
        shoot();
    }
    //radi rotaciju objekta
    void flip()
    {
        faceingRight = !faceingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //funkcija za pucanje
    void shoot()
    {

        if (Time.time > nextFire)
        {
            //čekanje do sljedečeg pucanja
            nextFire = (FireRate * 0.5) + Time.time;
            if (!faceingRight)
            {
                //stvaranje i dodavanje vektora metku
                shootBullet = false;
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozitionEnemy2.transform.position.x, firepozitionEnemy2.transform.position.y, transform.position.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = bulletspeed * (-transform.localScale.x) * clone.transform.right;
                clone.transform.Rotate(new Vector3(0, 0, 180));
            }
            else
            {
                //stvaranje i dodavanje vektora metku
                shootBullet = false;
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozitionEnemy2.transform.position.x, firepozitionEnemy2.transform.position.y, transform.position.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = bulletspeed * (-transform.localScale.x) * clone.transform.right;
            }
        }
    }
    //uništavanje objekta kad se dogodi kolizija sa slojem hazard
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
            //stvaranje čestica kad se objekt uništi
            Instantiate(DeathParticel, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}


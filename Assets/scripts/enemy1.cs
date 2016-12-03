using UnityEngine;
using System.Collections;
public class enemy1 : MonoBehaviour
{
    //varijable koje koristimo u skripti
    public bool destrojd = false;
    public Rigidbody2D rb;
    public GameObject prefabmetak;
    public GameObject firepozitionEnemy;
    public GameObject clone;
    public float bulletspeed = 10f;
    public double nextFire = 0;
    public double FireRate = 2;
    public GameObject DeathParticel;
    public bool faceingRight = false;
    // Use this for initialization
    void Start()
    {
        //stvara kruto tijelo
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //kretanje objekta
        float move = -1 * (Input.GetAxis("Horizontal"));
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
    //funkcija koja omogučava pucanje 
    void shoot()
    {
        if (Time.time > nextFire)
        {
            //čekanje do sljedečeg pucanja
            nextFire = (FireRate * 0.5) + Time.time;
            if (!faceingRight)
            {
                //stvaranje i dodavanje vektora metku
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozitionEnemy.transform.position.x, firepozitionEnemy.transform.position.y, transform.position.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = bulletspeed * (-transform.localScale.x) * clone.transform.right;
                clone.transform.Rotate(new Vector3(0, 0, 180));
            }
            else
            {
                //stvaranje i dodavanje vektora metku
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozitionEnemy.transform.position.x, firepozitionEnemy.transform.position.y, transform.position.z), Quaternion.identity);
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
    //radi rotaciju objekta
    void flip()
    {
        faceingRight = !faceingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Playercontroler : MonoBehaviour {
    //varijable koje koristimo u skripti
    public float maxspeed = 10f;
    public bool faceingRight = true;
    public Rigidbody2D rb;
    public Animator anim;
    public bool grounded = false;
    public Transform groundCheck;
    float groundradius = 0.3f;
    public LayerMask whatisground;
    public float jumpforce = 400f;
    public bool jump = true;
    public bool death1 = false;
    public GameObject prefabmetak;
    public GameObject firepozition;
    public float bulletspeed = 5f;
    public GameObject clone;
    public Slider engBar;
    void Start () {
        //stvranje krutog tijela i animatora
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	void FixedUpdate () {
        //pokreće animaciju spawn
        anim.SetBool("spawn", true);
        //provjerava dali je igrač na tlu
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundradius, whatisground);
        //postavlja vrijednost bool 
        anim.SetBool("Ground", grounded);
        //postavlja brzinu padnja ili skaknja
        anim.SetFloat("vSpeed", rb.velocity.y);
        //Provjera dali je objekt igrač na tlu ako nije pušta animaciju jumpFall
        if (!grounded)
        {
            jump = true;
            anim.SetBool("jump", true);
            return;
        }
        jump = false;
        anim.SetBool("jump", false);
        if (!death1)
        {
            //kretanje igrača
            float move = Input.GetAxis("Horizontal");
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
            if (grounded && Input.GetKeyDown(KeyCode.Y))
            {
                anim.SetTrigger("idleshot");
                 shoot();
            }
            if ( Input.GetKeyDown(KeyCode.Escape))
            {
                //prebcivanje na scenu begin i restartanje pozicije
                FristSpawnPoint.postin = 0;
                SceneManager.LoadScene("begin");
            }
        }
    }
    void Update (){
        //omogučava skakanje igrača
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow) && !jump)
        {
            anim.SetBool("Ground", false);
            anim.SetBool("jump", true);        
            rb.AddForce(new Vector2(0, jumpforce));
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
    //uništavanje igrača kad se dogodi kolizija
     void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.layer == 10 )
         {
            StartCoroutine(death());
        }
    }
    IEnumerator death()
    {
        anim = GetComponent<Animator>();
        death1 = true;
        anim.SetBool("death1", true);
        anim.SetBool("jump", false);
        anim.SetTrigger("death");
        anim.SetBool("Ground", true);
        yield return new WaitForSecondsRealtime(1);
        spawn(); 
    }
    //funkcija za pucanje
    void shoot()
    {
        float numberOFshot = engBar.value;
        if ( numberOFshot >0)
        {
            if (!faceingRight)
            {
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozition.transform.position.x, firepozition.transform.position.y, transform.position.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = bulletspeed * transform.localScale.x * clone.transform.right;
                clone.transform.Rotate(new Vector3(0, 0, 180));
                engBar.value = numberOFshot - 1;
            }
            else
            {
                clone = (GameObject)Instantiate(prefabmetak, new Vector3(firepozition.transform.position.x, firepozition.transform.position.y, transform.position.z), Quaternion.identity);
                clone.GetComponent<Rigidbody2D>().velocity = bulletspeed * transform.localScale.x * clone.transform.right;
                engBar.value = numberOFshot - 1;
            }
        }
    }
    //funkcija koja pokreće animaciju spawn
    void spawn()
    {
        death1 = false;
        rb.isKinematic = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        anim.Play("spawn");
        anim.SetBool("death1", false);
    }
}
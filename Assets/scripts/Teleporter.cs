using UnityEngine;
using System.Collections;
public class Teleporter : MonoBehaviour {
    //varijable koje koristimo u skripti
    public Transform PlayerNear;
    public float konzolradius = 0.3f;
    public LayerMask whatisPlayer;
    public bool PlayerIsNear = false;
    public GameObject LokacijaTeleportera;
    public GameObject igrac;
    void FixedUpdate()
    {
        //provjerava da li je igrač blizu
        PlayerIsNear = Physics2D.OverlapCircle(PlayerNear.position, konzolradius, whatisPlayer);
        if (PlayerIsNear)
        {
            //prebacuje objekt Igrač na drugu poziciju
            igrac.transform.position = LokacijaTeleportera.transform.position;
        }
    }
}

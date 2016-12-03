using UnityEngine;
using System.Collections;
public class Openingdors : MonoBehaviour {
    //varijable koje koristimo u skripti
    public Transform PlayerNear;
    float konzolradius = 0.3f;
    public LayerMask whatisPlayer;
    public bool PlayerIsNear = false;
    public GameObject vrata;
    void FixedUpdate()
    {
        //provjeravamo da li je objekt Igrač blizu
        PlayerIsNear = Physics2D.OverlapCircle(PlayerNear.position, konzolradius, whatisPlayer);
        if (PlayerIsNear)
        {
            //otvaramo vrata
            Destroy(vrata);
        }
    }
   }

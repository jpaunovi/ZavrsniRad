using UnityEngine;
using System.Collections;
public class FristSpawnPoint : MonoBehaviour {
    //varijable koje koristimo u skripti
    public GameObject igrac;
    //nove pozicije
    public GameObject[] SpawnPoints;
    //za svaku naovu moguču poziciju
    public bool PlayerIsNear = false;
    public bool PlayerIsNear2 = false;
    public bool PlayerIsNear3 = false;
    public bool PlayerIsNear4 = false;
    public bool PlayerIsNear5 = false;
    public bool PlayerIsNear6 = false;
    public bool PlayerIsNear7 = false;
    public LayerMask whatisPlayer;
    public Transform PlayerNear;
    public Transform PlayerNear2;
    public Transform PlayerNear3;
    public Transform PlayerNear4;
    public Transform PlayerNear5;
    public Transform PlayerNear6;
    public Transform PlayerNear7;
    public GameObject[] Vrata;
    public GameObject[] Platforma;
    float konzolradius = 0.3f;
    public static  int  postin;
    public static Vector3 igracPozicija;
    void Start () {
        //stavlja igrača na poziciju koja je zadnji put aktivirana
        switch (postin) {
            case 0:
                igracPozicija = SpawnPoints[0].transform.position;
                break;
            case 1:
                igracPozicija = SpawnPoints[1].transform.position;
                igrac.transform.position = igracPozicija;
                 Destroy(Vrata[1]);
                break;

            case 2:
                igracPozicija = SpawnPoints[2].transform.position;
                igrac.transform.position = igracPozicija;
                Destroy(Vrata[0]);
                Destroy(Vrata[1]);
                break;
            case 3:
                igracPozicija = SpawnPoints[3].transform.position;
                igrac.transform.position = igracPozicija;
                Destroy(Vrata[0]);
                Destroy(Vrata[1]);
                break;
            case 4:
                igracPozicija = SpawnPoints[4].transform.position;
                igrac.transform.position = igracPozicija;
                break;
            case 5:
                igracPozicija = SpawnPoints[5].transform.position;
                igrac.transform.position = igracPozicija;
                Destroy(Platforma[0]);
                Destroy(Platforma[1]);
                Destroy(Platforma[2]);
                Destroy(Platforma[3]);
                Destroy(Platforma[4]);
                Destroy(Platforma[5]);
                Destroy(Platforma[6]);
                break;
            case 6:
                igracPozicija = SpawnPoints[6].transform.position;
                igrac.transform.position = igracPozicija;
                break;
            case 7:
                igracPozicija = SpawnPoints[7].transform.position;
                igrac.transform.position = igracPozicija;
                break;
        }
}
    void Update()
    {
        //provjerava da li je igrač blizu
        PlayerIsNear = Physics2D.OverlapCircle(PlayerNear.position, konzolradius, whatisPlayer);
        PlayerIsNear2 = Physics2D.OverlapCircle(PlayerNear2.position, konzolradius, whatisPlayer);
        PlayerIsNear3 = Physics2D.OverlapCircle(PlayerNear3.position, konzolradius, whatisPlayer);
        PlayerIsNear4 = Physics2D.OverlapCircle(PlayerNear4.position, konzolradius, whatisPlayer);
        PlayerIsNear5 = Physics2D.OverlapCircle(PlayerNear5.position, konzolradius, whatisPlayer);
        PlayerIsNear6 = Physics2D.OverlapCircle(PlayerNear6.position, konzolradius, whatisPlayer);
        PlayerIsNear7 = Physics2D.OverlapCircle(PlayerNear7.position, konzolradius, whatisPlayer);
        if (PlayerIsNear)
            postin = 1;
        if (PlayerIsNear2)
            postin = 2;
        if (PlayerIsNear3)
            postin = 3;
        if (PlayerIsNear4)
            postin = 4;
        if (PlayerIsNear5)
            postin = 5;
        if (PlayerIsNear6)
            postin = 6;
        if (PlayerIsNear7)
            postin = 7;
        //daaje novu poziciju igraču ovisi o varijabli postin
        switch (postin) {
            case 0:
                igracPozicija = SpawnPoints[0].transform.position;
                break;
            case 1:
                igracPozicija = SpawnPoints[1].transform.position;
                break;
            case 2:
                igracPozicija = SpawnPoints[2].transform.position;
                break;
            case 3:
                igracPozicija = SpawnPoints[3].transform.position;
                break;
            case 4:
                igracPozicija = SpawnPoints[4].transform.position;
                break;
            case 5:
                igracPozicija = SpawnPoints[5].transform.position;
                break;
            case 6:
                igracPozicija = SpawnPoints[6].transform.position;
                break;
            case 7:
                igracPozicija = SpawnPoints[7].transform.position;
                break;
        }
    }
}

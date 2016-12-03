using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour {
    //varijable koje koristimo u skripti
    public bool PlayerIsNear = false;
    public LayerMask whatisPlayer;
    public Transform PlayerNear;
    float konzolradius = 0.3f;
	void Update () {
        //provjerava da li je objekt igrač blizu
        PlayerIsNear = Physics2D.OverlapCircle(PlayerNear.position, konzolradius, whatisPlayer);
        if (PlayerIsNear)
        {
            //restarta lokaciju igrača na poćetak
            FristSpawnPoint.postin = 0;
            //pokreče scenu endgame
            SceneManager.LoadScene("EndGame");
        }
    }
}

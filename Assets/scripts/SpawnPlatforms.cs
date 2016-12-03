using UnityEngine;
using System.Collections;
public class SpawnPlatforms : MonoBehaviour {
    //korištene varijable
    public GameObject[] spawnPoint;
    public GameObject platform;
    public LayerMask whatisPlayer;
    public bool PlayerIsNear = false;
    public Transform PlayerNear;
    float konzolradius = 0.3f;
    void FixedUpdate()
    {
        PlayerIsNear = Physics2D.OverlapCircle(PlayerNear.position, konzolradius, whatisPlayer);
        if (PlayerIsNear)
        {
            //stvara platforme na određenim lokacijama
            Instantiate(platform, new Vector3(spawnPoint[0].transform.position.x, spawnPoint[0].transform.position.y, spawnPoint[0].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[1].transform.position.x, spawnPoint[1].transform.position.y, spawnPoint[1].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[2].transform.position.x, spawnPoint[2].transform.position.y, spawnPoint[2].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[3].transform.position.x, spawnPoint[3].transform.position.y, spawnPoint[3].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[4].transform.position.x, spawnPoint[4].transform.position.y, spawnPoint[4].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[5].transform.position.x, spawnPoint[5].transform.position.y, spawnPoint[5].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[6].transform.position.x, spawnPoint[6].transform.position.y, spawnPoint[6].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[7].transform.position.x, spawnPoint[7].transform.position.y, spawnPoint[7].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[8].transform.position.x, spawnPoint[7].transform.position.y, spawnPoint[7].transform.position.z), Quaternion.identity);
            Instantiate(platform, new Vector3(spawnPoint[9].transform.position.x, spawnPoint[7].transform.position.y, spawnPoint[7].transform.position.z), Quaternion.identity);
        }
    }
}

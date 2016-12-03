using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Pickup : MonoBehaviour {
    //varijable koje koristimo u skripti
    public Slider engBar;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //dodaje vrijednost na naš klizač
            engBar.value++;
            //uništava objekt energija
            Destroy(this.gameObject);
        }
    }
}

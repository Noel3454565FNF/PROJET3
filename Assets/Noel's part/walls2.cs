using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class walls2 : MonoBehaviour
{

    Rigidbody2D rgb;
    public GameObject mymy;
    private int KaboomChance;
    private bool Kabboooooom = true;

    // Start is called before the first frame update
    void Start()
    {
        rgb = mymy.GetComponent<Rigidbody2D>();
        KaboomChance = Random.Range(0, 100);
/*        if (KaboomChance >= 75)
        {
            Kabboooooom = true;
        }
*/    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            if (Kabboooooom == true)
            {
                print("KABOOM");
                SceneManager.LoadScene("KABOOM");
                //KABOOM CUTSCENE
            }
            else
            {
                //dino goes KABOOM
            }
        }
    }
}

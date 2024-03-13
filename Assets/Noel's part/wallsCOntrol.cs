using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class wallsCOntrol : MonoBehaviour
{
    public GameObject Player;

    public GameObject Wup;
    public GameObject Wdown;
    public GameObject Wright;
    public GameObject Wleft;

    public float Facts = 20;

    // Start is called before the first frame update
    void Start()
    {
        Wup.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 20f, 0);
        Wdown.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + -20f, 0);
        Wleft.transform.position = new Vector3(Player.transform.position.x + -20f, Player.transform.position.y, 0);
        Wright.transform.position = new Vector3(Player.transform.position.x + 20f, Player.transform.position.y, 0);
        StartCoroutine(YAHOOO());



    }

    // Update is called once per frame
    void Update()
    {
        
    }
IEnumerator YAHOOO()
    {
        Facts = Facts - 0.3f;
        yield return new WaitForSeconds(0.1f);
        Wup.transform.position = new Vector3(Wup.transform.position.x, Player.transform.position.y + Facts, 0);
        Wdown.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + -Facts, 0);
        Wleft.transform.position = new Vector3(Player.transform.position.x + -Facts, Player.transform.position.y, 0);
        Wright.transform.position = new Vector3(Player.transform.position.x + Facts, Player.transform.position.y, 0);
        StartCoroutine(YAHOOO());
    }

}

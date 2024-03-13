using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footColliderScript : MonoBehaviour
{
    [Header("TileDestroying")]
    [SerializeField] private Transform footLeft;
    [SerializeField] private Transform footRight;
    [SerializeField] private TileDestroy tileDestroy;
    [SerializeField] private PlayerController playerController;
    private bool isChuting;
    private bool isJumping;

    private void Update()
    {
        isJumping = playerController.isJumping;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isChuting)
            {
                StartCoroutine(tileDestroy.DestroyTile(new Vector3(Mathf.Floor(footLeft.position.x), Mathf.Floor(footLeft.position.y), 0)));
                StartCoroutine(tileDestroy.DestroyTile(new Vector3(Mathf.Floor(footRight.position.x), Mathf.Floor(footRight.position.y), 0)));
            }
            isChuting = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isJumping)
        {
            isChuting = true;
        }
    }
}

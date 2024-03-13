using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float Offset;
    private float PlayerRotationY;

    private float transitionPercentage;
    private bool isTransfering = false;
    private Vector3 StartingPoint;
    private Vector3 EndingPoint;


    private void Start()
    {
        PlayerRotationY = Player.rotation.eulerAngles.y;
    }

    private void Update()
    {
        if (isTransfering || PlayerRotationY != Player.rotation.eulerAngles.y)
        {
            isTransfering = true;
            transitionPercentage += Time.deltaTime * 5;

            if (PlayerRotationY == 0)
            {
                transform.position = Vector3.Lerp(StartingPoint, new Vector3(Player.position.x + Offset, Player.position.y + 1, -10), transitionPercentage);
            }
            else
            {
                transform.position = Vector3.Lerp(StartingPoint, new Vector3(Player.position.x - Offset, Player.position.y + 1, -10), transitionPercentage);
            }

            if (transitionPercentage >= 1)
            {
                isTransfering = false;
            }
        }
        else
        {
            transitionPercentage = 0;
            if (PlayerRotationY == 0)
            {
                transform.position = new Vector3(Player.position.x + Offset, Player.position.y + 1, -10);
                StartingPoint = transform.position;
                EndingPoint = new Vector3(Player.position.x - Offset, Player.position.y, -10);
            }
            else
            {
                transform.position = new Vector3(Player.position.x - Offset, Player.position.y + 1, -10);
                StartingPoint = transform.position;
                EndingPoint = new Vector3(Player.position.x + Offset, Player.position.y, -10);
            }
        }
        PlayerRotationY = Player.rotation.eulerAngles.y;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(Target.transform.position);

        if (Vector3.Distance(transform.position, Target.transform.position) > minDistance)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}

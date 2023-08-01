using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 target;
    readonly float speed = 5f;

    void FixedUpdate()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y + 3, -10f);
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.fixedDeltaTime);
    }
}

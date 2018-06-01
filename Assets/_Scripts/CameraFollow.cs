using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float MovSpeed;

    Vector3 CameraPos;

    private void Start()
    {
        Target = _SetUpPlayer.Player.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        CameraPos = new Vector3(Target.position.x, Target.position.y, -10);

        transform.position = Vector3.Lerp(transform.position, CameraPos, Time.deltaTime * MovSpeed);
    }
}

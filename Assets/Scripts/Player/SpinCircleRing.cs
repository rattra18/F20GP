using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCircleRing : MonoBehaviour
{

    public Transform transform;
    private float speed = 50;
    // Start is called before the first frame update
    void Update()
    {
        Rotate();
    }

    // Update is called once per frame
    void Rotate()
    {
        transform.Rotate( 0, speed * Time.unscaledDeltaTime, 0);
    }
}

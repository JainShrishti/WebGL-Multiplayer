using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back * 50f * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEarthController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private Vector3 angles;
    private Quaternion qx = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float angleSen;
    private float angleCos;

    private void FixedUpdate()
    {
        angles.x = angles.x - (rotationSpeed * Time.deltaTime);
        angles.x = angles.x - 360 * Mathf.Floor(angles.x / 360);
        angleSen = Mathf.Sin((Mathf.PI / 180) * angles.x * 1 / 2);
        angleCos = Mathf.Cos((Mathf.PI / 180) * angles.x * 1 / 2);
        qx.Set(angleSen, 0, 0, angleCos);
        r = Quaternion.identity * qx * Quaternion.identity;
        transform.rotation = r;
    }
}
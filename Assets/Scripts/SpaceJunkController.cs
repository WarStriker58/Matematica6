using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunkController : MonoBehaviour
{
    private PlayerController player;

    public PlayerController Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    private Rigidbody _compRigidbody;
    [SerializeField] private int damage;
    private Vector3 playerPosition;
    private Vector3 direction;
    [SerializeField] private float speed;
    [Header("Rotation Elements")]
    [SerializeField] private float rotationSpeed;
    private Vector3 angles;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float angleSen;
    private float angleCos;

    void Start()
    {
        playerPosition = player.transform.position;
        _compRigidbody = GetComponent<Rigidbody>();
        direction = (playerPosition - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        _compRigidbody.velocity = direction * speed;

        angles.y = angles.y - (rotationSpeed * Time.deltaTime);
        angles.y = angles.y - 360 * Mathf.Floor(angles.y / 360);

        angleSen = Mathf.Sin((Mathf.PI / 180) * angles.y * 1 / 2);
        angleCos = Mathf.Cos((Mathf.PI / 180) * angles.y * 1 / 2);
        qy.Set(0, angleSen, 0, angleCos);

        angles.z = angles.z - (rotationSpeed * Time.deltaTime);
        angles.z = angles.z - 360 * Mathf.Floor(angles.z / 360);

        angleSen = Mathf.Sin((Mathf.PI / 180) * angles.z * 1 / 2);
        angleCos = Mathf.Cos((Mathf.PI / 180) * angles.z * 1 / 2);
        qz.Set(0, 0, angleSen, angleCos);

        r = qy * Quaternion.identity * qz;
        transform.rotation = r;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }
}
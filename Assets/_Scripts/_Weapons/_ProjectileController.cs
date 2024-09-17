using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class _ProjectileController : MonoBehaviour
{
    [SerializeReference] private float _Force;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.AddForce(Vector3.forward * _Force, ForceMode.Impulse);
        Destroy(gameObject, 1.2f);
    }

    private void OnCollisionEnter(Collision col)
   {
      Destroy(col.collider.gameObject);
   }
}

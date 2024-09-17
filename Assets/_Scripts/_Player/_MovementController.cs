using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class _MovementController : MonoBehaviour
{
   [Header("Movement Stats")]
   private Rigidbody rb;
   [SerializeReference] private float _moveSpeed;
   private float xInput, yInput;
   private void Start()
   {
      rb = GetComponent<Rigidbody>();
   }
   private void Update()
   {
      xInput = Input.GetAxisRaw("Horizontal");
      yInput = Input.GetAxisRaw("Vertical");

   }

   private void FixedUpdate()
   {
      rb.velocity = new Vector3(xInput * _moveSpeed * Time.fixedDeltaTime, 0, yInput * _moveSpeed * Time.fixedDeltaTime);
   }

   
}

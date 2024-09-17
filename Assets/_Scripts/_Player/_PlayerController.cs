using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    [Header("Aim")]
    [SerializeReference] private LayerMask enemyLayer;
    [SerializeReference] private Transform _aimRadius;
    [SerializeReference] private float _rotationSpeed;
    private List<GameObject> _enemiesInRange;
    private GameObject _closestEnemy;
    private float _distanceFromPlayer;
    private float _currentEnemyDistance;
    
    

    [Header("Attack / Shoot Values")]
    [SerializeReference] private GameObject _attackPrefab;
    [SerializeReference] private Transform _attackPosition;
    [SerializeReference] private float _attackDelay;
    private bool _canAttack;

    private void Awake()
    {
        _canAttack = true;
    }

    private void Update()
    {
        if(_closestEnemy != null)
        transform.LookAt(_closestEnemy.transform.position);
        if(Input.GetButtonDown("Fire1") && _canAttack) StartCoroutine(Shoot());

    }

    private void OnTriggerEnter(Collider _trigger)
    {
        GameObject  _newEnemy = _trigger.gameObject;
        _enemiesInRange.Add(_newEnemy);
        _distanceFromPlayer = Vector3.Distance(transform.position, _newEnemy.transform.position);
        if(_closestEnemy == null)
        {
            _closestEnemy = _newEnemy;
            _currentEnemyDistance = _distanceFromPlayer;
        } else if(_distanceFromPlayer < _currentEnemyDistance && _closestEnemy != null){
            _closestEnemy = _newEnemy;
        } else {
            return;
        }
    }
    
    private IEnumerator Shoot()
    {
        _canAttack = false;
        Instantiate(_attackPrefab, _attackPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(_attackDelay);
        _canAttack = true;
    }
}

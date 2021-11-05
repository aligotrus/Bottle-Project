using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _timeLeft;
    [SerializeField] private float _power = 0f;

    private Rigidbody _rigidbody;
    private readonly Vector3 jumpDerictionY = Vector3.up;
    private readonly Vector3 jumpDerictionZ = Vector3.one;

    public bool IsJumped { get; private set; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _power += 1f;
        }
        if (_timeLeft <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _power += 1f;
                Jump();
                if (IsJumped == true)
                {
                    _power = 0;
                }
            }
        } 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            if (ground)
                IsJumped = true;
        }
    }
    

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ground ground))
        {

            if (ground)
                IsJumped = false;
        }
    }

    private void Jump()
    {
        if (IsJumped)
        {
            _rigidbody.AddForce(jumpDerictionY * _power, ForceMode.Impulse);
            _rigidbody.AddForce(jumpDerictionZ * _power,ForceMode.Impulse);
        }
    }


    
}


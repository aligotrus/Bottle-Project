using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float timeLeft;
    private Rigidbody _rigidbody;
    [SerializeField] private float power = 0f;
    public bool isJumped { get; private set; }
    private readonly Vector3 jumpDeriction = Vector3.up;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                power += 100f;
                this.Jump();
            }
        }
       


    }
    private void Jump()
    {
        if (this.isJumped)
        {
            this._rigidbody.AddForce(this.jumpDeriction * this.power, ForceMode.Impulse);
        }
    }
    

    private void OnCollisionEnter(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
            this.isJumped = true;
    }

    private void OnCollisionExit(Collision other)
    {
        var ground = other.gameObject.GetComponentInParent<Ground>();
        if (ground)
            this.isJumped = false;
    }
}


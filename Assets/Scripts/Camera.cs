using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offset;

    public GameObject Player;
   

   private void Start()
    {
        
            offset = transform.position - Player.transform.position;
               
    }

    
    private void Update()
    {
        if (offset != transform.position - Player.transform.position)
        {
            transform.position = Player.transform.position + offset;
        }
        
    }
}

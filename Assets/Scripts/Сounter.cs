using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class �ounter : MonoBehaviour
{
    private GameObject Player;
    private float startPosition;
    private float endPosition;
    private float score;
    
    public TMP_Text Text ;

    private void OnTriggerEnter(Collider other)
    {
        startPosition = 0;

        if (other.gameObject.TryGetComponent(out Ground ground))
        {
            if (Player.transform.position.z != startPosition)
            {
                endPosition = Player.transform.position.z;
                �ount();
            }
        }
    }

    private void �ount()
    {
        
        score = endPosition - startPosition;
        Text.text = score.ToString();
    }


}

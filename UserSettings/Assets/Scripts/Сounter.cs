using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ñounter : MonoBehaviour
{
    [SerializeField]private GameObject Player;

    private float startPosition;
    private float endPosition;
    private int score;
    
    public TMP_Text Text ;

    private void Start()
    {
        startPosition = Player.transform.position.z;

    }

    private void Update()
    {
        
        if (Player.transform.position.z != startPosition)
        {
            endPosition = Player.transform.position.z;
            Ñount();
        }
    }

    private void Ñount()
    {
        score = (int)(endPosition - startPosition);
        Text.text = score.ToString();
    }


}

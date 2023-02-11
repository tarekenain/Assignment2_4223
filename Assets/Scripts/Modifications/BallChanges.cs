using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BallChanges : MonoBehaviour
{
    public GameObject playerPrefab;

    public Dropdown playerSize;
    private float size = 1.0f;

    public Dropdown playerColor;

    public Slider playerSpeed;
    public Text speedText;
    public static float speed;
    public static float speedMult;
    
    void Update()
    {
        speed = playerSpeed.value;
        speedMult = speed * 100;
        speedText.text = speedMult.ToString("N0") + "%";
    }


    public void ChangeSize()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        switch(playerSize.value)
        {
            case 0:
                size = 0.5f;
                break;
            case 1:
                size = 1.0f;
                break;
            case 2:
                size = 2.0f;
                break;
            default:
                size = 1.0f;
                break;
        }

        
        player.transform.localScale = new Vector3(size,size,size);
        player.transform.localPosition = new Vector3(player.transform.localPosition.x, 0.5f * size, player.transform.localPosition.z);
    }

    public void ChangeColor()
    {
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        switch(playerColor.value)
        {
            case 0:
                player.GetComponent<Renderer>().material.color = Color.white;
                break;
            case 1:
                player.GetComponent<Renderer>().material.color = Color.red;
                break;
            case 2:
                player.GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                player.GetComponent<Renderer>().material.color = Color.blue;
                break;
            default:
                player.GetComponent<Renderer>().material.color = Color.white;
                break;
        }
    }   

    public void ChangeSpeed()
    {
        Time.timeScale = speed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool hasKeyToCastle { get; set; }

    public Player Player { get; private set; }

    public static GameManager InstanceGameManager
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("GameMAnager is null, Bro!");
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}

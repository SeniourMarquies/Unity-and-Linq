using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float CurrentHP;

    public float CurrentHealth => CurrentHP;

    private void Awake()
    {
        CurrentHP = Random.Range(25f, 100f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

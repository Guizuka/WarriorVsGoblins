using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrowController : MonoBehaviour
{
    [SerializeField]
    float speed = 500f;
    
    public GameObject bow;

    private Rigidbody2D rb;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        bow = GameObject.FindGameObjectWithTag("Bow");
        rb.AddForce(new Vector2(bow.transform.position.y, 0) * speed);
        Destroy(gameObject, 1f);
        
    
        
    }

    

    
}


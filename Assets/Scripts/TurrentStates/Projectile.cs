using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;

    public Vector3 Direction { get; set; } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction*speed *Time.deltaTime,Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

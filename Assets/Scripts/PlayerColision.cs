using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerColision : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip, clip1, clipdie;
    private AudioSource source;
    public PlayerAnimation playeranim;
    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<PlayerAnimation>();

        //khai báo 
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playeranim.SetJumping(true);
            
        }
        if (collision.gameObject.CompareTag("water"))
        {
            playeranim.SetSwim(true);
            Debug.Log("......boine");
        }
       
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            var name = collision.attachedRigidbody.name;
            //phá coin
            Destroy(GameObject.Find(name));
            source.PlayOneShot(clip);
        }else if(collision.gameObject.tag == "quai")
        {
            var name = collision.attachedRigidbody.name;
            //phá coin
            Destroy(GameObject.Find(name));
            source.PlayOneShot(clipdie);
        }
    }
}

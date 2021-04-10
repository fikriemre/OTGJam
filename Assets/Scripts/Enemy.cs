using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    GameObject playerObje;
    Rigidbody2D Rb;
    Vector2 playerPoz;
    public float Speed = 100f;
    public Transform[] WayPointsTransform;
    private List<Vector3> WayPoints = new List<Vector3>();

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < WayPointsTransform.Length; i++)
        {
            WayPoints.Add(WayPointsTransform[i].position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.CompareTag("Player"))
        {

        }
        player = collision.gameObject.GetComponent<Player>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (player)
        {
            if (player.gameObject == collision.gameObject)
            {
                player = null;
            }
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            //Oyuncuyu Takip et
           
            Rb.velocity = (player.transform.position - transform.position).normalized * Speed * Time.fixedDeltaTime;
           
            if (Mathf.Abs( player.transform.position.x )- Mathf.Abs(transform.position.x)<=1.02f )
            {
                Debug.Log("dadad");
                Destroy(player.gameObject);
            }

        }
        //vardiya noktası varsa vardiyaya
        else if (WayPoints.Count >= 2)
        {
           
              
                Rb.velocity = (WayPoints[0] - transform.position).normalized * Speed * Time.fixedDeltaTime;
            


        }
        else
        {

        }
        //Idle Bekle

    }

    void Yakaladı()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    GameObject playerObje;
    Rigidbody2D Rb;
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

        StartCoroutine(EnemySound());
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
    int WayPointIndex = 0;
    private void FixedUpdate()
    {
        if (player)
        {
            //Oyuncuyu Takip et

            Rb.velocity = (player.transform.position - transform.position).normalized * Speed * Time.fixedDeltaTime;
            SFXManager.Instance.EnemyDetectedSound();



        }
        //vardiya noktası varsa vardiyaya
        else if (WayPoints.Count >= 2)
        {
            
            Vector3 Distance = WayPoints[WayPointIndex] - transform.position;
            Distance.y = 0;
            Rb.velocity = (Distance) * Speed * Time.fixedDeltaTime;
            if (Mathf.Abs(Distance.x) <= 1)
            {
                WayPointIndex = (WayPointIndex + 1) == WayPoints.Count ? 0 : WayPointIndex + 1;
                transform.Rotate(new Vector3(0, transform.rotation.y + 180, 0));
            }


        }
        else
        {

        }
        //Idle Bekle
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < WayPointsTransform.Length; i++)
        {
            Gizmos.DrawLine(WayPointsTransform[i].position, WayPointsTransform[i - 1].position);
        }
    }

    float voiceDelay = Random.Range(1, 2);
    IEnumerator EnemySound()
    {
        SFXManager.Instance.EnemyVoice();
        yield return new WaitForSeconds(voiceDelay);
    }
}

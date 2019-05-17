using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemy : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform startPos;
    public float enemyLives = 2;
    public float speed;

    [SerializeField]
    private AudioClip deadClip;

    [SerializeField]
    private AudioClip shootClip;


    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            enemyLives--;
            AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position,1f);
            Destroy(other.gameObject);

            if (enemyLives < 0)
            {
                //Play enemy dead audio
                AudioSource.PlayClipAtPoint(deadClip, Camera.main.transform.position,1f);
                Destroy(this.gameObject);
            }


            //Enemy dead animation
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
                ScoreManager.instance.ChangeLives(player.lives);
            }
        }
    }
}

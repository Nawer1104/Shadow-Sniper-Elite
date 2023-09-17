using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2;

    int index = 0;

    private Vector3 startPos;

    public bool isLoop = true;

    public GameObject vfxOnDeath;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 destination = GameManager.Instance.waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < GameManager.Instance.waypoints.Count - 1)
            {
                index++;
            }
            else
            {
                if (isLoop)
                {
                    index = 0;
                    transform.position = startPos;
                }
            }
        }
    }

    public void Destroy()
    {
        GameManager.Instance.enemies.Remove(this);
        GameObject vfx = Instantiate(vfxOnDeath, transform.position, Quaternion.identity);
        Destroy(vfx, 1f);
        Destroy(gameObject);
    }
}
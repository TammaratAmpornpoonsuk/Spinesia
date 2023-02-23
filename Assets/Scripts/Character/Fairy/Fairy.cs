using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    [SerializeField] private GameObject fairyPos;
    [SerializeField] private float speed;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = fairyPos.transform.position;
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //distance = Vector2.Distance(transform.position, fairyPos.transform.position);
        //Vector2 direction = fairyPos.transform.position - transform.position;
        //direction.Normalize();
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, fairyPos.transform.position, speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}

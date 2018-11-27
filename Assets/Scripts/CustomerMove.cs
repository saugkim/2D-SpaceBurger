using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    [SerializeField]
    Vector3 RealPos;
    [SerializeField]
    public float magnitude;
    [SerializeField]
    public float freq;
    [SerializeField]
    public float speed;
    public bool ordered;
    public GameObject startOrderPoint;
    public GameObject orderPoint;
    public GameObject LeavePoint;
    // Use this for initialization
    public GameObject asiakasRef;
    public float swingAngle;
    public List<RuntimeAnimatorController> aliens = new List<RuntimeAnimatorController>();
    public Transform target;
    void Start()
    {
        RealPos = transform.position;
        speed = 0.2f;
        asiakasRef = GameObject.FindGameObjectWithTag("AsiakasCTRL");
        target = startOrderPoint.transform;
        ordered = false;
        freq = 0.5f;
        magnitude = 0.1f;
        swingAngle = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Mathf.Sin(Time.time * freq) > 0.9999f)
        {
            Debug.Log("time: " + Mathf.Sin(Time.time * freq));
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }

        if (target == orderPoint.transform && Vector2.Distance(RealPos, target.position) < 0.1f && !ordered)
        {
            asiakasRef.GetComponent<AsiakasScript>().OrderBurger();
            ordered = true;
        }
        if (target == LeavePoint.transform && Vector2.Distance(RealPos, target.position) < 0.1f && ordered)
        {
            asiakasRef.GetComponent<AsiakasScript>().burgerTimer = Random.Range(180, 300);
            freq = 0.5f;
            magnitude = 0.1f;
            ordered = false;
        }
        RealPos = Vector2.MoveTowards(RealPos, target.position, speed);
        transform.position = (RealPos + transform.up * Mathf.Sin(Time.time * freq) * magnitude) + (transform.right * Mathf.Sin((Time.time * freq * 1.2f) + 100) * magnitude * 1.1f);
        transform.rotation = Quaternion.AngleAxis(swingAngle * Mathf.Sin((Time.time * (freq * 1.25f)) + 50) * magnitude * 5, Vector3.forward);

    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }
    public void StartOrder()
    {
        RealPos = startOrderPoint.transform.position;
        target = orderPoint.transform;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = aliens[Random.Range(0, aliens.Count - 1)];
    }
    public void Leave()
    {
        target = LeavePoint.transform;
    }
}

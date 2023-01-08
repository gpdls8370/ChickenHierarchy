using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class player2 : MonoBehaviour
{
    public int MaxCount2 = 0;
    public int TargetCount = 0;
    public float movePower = 1f;
    public float jumpPower = 1f;

    Vector3 position;
    public float Speed = 1;


    void Start()
    {
        position = transform.position;
    }



    // Update is called once per frame

    void Update()
    {

    }


    void FixedUpdate()
    {
        Move();
        target2Result();

    }


    void Move()        //상하좌우 이동 
    {

        position.x += Speed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        position.y += Speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.position = position;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "target2")
        {
            Destroy(collision.gameObject);                  //타겟2이랑 잘 부딪히면 타켓 없애고 카운트 올리고 점수 2추가
            TargetCount++;
            GameManager.instance.AddScore(2);
        }

        if (collision.gameObject.tag != "target2")
        {
            Destroy(this.gameObject);                        //타켓2말고 다른애랑 잘못 부딪히면 플레이어 없애고 실패화면으로
            GameManager.instance.Result("fail", "2round");

        }
    }

    void target2Result()                                 //애들 다 잡으면(맥스카운트 되면) main2없애고 main3 소환
    {
        if (TargetCount == MaxCount2)
        {
            Instantiate(Resources.Load("main3"), position, transform.rotation);
            Destroy(this.gameObject);
        }
    }


}

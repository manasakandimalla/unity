using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ballmovement : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public GameObject door;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * 100);
        if((rb.position.x)>=500)
        {
            winText.text = "You Win!!!";
            Destroy(rb);
        }
        if((rb.position.x)< -500)
        {
            //winText.text = "Can't get out from here";
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
                  
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 10)
        {
            winText.text = "Door unlocked!";
            Destroy(door.gameObject);

        }
    }
}
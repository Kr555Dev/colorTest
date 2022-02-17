using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce;
    public float sidewayForce;
    public float jumbForce;
    public Material color;
    public string Mycolor;
    public GameObject CompleteLevelScreen;
    public float timeforfirstinvoke;
    public float timebetweeneachinvoke;

    // Start is called before the first frame update
    void Start()
    {
        colorSet();

        Changecolor();
        return;
    }

    private void colorSet()
    {
        int Playercolor = Random.Range(0, 4);

        switch (Playercolor)
        {
            case 0:
                Mycolor = "ObstacleGreen";
                color.color = Color.green;
                break;

            case 1:
                Mycolor = "ObstacleRed";
                color.color = Color.red;
                break;

            case 2:
                Mycolor = "ObstacleYellow";
                color.color = Color.yellow;
                break;

            case 3:
                Mycolor = "ObstacleBlue";
                color.color = Color.blue;
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("space"))
        {
            rb.AddForce(0f, jumbForce * Time.deltaTime, 0f, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (rb.position.y < -1f)
        {
            Invoke("Restart", 0.1f);
            return;
        }
    }


    void Changecolor()
    {
        InvokeRepeating("colorSet", timeforfirstinvoke, timebetweeneachinvoke);
    }

    private void OnCollisionEnter(Collision collides)
    {
        if (collides.collider.tag == Mycolor)
        {
            Debug.Log("You hit the same color");
        }

        if(collides.collider.tag == "ground")
        {
            return;
        }
        if(collides.collider.tag != Mycolor)
        {
            Debug.Log("GAME OVER");
            Invoke("Restart", 1f);
            return;

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "End")
        {
            Debug.Log("Level Complete");
            CompleteLevelScreen.SetActive(true);
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}


using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    [SerializeField] Transform Player;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = Player.position.z.ToString("0");
    }
}

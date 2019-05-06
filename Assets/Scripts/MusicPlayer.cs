using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //testing

    }
}

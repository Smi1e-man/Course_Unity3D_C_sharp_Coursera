using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject PrRock;
    public Sprite GreenR;
 
    public Sprite MagentaR;
 
    public Sprite WhiteR;

    const int SpDelay = 1;

    Timer Timer;

    const int Size = 100;
    int MinX;
    int MaxX;
    int MinY;
    int MaxY;

    int CountRock;
    // Start is called before the first frame update
    void Start()
    {
        MinX = Size;
        MaxX = Screen.width - Size;
        MinY = Size;
        MaxY = Screen.height - Size;

        Timer = gameObject.AddComponent<Timer>();
        Timer.Duration = SpDelay;
        Timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        CountRock = GameObject.FindGameObjectsWithTag("Rock").Length;
        if (Timer.Finished && CountRock <= 2)
        {
            SpawnRock();

            Timer.Duration = SpDelay;
            Timer.Run();
        }
    }

    //Create new Rock
    void SpawnRock()
    {
        Vector3 location = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY),
                                       -Camera.main.transform.position.z);
        Vector3 Wlocation = Camera.main.ScreenToWorldPoint(location);
        GameObject Rock = Instantiate(PrRock) as GameObject;
        Rock.transform.position = Wlocation;

        SpriteRenderer spriteRenderer = Rock.GetComponent<SpriteRenderer>();
        int SpriteNB = Random.Range(0, 3);
        if (SpriteNB == 0)
            spriteRenderer.sprite = GreenR;
        else if (SpriteNB == 1)
            spriteRenderer.sprite = MagentaR;
        else if (SpriteNB == 2)
            spriteRenderer.sprite = WhiteR;
    }
}

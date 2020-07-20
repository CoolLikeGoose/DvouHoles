using UnityEngine;

public class lvls : MonoBehaviour
{
    static public float minx,miny,maxx,maxy;
    static public string code;
    static public int[] KolvoKnopok = new int[9];
    public GameObject ForUISpawner;
    public Transform RoditelCubov;
    private int id;
    
    public GameObject[] KvadratiDlyaKraski = new GameObject[9];
    float grany;
    float granx;
    float camerasize;
    Vector3 camerapos;
    Vector3 pos;
    Vector3 startpos;
   // 
    void Start()
    {
        id = PlayerPrefs.GetInt("Number", 0);
        switch (id)
        {
           case 1: 
                One();
                break;
           case 2: 
                Two();
                break;
           case 3: 
                Three();
                break;
           case 4: 
                Four();
                break;
        }
    }
     public void One()
    {
        //minx<maxx miny<maxy
        this.GetComponent<Camera>().orthographicSize = 58f;
        minx = -56; maxx = -48; miny = -38; maxy = 5f;
         startpos = new Vector3(-76, -36, 20);
         pos = new Vector3(-76, -36, 20);
        camerapos = new Vector3(-52, -11, -1);
        int length = 13;
        int height = 11;
        granx = pos.x + ((length - 1) * 4);
        grany = pos.y + ((height-1) * 4);
        this.transform.position = camerapos;

        code = "00000010000000000010100000000010001000000010000010000010000000100010000000001010000000000011000000000001100000100000101000101000100011100011100";

           
        ForUISpawner.GetComponent<UI_spawner>().LateStart();

        for (int i = 0; i < code.Length; i++)
        {
            
            Instantiate(KvadratiDlyaKraski[code[i] - '0'], pos, Quaternion.identity, RoditelCubov);
            
            KolvoKnopok[code[i] - '0']++;
            
            pos.x += 4f;
            if (pos.x>granx)
            {
                pos.x = startpos.x;
                pos.y += 4f;
            }
        }
    }

    public void Two()
    {
        //границы указывать
        this.GetComponent<Camera>().orthographicSize = 70f;
        minx = -45; maxx = -41; miny = -25; maxy = 10;
        startpos = new Vector3(-76, -36, 20);
        pos = new Vector3(-76, -36, 20);
        camerapos = new Vector3(-42, -4f, -1); 
        int length = 18;
        int height = 16;
        granx = pos.x + ((length - 1) * 4);
        grany = pos.y + ((height - 1) * 4);

        this.transform.position = camerapos;
        code = "000000111111000000000011110000110000000111000000011000001110000110001100001110000110000100011110000000000010011111000000000010011111111100000010011111111110000010011111111111000010011111111111100010001111100111100100001111100111100100000111111111111000000011111111110000000000111111000000";



        ForUISpawner.GetComponent<UI_spawner>().LateStart();

        for (int i = 0; i < code.Length; i++)
        {
            Instantiate(KvadratiDlyaKraski[code[i] - '0'], pos, Quaternion.identity, RoditelCubov);
            KolvoKnopok[code[i] - '0']++;
            pos.x += 4f;
            if (pos.x > granx)
            {
                pos.x = startpos.x;
                pos.y += 4f;
            }
        }
    }

    public void Three()
    {
        this.GetComponent<Camera>().orthographicSize = 68f;
        //границы указывать
        minx = -44; maxx = -40; miny = -27; maxy = 14;
        startpos = new Vector3(-76, -36, 20);
        pos = new Vector3(-76, -36, 20);
        camerapos = new Vector3(-41.5f, -3f, -1);
        int length = 18;
        int height = 16;
        granx = pos.x + ((length - 1) * 4);
        grany = pos.y + ((height - 1) * 4);

        code = "000001111111100000000110000000011000001000000000000100001000000000000100010000001100000010011001000000100110010001000000100010011000000000000110010000000000011010010000000000122110001000001101121210001000012212211210001000012112212210001000112221101100000111001221000100000000000110111000";


        this.transform.position = camerapos;
        ForUISpawner.GetComponent<UI_spawner>().LateStart();

        for (int i = 0; i < code.Length; i++)
        {
            Instantiate(KvadratiDlyaKraski[code[i] - '0'], pos, Quaternion.identity, RoditelCubov);
            KolvoKnopok[code[i] - '0']++;
            pos.x += 4f;
            if (pos.x > granx)
            {
                pos.x = startpos.x;
                pos.y += 4f;
            }
        }
    }
    public void Four()
    {
        this.GetComponent<Camera>().orthographicSize = 65f;
        //границы указывать
        camerapos = new Vector3(-48, -0, -1);
        minx = -50; maxx = -46; miny = -27; maxy = 11;
        startpos = new Vector3(-76, -36, 20);
        pos = new Vector3(-76, -36, 20);
        int length = 15;
        int height = 15;
        granx = pos.x + ((length - 1) * 4);
        grany = pos.y + ((height - 1) * 4);

        code = "000001111100000000115555511000001555555555100015555111155510015555555515510155555555555551155111555111551151011151011151151001111001151111111111111111015555555555510015555555555510001555555555100000115555511000000001111100000";


        this.transform.position = camerapos;
        ForUISpawner.GetComponent<UI_spawner>().LateStart();

        for (int i = 0; i < code.Length; i++)
        {
            Instantiate(KvadratiDlyaKraski[code[i] - '0'], pos, Quaternion.identity, RoditelCubov);
            KolvoKnopok[code[i] - '0']++;
            pos.x += 4f;
            if (pos.x > granx)
            {
                pos.x = startpos.x;
                pos.y += 4f;
            }
        }
    }


}

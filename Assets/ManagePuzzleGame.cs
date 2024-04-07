using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managePuzzleGame : MonoBehaviour
{
    float timer;
    bool cardsShuffled = false;
    public Image piece;
    public Image placeholder;
    float phWidth, phHeight;
    int[] newArray = new int[25];
    // Start is called before the first frame update
    void Start()
    {
        createPlaceHolders();
        createPieces();
        shufflePieces();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 4 && !cardsShuffled)
        {
            shufflePieces();
            cardsShuffled = true;
        }
    }

    public void createPlaceHolders()
    {
        phWidth = 100;
        phHeight = 100;
        float nbRows, nbColumns;
        nbRows = 5; nbColumns = 5;
        for(int i = 0; i < 25 ; i++)
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("rightSide").transform.position;
            float row, column;
            row = i % 5;
            column = i / 5;
            Vector3 phPosition = new Vector3(centerPosition.x + phWidth * (row - nbRows / 2), centerPosition.y - phHeight * (column - nbColumns / 2), centerPosition.z);
            Image ph = (Image)(Instantiate(placeholder, phPosition, Quaternion.identity));
            ph.tag = "" + (i + 1);
            ph.name = "PH" + (i + 1);
            ph.transform.SetParent(GameObject.Find("Canvas").transform);
        }
    }

    public void createPieces()
    {
        phWidth = 100;
        phHeight = 100;
        float nbRows, nbColumns;
        nbRows = 5;
        nbColumns = 5;

        for( int i = 0;i < 25 ; i++) 
        {
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("leftSide").transform.position;
            float row, column;
            row = i % 5;
            column = i / 5;
            Vector3 phPosition = new Vector3(centerPosition.x + phWidth * (row - nbRows / 2), centerPosition.y - phHeight * (column - nbColumns / 2), centerPosition.z);
            Image ph = (Image)(Instantiate(piece,phPosition,Quaternion.identity));
            ph.tag = "" + (i + 1);
            ph.name = "Piece" + ( i + 1);
            ph.transform.SetParent(GameObject.Find("Canvas").transform);
            Sprite[] allSprites = Resources.LoadAll<Sprite>("MonaLisa");
            Sprite s1 = allSprites[i];
            ph.GetComponent<Image>().sprite = s1;

        }
    }

    void shufflePieces()
    {
        for (int i = 0; i < 25; i++)
        {
            newArray[i] = i;
        }
        
        int tmp;
        for (int t = 0; t < 25; t++)
        {
            tmp = newArray[t];
            int r = Random.Range(t, 10);
            newArray[t] = newArray[r];
            newArray[r] = tmp;
        }
       
        for(int i = 0; i < 25 ; i++)
        {
            float row, nbRows, nbColumns, column;
            nbRows = 5;
            nbColumns = 5;
            row = (newArray[i]) % 5;
            column = (newArray[i]) / 5;
            Vector3 centerPosition = new Vector3();
            centerPosition = GameObject.Find("leftSide").transform.position;
            var g = GameObject.Find("Piece" + (i + 1));
            Vector3 newPosition = new Vector3(centerPosition.x + phWidth*(row-nbRows/2), centerPosition.y - phHeight * (column-nbColumns/2),centerPosition.z);
            g.transform.position = newPosition;
            g.GetComponent<DragAndDrop>().initCardPosition();
        }
    }
}

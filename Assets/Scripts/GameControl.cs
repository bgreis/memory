using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private GameObject token;
    List<int> faceindexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
    public static System.Random rnd = new System.Random();
    public int shuffleNum;
    int[] visibleFaces = { -1, -2, };
    
    private void Start()
    {
        int originalLength = faceindexes.Count;
        float yPosition = 3f;
        float xPosition = -1f;
        

        for(int i = 0; i < 11; i++)
        {
            shuffleNum = rnd.Next(0, (faceindexes.Count));

            var temp = Instantiate(token, new Vector3(
                xPosition, yPosition, 0),
                Quaternion.identity);
            temp.GetComponent<MainToken>().faceIndex = faceindexes[shuffleNum];
            
            faceindexes.Remove(faceindexes[shuffleNum]);
            xPosition += 2;

            if (i == (originalLength/2 - 4))
            {
                yPosition = 1;
                xPosition = -3;
            }

            if (i == (originalLength/2))
            {
                yPosition = -1;
                xPosition = -3;
            }

            token.GetComponent<MainToken>().faceIndex = faceindexes[0];
        }
    }
    public bool TwoCardsUp()
    {
        bool cardsUp = false;
        if(visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
        {
            cardsUp = true;
        }
        return cardsUp;
    }

    public void AddVisibleFace(int index)
    {
        if(visibleFaces[0] == -1)
        {
            visibleFaces[0] = index;
        }
        else if (visibleFaces[1] == -2)
        {
            visibleFaces[1] = index;
        }
    }

    public void RemoveVisibleFace(int index)
    {
        if (visibleFaces[0] == index)
        {
            visibleFaces[0] = -1;
        }
        else if (visibleFaces[1] == index)
        {
            visibleFaces[1] = -2;
        }
    }

    public bool CheckMatch()
    {
        bool success = false;
        if(visibleFaces[0] == visibleFaces[1])
        {
            visibleFaces[0] = -1;
            visibleFaces[1] = -2;
            success = true;
        }
        return success;
    }

    private void Awake()
    {
        token = GameObject.Find("Token");
    }

}

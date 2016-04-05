using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class ApplePicker : MonoBehaviour
{

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    string dateTime;

    // Use this for initialization
    void Start()
    {
        dateTime = DateTime.Now.ToString();
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    void Update()
    {
        UserValidation.timeElapsed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Main Player Menu");
    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if (basketList.Count == 0)
        {
            UserValidation.userList[UserValidation.activeUserIndex].AddGame("Apple Picker", Basket.score, UserValidation.userList[UserValidation.activeUserIndex].username, dateTime);
            UserValidation.Save();
            SceneManager.LoadScene("Main Player Menu");
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public Material material;
    private float offset;
    public GameObject coin;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateQuestion());
    }

    // Update is called once per frame
    IEnumerator AnimateQuestion()
    {
        while(true)
        {
            material.SetTextureOffset("_MainTex", new Vector2(0, offset));
            yield return new WaitForSeconds(0.5f);
            offset += 0.2f;
            if (offset > 0.8f)
            {
                offset = 0f;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1))
        {
            StartCoroutine(AnimateCoin());
            GameManager.coins++;
            GameManager.points += 100;
        }
    }

    IEnumerator AnimateCoin()
    {
        GameObject animatedCoin = Instantiate(coin, transform.position, Quaternion.Euler(0, -90, 0));
        Vector3 finalPosition = animatedCoin.transform.position + Vector3.up * 3;
        float animationTime = 0f;
        while (animationTime < 0.5f)
        {
            animationTime += Time.deltaTime;
            animatedCoin.transform.position = Vector3.Lerp(animatedCoin.transform.position, finalPosition, animationTime/1f);
            yield return null;
        }

        animatedCoin.transform.position = finalPosition;
        Destroy(animatedCoin);
    }
}
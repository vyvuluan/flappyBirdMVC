﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;
        float width = sr.bounds.size.x;
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;
        tempScale.x = worldWidth / width;
        transform.localScale = tempScale;
        transform.position = new Vector3(0, -worldHeight/2, 0);
    }

}

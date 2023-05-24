using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    #region BIRD
    [Header("Bird")]
    [Space(8.0f)]
    [Tooltip("Trọng lực")]
    public float gravitationalForce = 9.8f;
    [Tooltip("Lực nhảy truyền vào")]
    public float bounceForce = 4;
    #endregion

    #region PIPE
    [Header("Pipe")]
    [Space(8.0f)]
    [Tooltip("Tốc độ của cống")]
    public float speed = 3;
    [Tooltip("Số lượng cống")]
    public int pipePoolSize = 2;
    [Tooltip("Khoảng cách giữa các cống")]
    public float pipeSpacing = 4f;
    #endregion

    #region BULLET
    [Header("Bullet")]
    [Space(8.0f)]
    [Tooltip("số lượng đạn trong pool")]
    public int poolBulletSize = 7;
    [Tooltip("tốc độ viên đạn")]
    public float bulletSpeed = 4;
    #endregion

}

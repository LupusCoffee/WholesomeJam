using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    GameObject AreaOfInfluenceTransform;

    private void Start()
    {
        AreaOfInfluenceTransform = gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        this.gameObject.transform.localScale = AreaOfInfluenceTransform.gameObject.GetComponent<CircleCollider2D>().radius*2 * AreaOfInfluenceTransform.transform.localScale;
    }
}

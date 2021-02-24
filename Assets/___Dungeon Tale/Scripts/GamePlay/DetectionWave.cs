using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * change log version 3.0 added reference to sprite and sprite mask
 * implemented transformation scaleing on both 
 * during DEstroyWave() to make shaded circle grow and shrink with wave
 */

public class DetectionWave : MonoBehaviour
{
    [SerializeField] Vector2SO[] enemypos;
    [SerializeField] SpriteMask mask;
    [SerializeField] GameObject lightmask;
    [SerializeField] GameObject circle;
    [SerializeField] BoolSO wave;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int vertexCount = 40;
    [SerializeField] float lineWidth = 0.2f;
    [SerializeField] float radius=3.0f;
    [SerializeField] Button detectionButton;

 
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        wave.state = false;

    }


    IEnumerator DestroyWave()
    {
        SetupCircle();
    
        mask.transform.localScale *=2;
        lightmask.transform.localScale *= 2;
        Collider2D[] rays = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var item in rays)
        {
            if (item.CompareTag("Enemy"))
            {
                lineRenderer.startColor = Color.red;
                lineRenderer.endColor = Color.red;
                item.gameObject.layer = 8;
            }
        }
        yield return new WaitForSeconds(2);
        mask.transform.localScale = Vector3.one * 3;
        lightmask.transform.localScale = Vector3.one * 3;
        lineRenderer.positionCount = 0;
        wave.state = false;
    }

    IEnumerator ActivatingWave()
    {

        yield return new WaitForSeconds(5);
        detectionButton.interactable = true;
        

    }
    public void IsActiveWave()
    {
        if (detectionButton.IsInteractable())
        {
            wave.state = true;
            detectionButton.interactable = false;
            StartCoroutine(DestroyWave());
            StartCoroutine(ActivatingWave());
        }
    }
    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount + 1;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}

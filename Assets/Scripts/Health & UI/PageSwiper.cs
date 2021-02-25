using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    private Vector3 panelLocation;

    public GameObject startpanel;
    public GameObject leftpanel;
    public GameObject rightpanel;

    private Vector3 startpanelLocation;
    private Vector3 leftpanelLocation;
    private Vector3 rightpanelLocation;
    private Vector3 newLocation;

    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int currentIndex;

    public SelectButtons selectButtons;

    void Start()
    {
        panelLocation = transform.position;
        startpanelLocation = startpanel.transform.position;
        leftpanelLocation = leftpanel.transform.position;
        rightpanelLocation = rightpanel.transform.position;
        currentIndex = 1;

    }

    public void OnDrag(PointerEventData data)
    {
        float difference = (data.pressPosition.x - data.position.x) / 192;
        transform.position = (panelLocation - new Vector3(difference, 0, 0));
    }

    public void SetPosition(int index)
    {
        currentIndex = index;
        GetLocation();
        StartCoroutine(SmoothMove(transform.position, newLocation, easing));
        panelLocation = newLocation;
        selectButtons.GetPosition(currentIndex);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold) {
            newLocation = panelLocation;
            if(percentage > 0)
            {
                if(currentIndex == 0)
                {

                } else
                {
                    currentIndex --;
                }
                GetLocation();
            } else if(percentage < 0)
            {
                if(currentIndex == 2)
                {

                } else
                {
                    currentIndex ++;
                }
                GetLocation();
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
            selectButtons.GetPosition(currentIndex);
        } else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
            selectButtons.GetPosition(currentIndex);
        }
    }

    public void GetLocation()
    {
        switch(currentIndex)
        {
            case 2:
                newLocation = rightpanelLocation;
                currentIndex = 2;
                break;
            case 1:
                newLocation = startpanelLocation;
                currentIndex = 1;
                break;
            case 0:
                newLocation = leftpanelLocation;
                currentIndex = 0;
                break;
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while(t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}

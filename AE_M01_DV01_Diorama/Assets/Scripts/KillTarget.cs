using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillTarget : MonoBehaviour
{
    public TMP_Text scoreText;

    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;

    Transform camera;
    private float countDown;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        score = 0;
        countDown = timeToSelect;

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider.gameObject == target)
            {
                isHitting = true;
            }
        }

        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                // on target
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped)
                {
                    hitEffect.Play();
                }
            }
            else
            {
                //killed
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                scoreText.text = "Score: " + score;
                countDown = timeToSelect;
                SetRandomPosition();
            }
        }
        else
        {
            //reset
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 0.5f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }
}

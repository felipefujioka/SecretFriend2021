using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class QuestController : MonoBehaviour
    {
        public List<Transform> Waypoints;
        public ParticleSystem Firefly;
        public AudioSource Bgm;
        public AudioSource EndSound;
        public AudioSource CollectSound;

        public CanvasGroup FadeOut;
        
        private int index;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("player"))
            {
                if (index < Waypoints.Count)
                {
                    CollectSound.Play();
                    Firefly.transform.DOMove(Waypoints[index++].position, 1f).Play();
                    if (index == Waypoints.Count - 1)
                    {
                        Bgm.Play();
                    }
                }
                else
                {
                    FadeOut.DOFade(1, 2).Play().OnComplete(() =>
                    {
                        SceneManager.LoadScene("End");
                    });
                    EndSound.Play();
                }
                
            }
        }
    }
}
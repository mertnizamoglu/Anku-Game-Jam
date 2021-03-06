using System;
using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Concretes;
using ANKU.Enums.Concretes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ANKU.Managers.Concretes
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private AudioSource ghostHitSound;
        [SerializeField] private AudioSource villianModeCounterSound;
        [SerializeField] private AudioSource magicFireSound;
        [SerializeField] private AudioSource puzzleFailSound;
        
        [SerializeField] private AudioSource villianBGMusic;
        [SerializeField] private AudioSource angelBGMusic;

        
        private void Awake()
        {
            SingletonObject();
        }
        
        private void SingletonObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


        public void PlayGhostHitSound()
        {
            if(ghostHitSound.isPlaying) return;
            ghostHitSound.pitch = Random.Range(1, 2);
            ghostHitSound.PlayDelayed(.3f);
        }   
        public void PlayVillianModeCountSound(bool isLoop)
        {
            villianModeCounterSound.loop = isLoop;
            if(villianModeCounterSound.isPlaying) return;

            villianModeCounterSound.Play();
        }

        public void PlayMagicFireSound()
        {
            // if(magicFireSound.isPlaying) return;
            magicFireSound.pitch = Random.Range(1.0f, 2.0f);
            magicFireSound.Play();
        }

        public void PlayPuzzleFailSound()
        {
            if(puzzleFailSound.isPlaying) return;
            
            StopAngelSound();
            StopVillianSound();
            puzzleFailSound.Play();
        }

        public void PlayPuzzleSuccessSound()
        {
            
        }

        public void PlayVillianSound()
        {
            villianBGMusic.Play();
        }
        public void PlayAngelSound()
        {
            angelBGMusic.Play();
        }
        public void StopVillianSound()
        {
            villianBGMusic.Stop();
        }
        public void StopAngelSound()
        {
            angelBGMusic.Stop();
        }
    }
}
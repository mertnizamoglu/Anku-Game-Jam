using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ANKU.Animations.Concretes
{
    
    public class AnimationManager : MonoBehaviour
    {
        public static AnimationManager Instance { get; private set; }
        [SerializeField] private GameObject door;
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
        public void PlayAnimation()
        {
            door.transform.Rotate(0, 90, 0);
        }
    }
}

using System;
using TMPro;
using UnityEngine;

namespace Game
{
    public class CharacterController : MonoBehaviour
    {
        public GameObject Flashlight;
        public GameObject ActionUI;
        public GameObject QuestController;

        private bool canPickFlashlight;
        private bool pickedFlashlight;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Bag") && !pickedFlashlight)
            {
                ActionUI.SetActive(true);
                canPickFlashlight = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Bag") && !pickedFlashlight)
            {
                ActionUI.SetActive(false);
                canPickFlashlight = false;
            }
        }

        private void Update()
        {
            if (canPickFlashlight && Input.GetKeyDown(KeyCode.F))
            {
                pickedFlashlight = true;
                Flashlight.SetActive(true);
                ActionUI.GetComponent<TextMeshProUGUI>().text = "Siga a luz";
                QuestController.SetActive(true);
            }
        }
    }
}
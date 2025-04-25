using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Room1
{
    public class TurnOffLight : MonoBehaviour
    {
        [SerializeField] private Material unlit;
        [SerializeField] private Material lit;
        [SerializeField] private GameObject pointLight;
        [SerializeField] private ParticleSystem explode;
        [SerializeField] private Renderer bulbRenderer;
        private bool destroyed = false;

        private XRSimpleInteractable simpleInteractable;

        private void Awake()
        {
            simpleInteractable = GetComponent<XRSimpleInteractable>();
            
            if (simpleInteractable != null)
            {
                simpleInteractable.selectEntered.AddListener(TurnOffLightOnSelect);
            }
            else
            {
                Debug.LogError("XRSimpleInteractable component missing!", this);
            }
        }

        private void TurnOffLightOnSelect(SelectEnterEventArgs args)
        {
            if (unlit && bulbRenderer && pointLight && !destroyed){
                bulbRenderer.material = unlit;
                pointLight.SetActive(false);
                explode.Play();
                destroyed = true;
            }
        }
        private void OnDestroy()
        {
            if (simpleInteractable != null)
            {
                simpleInteractable.selectEntered.RemoveListener(TurnOffLightOnSelect);
            }
        }
    }
}
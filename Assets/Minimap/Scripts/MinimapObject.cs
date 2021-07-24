using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArenaMinimap
{
    
    public class MinimapObject : MonoBehaviour
    {
        [Tooltip("TYPE of Object: ALLY, ENEMY, PLAYER, UNIQUE")]
        public TYPE objectType;
        [Tooltip("Unique Marker Sprite")]
        public Sprite markerSprite;
        [Tooltip("Target's transform, used to set the Marker Target")]
        public Transform targetTransform;
        [Tooltip("Marker Prefab that will be instantiated on Game Start")]
        public MinimapMarker marker;
        [Tooltip("Manager that will control the Minimap Objects")]
        public MinimapManager minimapManager;
        [Tooltip("Enable Marker on GameObject Awake")]
        public bool enableOnAwake = false;
        [Tooltip("Should the marker follow the parent object?")]
        public bool shouldFollow = true;

        //Check if Object was initialized
        private bool _init = false;

        public void Awake()
        {
            if(enableOnAwake)
            {
                Invoke("EnableMarker",0.5f);
            }
        }

        //Manually sets the Marker Type
        public void SetType(TYPE p_type)
        {
            objectType = p_type;
            marker.SetMarkerType(p_type);
        }

        public void ShouldFollow(bool p_follow)
        {
            shouldFollow = p_follow;
            marker.SetFollow(p_follow);
        }

        //Enables the Marker. Must be 
        public void EnableMarker()
        {
            if(minimapManager==null)
            {
                minimapManager = FindObjectOfType<MinimapManager>();
            }
            if(marker!=null)
            {
                if(!marker.isActiveAndEnabled)
                {
                    marker.gameObject.SetActive(true);
                }
                if(!_init)
                {
                    marker = Instantiate(marker);
                    marker.Initialize(targetTransform);
                    minimapManager.AddNewMarker(marker, objectType);
                    marker.SetFollow(shouldFollow);
                    _init = true;
                }
                else
                {
                    minimapManager.ResetMarkerSprite(marker);
                }
                if(markerSprite!=null && objectType==TYPE.UNIQUE)
                {
                    marker.SetSprite(markerSprite);
                }
            }
        }

        //Change Marker Sprite to death sprite
        public void MarkerDeath()
        {
            if(_init)
            {
                minimapManager.MarkerDied(marker);
            }
        }

        //Disables the Marker's GameObject
        public void DisableMarker()
        {
            if (marker.isActiveAndEnabled)
            {
                marker.gameObject.SetActive(false);
            }
        }
    }
}

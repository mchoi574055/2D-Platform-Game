using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArenaMinimap
{ 
    //UNIQUE Markers are not affected by death. Use UNIQUE types for special markers that will not change (items, constructions, etc)
    public enum TYPE
    {
        PLAYER,
        ENEMY,
        ALLY,
        UNIQUE
    }

    public class MinimapManager : MonoBehaviour
    {
        [Tooltip("Render Texture on which Minimap Camera will be rendered")]
        public RenderTexture cameraTexture;
        [Tooltip("Layer of objects that will be shown on minimap")]
        public LayerMask minimapLayer;
        [Tooltip("Camera used for rendering the minimap")]
        public MinimapCamera minimapCamera;
        [Tooltip("Prevents Main Camera from rendering minimap LayerMask")]
        public bool disableMinimapLayerOnMainCamera = false;
        public Camera mainCamera;
        [Tooltip("Default sprite for allies")]
        public Sprite allySprite;
        [Tooltip("Death sprite for allies")]
        public Sprite allyDeathSprite;
        [Tooltip("Default sprite for player")]
        public Sprite playerSprite;
        [Tooltip("Death sprite for Player")]
        public Sprite playerDeathSprite;
        [Tooltip("Default sprite for enemies")]
        public Sprite enemySprite;
        [Tooltip("Death sprite for enemies")]
        public Sprite enemyDeathSprite;

        private List<MinimapMarker> _markerList;

        //initializes the MinimapCamera
        void Awake()
        {
            _markerList = new List<MinimapMarker>();
            minimapCamera.MInitialize(minimapLayer);
            if (cameraTexture != null) minimapCamera.ApplyRenderTexture(cameraTexture);
            if(disableMinimapLayerOnMainCamera && mainCamera!=null)
            {
                var __newMask = mainCamera.cullingMask & ~(minimapLayer);
                mainCamera.cullingMask = __newMask;
            }
        }
        
        //Updates all Minimap Markers on the MarkerList
        void Update()
        {
            if(_markerList!=null)
            {
                foreach (MinimapMarker __marker in _markerList)
                {
                    if (__marker.isActiveAndEnabled)
                    {
                        __marker.MUpdate();
                    }
                }
            }
        }

        //Add a new marker of TYPE p_type on the MarkerList
        public void AddNewMarker(MinimapMarker p_marker, TYPE p_type)
        {
            if (!_markerList.Contains(p_marker))
            {
                switch (p_type)
                {
                    case TYPE.PLAYER:
                        p_marker.SetSprite(playerSprite);
                        p_marker.SetMarkerType(TYPE.PLAYER);
                        break;
                    case TYPE.ALLY:
                        p_marker.SetSprite(allySprite);
                        p_marker.SetMarkerType(TYPE.ALLY);
                        break;
                    case TYPE.ENEMY:
                        p_marker.SetSprite(enemySprite);
                        p_marker.SetMarkerType(TYPE.ENEMY);
                        break;
                    case TYPE.UNIQUE:
                        p_marker.SetMarkerType(TYPE.UNIQUE);
                        break;
                }
                _markerList.Add(p_marker);               
            }
        }
        //Set Death Sprite for marker
        public void MarkerDied(MinimapMarker p_marker)
        {
            switch (p_marker.GetMarkerType())
            {
                case TYPE.PLAYER:
                    p_marker.SetSprite(playerDeathSprite);
                    break;
                case TYPE.ALLY:
                    p_marker.SetSprite(allyDeathSprite);
                    break;
                case TYPE.ENEMY:
                    p_marker.SetSprite(enemyDeathSprite);
                    break;
            }
            p_marker.SetFollow(false);
        }

        //Resets Marker sprite to Default TYPE sprite
        public void ResetMarkerSprite(MinimapMarker p_marker)
        {
            switch (p_marker.GetMarkerType())
            {
                case TYPE.PLAYER:
                    p_marker.SetSprite(playerSprite);
                    break;
                case TYPE.ALLY:
                    p_marker.SetSprite(allySprite);
                    break;
                case TYPE.ENEMY:
                    p_marker.SetSprite(enemySprite);
                    break;
            }
            p_marker.SetFollow(true);
        }
    }
}

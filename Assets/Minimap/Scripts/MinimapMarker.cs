using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArenaMinimap
{
    public class MinimapMarker : MonoBehaviour {

        //Marker's target/origin
        private Transform _targetTransform;
        //Marker's sprite renderer
        private SpriteRenderer _renderer;
        //Type of Marker: PLAYER, ALLY, ENEMY, UNIQUE"
        private TYPE _markerType;
        //Should the marker follow the target's movement?
        private bool _shouldFollow = true;
       

        //Initialize the marker by setting the target
        public void Initialize(Transform p_target)
        {
            _targetTransform = p_target;
        }

        //Update method used by the MinimapManager
        public void MUpdate()
        {            
            //if has a target and should follow, follow the target's transform.position
            if(_targetTransform!=null && _shouldFollow)
            {                
                transform.position = _targetTransform.position;
            }
        }
        //Set if Marker will follow the Target's transform
        public void SetFollow(bool p_shouldFollow)
        {
            _shouldFollow = p_shouldFollow;
        }

        //Set the Marker's sprite
        public void SetSprite(Sprite p_sprite)
        {
            if(p_sprite!=null)
            {
                //Find _renderer if null, set renderer sprite if not
                if (_renderer != null) _renderer.sprite = p_sprite;
                else
                {
                    _renderer = GetComponent<SpriteRenderer>();
                    if (_renderer != null) _renderer.sprite = p_sprite;
                }
            }
        }

        //Get Marker Type
        public TYPE GetMarkerType()
        {
            return _markerType;
        }
        //Set Marker Type
        public void SetMarkerType(TYPE p_type)
        {
            _markerType = p_type;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class AnimatedTile : TileBase
{
    public Sprite[] animationSprites;
    public float animationSpeed = 1f;

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        tileAnimationData.animatedSprites = animationSprites;
        tileAnimationData.animationSpeed = animationSpeed;
        tileAnimationData.animationStartTime = 0;
        return true;
    }
}

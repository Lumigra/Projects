using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrderSetter
{
    public SpriteOrderSetter(SpriteRenderer renderer, int LaneNo)
    {
        SetSpriteOrder(renderer, LaneNo);
    }
    public void SetSpriteOrder(SpriteRenderer renderer, int LaneNo)
    {
        switch (LaneNo)
        {
            case 1:
                renderer.sortingLayerName = "BackLane";
                break;
            case 2:
                renderer.sortingLayerName = "MidLane";

                break;
            case 3:
                renderer.sortingLayerName = "FrontLane";
                break;
        }
    }
}

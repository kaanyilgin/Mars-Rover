﻿using System.Collections.Generic;

namespace MarsRover.BL.Map
{
    public class MarsMap : MapBase
    {
        public MarsMap(Point point) : base(point)
        {
        }

        public override void Discover()
        {
            foreach (var rover in _rovers)
            {
                rover.Move();
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Food_Shortage
{
    public class Robot : IIdentifiable, IRobot
    {
        public Robot(string model, string id)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}

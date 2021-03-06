﻿using System;

namespace HispterOfTheDay.Domain.Model
{
    public class Image
    {
        protected bool Equals(Image other)
        {
            return string.Equals(ImageData, other.ImageData);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Image)obj);
        }

        public override int GetHashCode()
        {
            return (ImageData != null ? ImageData.GetHashCode() : 0);
        }

        public string ImageData { get; set; }

        public DateTime CaptureTime { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}

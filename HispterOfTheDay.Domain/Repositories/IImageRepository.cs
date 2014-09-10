﻿using HispterOfTheDay.Domain.Model;

namespace HispterOfTheDay.Domain.Repositories
{
    public interface IImageRepository : IRepository
    {
        void Save(Image image);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackend.Service.Interfaces
{
   public interface ITVShowService
    {
        List<string> GetAllTvShows();

        List<string> GetSeasonsofSpecificTVShow();
    }
}

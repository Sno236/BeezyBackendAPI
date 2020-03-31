﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyBackend.Repository.Configuration
{
    public class APIConfiguration : ConfigurationBase
    {
                

        public string GetEndpointDataFromConfig(string connectionKey)
        {
            return GetConfiguration().GetConnectionString(connectionKey);
        }

    }
}

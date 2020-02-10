using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    class SqlLiteAutoMapperProfile: Profile
    {
        public SqlLiteAutoMapperProfile()
        {
            CreateMap<AccessTokenLifetime, AccessTokenLifetimeRecord>();
            CreateMap<List<AccessTokenLifetimeRecord>, List<AccessTokenLifetime>>();
        }
    }
}

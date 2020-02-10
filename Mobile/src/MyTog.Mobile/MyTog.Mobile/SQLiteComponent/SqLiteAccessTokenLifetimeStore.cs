using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class SqLiteAccessTokenLifetimeStore : BaseRepository<AccessTokenLifetime, AccessTokenLifetimeRecord>,
        IAccessTokenLifetimeStore
    {
        public SqLiteAccessTokenLifetimeStore(IMapper mapper) : base(mapper)
        {
        }
    }
}
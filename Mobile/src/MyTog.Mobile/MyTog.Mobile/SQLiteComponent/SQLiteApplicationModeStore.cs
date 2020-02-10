using AutoMapper;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class SQLiteApplicationModeStore : BaseRepository<ApplicationMode, ApplicationModeRecord>,
        IApplicationModeStore
    {
        public SQLiteApplicationModeStore(IMapper mapper) : base(mapper)
        {
        }
    }
}
using System;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    internal class CurrentUserService
    {
        private readonly Func<IUserQuery> _queryFactory;

        public CurrentUserService(Func<IUserQuery> queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public User GetCurrentUser()
        {
            return _queryFactory().Get();
        }

        public void SetCurrentUser(User user)
        {
        }
    }
}
using System;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile
{
    internal class CurrentUserService
    {
        private readonly CommandBus _bus;
        private readonly Func<IUserQuery> _queryFactory;

        public CurrentUserService(Func<IUserQuery> queryFactory, CommandBus bus)
        {
            _queryFactory = queryFactory;
            _bus = bus;
        }

        public User GetCurrentUser()
        {
            return _queryFactory().Get();
        }

        public void SetCurrentUser(User user)
        {
            var command = new CreateUserCommand();
        }
    }
}
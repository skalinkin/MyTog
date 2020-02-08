using System.Collections.Generic;
using System.Threading.Tasks;
using Kalinkin.MyTog.Mobile.Domain;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class SqLiteAccessTokenLifetimeStore : SqlLiteDatabase<AccessTokenLifetimeRecord>,
        IAccessTokenLifetimeStore
    {
        public Task<int> SaveItemAsync(AccessTokenLifetime item)
        {
            var record = new AccessTokenLifetimeRecord
            {
                AccessToken = item.AccessToken,
                AccessTokenExpiration = item.AccessTokenExpiration,
                AuthenticationTime = item.AuthenticationTime,
                IdentityToken = item.IdentityToken,
                RefreshToken = item.RefreshToken
            };
            return base.SaveItemAsync(record);
        }

        public new Task<List<AccessTokenLifetime>> GetItemsAsync()
        {
            return Task.Run(() =>
            {
                var records = base.GetItemsAsync().Result;
                var list = new List<AccessTokenLifetime>();
                foreach (var record in records)
                {
                    list.Add(new AccessTokenLifetime
                    {
                        AccessToken = record.AccessToken,
                        AccessTokenExpiration = record.AccessTokenExpiration,
                        AuthenticationTime = record.AuthenticationTime,
                        IdentityToken = record.IdentityToken,
                        RefreshToken = record.RefreshToken
                    });
                }

                return list;
            });
        }
    }
}
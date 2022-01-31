using Avanade.Allocation.Core.BL;
using Avanade.Allocation.Core.Mock.Repositories;
using Avanade.Allocation.Core.Mock.Storage;
using Avanade.Allocation.Core.Repositories;
using Xunit;

namespace Avanade.Allocation.WPF.Test
{
    public class AuthenticationTest
    {
        [Fact]
        public void ShouldSignInOkCredential()
        {
            //ARRANGE
            //Recupero dati che mi serviranno per gestire l'operazione

            AllocationMockStorage.Initialize();
            //Creazione del repository
            IUserRepository userRepo = new UserRepositoryMock();
            //Creazione del bl
            AuthenticationBusinessLayer layer = new AuthenticationBusinessLayer(userRepo);

            var userName = "lino.banfi";
            var password = "12345";

            //ACT eseguo l'operazione da testare
            var result = layer.SignIn(userName, password);

            //ASSERT Verifico il risultato
            Assert.True(result.Success);
        }
    }
}
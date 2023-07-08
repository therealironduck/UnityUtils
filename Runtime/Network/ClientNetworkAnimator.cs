#if THEREALIRONDUCK_NETWORKING
namespace TheRealIronDuck.Runtime.Network
{
    public class ClientNetworkAnimator : NetworkAnimator
    {
        protected override bool OnIsServerAuthoritative() => false;
    }
}
#endif
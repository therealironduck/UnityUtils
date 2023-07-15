#if THEREALIRONDUCK_NETWORKING
using Unity.Netcode.Components;

namespace TheRealIronDuck.Runtime.Network
{
    public class ClientNetworkAnimator : NetworkAnimator
    {
        protected override bool OnIsServerAuthoritative() => false;
    }
}
#endif
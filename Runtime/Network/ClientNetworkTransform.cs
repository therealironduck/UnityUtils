#if THEREALIRONDUCK_NETWORKING
using Unity.Netcode.Components;

namespace TheRealIronDuck.Runtime.Network
{
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative() => false; 
    } 
}
#endif
using GTANetworkAPI;

namespace GtaVMod.Commands
{
    public class CorePlayerCommands : Script
    {
        [Command("pos")]
        public void GetPosition(Player player)
        {
            CommandProxy.ExecuteIfLoggedIn(player, p =>
            {
                var pos = p.Position;
                p.SendChatMessage($"~g~Position: ~w~X: {pos.X:F2}, Y: {pos.Y:F2}, Z: {pos.Z:F2}");
            });
        }

        [Command("tp")]
        public void Teleport(Player player, float x, float y, float z)
        {
            CommandProxy.ExecuteIfLoggedIn(player, p =>
            {
                p.Position = new Vector3(x, y, z);
                p.SendChatMessage($"~b~Teleported to ~w~({x}, {y}, {z})");
            });
        }

        [Command("quit", "/quit")]
        public void Quit(Player player)
        {
            CommandProxy.ExecuteIfLoggedIn(player, p =>
            {
                p.Kick("~r~You have voluntarily disconnected from the server.");
            });
        }
    }
}

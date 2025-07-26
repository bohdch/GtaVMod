using GTANetworkAPI;

namespace GtaVMod.Commands
{
    public class VehicleCommands : Script
    {
        [Command("veh")]
        public void SpawnVehicle(Player player, string model)
        {
            CommandProxy.ExecuteIfLoggedIn(player, p =>
            {
                try
                {
                    NAPI.Vehicle.CreateVehicle(NAPI.Util.GetHashKey(model), p.Position.Around(5), 0, 0, 0);
                    p.SendChatMessage($"~g~Vehicle {model} spawned.");
                }
                catch
                {
                    p.SendChatMessage("~r~Error spawning vehicle. Invalid model?");
                }
            });
        }
    }
}

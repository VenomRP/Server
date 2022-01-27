using GTANetworkAPI;
using GVRP.Handler;
using GVRP.Module.ClientUI.Components;
using GVRP.Module.Computer.Apps.VehicleImpoundApp;
using GVRP.Module.GTAN;
using GVRP.Module.Players;
using GVRP.Module.Players.Windows;
using System;
using System.Text.RegularExpressions;

namespace GVRP.Module.Vehicles.Impound
{
    class VehicleImpoundEvents : Script
    {
        [RemoteEvent]
        public void SetVehicleImpoundTime(Player client, String timeString)
        {
            var dbPlayer = client.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;

            if (Int32.TryParse(timeString, out int time))
            {
                //max 8 Stunden
                if (time < 8 * 60)
                {
                    if (client.TryData("impound_vehicle", out SxVehicle vehicle))
                    {
                        if (vehicle != null)
                        {
                            //no impound, just normal
                            if (time == 0)
                            {
                                VehicleImpoundFunctions.RemoveVehicleAndGiveReward(dbPlayer, vehicle);
                                return;
                            }
                            else
                            {
                                client.SetData("impound_time", time);
                                ComponentManager.Get<TextInputBoxWindow>().Show()(dbPlayer, new TextInputBoxWindowObject() { Title = "Beschlagnahmungsgrund", Callback = "SetVehicleImpoundReason", Message = "Gib Informationen zur Beschlagnahmung ein." });
                            }
                        }
                    }
                }
                else
                {
                    dbPlayer.SendNewNotification("Die maximale Beschlagnahmungszeit ist 8 Stunden");
                }
            }
            else
            {
                dbPlayer.SendNewNotification("Die Zeit muss in Minuten angegeben werden!");
            }
        }

        [RemoteEvent]
        public void SetVehicleImpoundReason(Player client, String reason)
        {
            var dbPlayer = client.GetPlayer();
            if (dbPlayer == null || !dbPlayer.IsValid()) return;

            reason = Regex.Replace(reason, @"[^a-zA-Z0-9\s]", "");

            if (client.TryData("impound_vehicle", out SxVehicle vehicle))
            {
                if (vehicle != null)
                {
                    if (client.TryData("impound_time", out int time))
                    {
                        VehicleImpoundOverview vehicleImpoundOverview = new VehicleImpoundOverview()
                        {
                            Model = vehicle.Data.modded_car == 1 ? vehicle.Data.mod_car_name : vehicle.Data.Model,
                            Officer = client.Name,
                            Reason = reason,
                            VehicleId = vehicle.databaseId,
                            Date = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                            Release = (DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60 * time).ToString()
                        };

                        VehicleImpoundFunctions.ImpoundVehicle(dbPlayer, vehicle, vehicleImpoundOverview);

                    }

                }
            }

        }


    }
}

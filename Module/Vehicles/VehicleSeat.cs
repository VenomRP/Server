using System;
using System.Collections.Generic;
using System.Linq;
using GTANetworkAPI;

namespace GVRP.Module.Vehicles
{
    public static class VehicleSeat
    {
        public static int GetNextFreeSeat(this Vehicle vehicle, int offset = 0)
        {
            var seats = new bool[(int)Math.Round((double)vehicle.MaxOccupants)];

            var unavailableSeats = new HashSet<int>();

            foreach (var player in vehicle.Occupants)
            {
                var player1 = Players.Players.Instance.FindPlayer(player, true);
                unavailableSeats.Add(player1.Player.VehicleSeat);
            }

            for (int i = offset, length = (int)Math.Round((double)vehicle.MaxOccupants); i < length; i++)
            {
                if (!unavailableSeats.Contains(i))
                {
                    return i;
                }
            }

            return -2;
        }

        public static bool IsSeatFree(this Vehicle vehicle, int seat)
        {
            var player3 = Players.Players.Instance.FindPlayer(vehicle.Occupants, true);
            return vehicle.IsValidSeat(seat) && vehicle.Occupants.All(player => player3.Player.VehicleSeat != seat);
        }

        public static bool IsValidSeat(this Vehicle vehicle, int seat)
        {
            return seat > -2 && seat < vehicle.MaxOccupants - 1;
        }
    }
}
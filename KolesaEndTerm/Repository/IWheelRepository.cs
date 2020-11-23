using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface IWheelRepository
    {
        Wheel GetWheel(int id);
        IEnumerable<Wheel> GetAllWheels();
        Wheel Add(Wheel wheel);
        Wheel Update(Wheel wheel);
        Wheel Delete(int id);
    }
}
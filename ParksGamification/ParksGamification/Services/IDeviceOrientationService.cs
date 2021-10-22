using System;
using System.Collections.Generic;
using System.Text;

namespace ParksGamification.Services
{
    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}

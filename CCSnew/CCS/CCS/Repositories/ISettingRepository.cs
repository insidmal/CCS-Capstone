using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Repositories
{
    public interface ISettingRepository
    {
        Settings GetSettings();
        Settings UpdateSettings(Settings s);
    }
}

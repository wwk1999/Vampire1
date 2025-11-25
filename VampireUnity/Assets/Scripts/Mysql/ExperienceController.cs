using System;
using System.Collections.Generic;
using MySqlConnector;
using UnityEngine;
public class Experience
{
    public int Level { get; set; }
    public int Value { get; set; }
}
public class ExperienceController : XSingleton<ExperienceController>
{
    public List<Experience> Experience = new List<Experience>()
    {
        new Experience { Level = 1, Value = 100 },
        new Experience { Level = 2, Value = 200 },
        new Experience { Level = 3, Value = 300 },
        new Experience { Level = 4, Value = 400 },
        new Experience { Level = 5, Value = 5000 },
        new Experience { Level = 6, Value = 600 },
        new Experience { Level = 7, Value = 700 },
        new Experience { Level = 8, Value = 800 },
        new Experience { Level = 9, Value = 900 },
        new Experience { Level = 10, Value = 1000 },
        new Experience { Level = 11, Value = 1200 },
        new Experience { Level = 12, Value = 1400 },
        new Experience { Level = 13, Value = 1600 },
        new Experience { Level = 14, Value = 1800 },
        new Experience { Level = 15, Value = 2000 },
        new Experience { Level = 16, Value = 2200 },
        new Experience { Level = 17, Value = 2400 },
        new Experience { Level = 18, Value = 2600 },
        new Experience { Level = 19, Value = 2800 },
        new Experience { Level = 20, Value = 3000 },
        new Experience { Level = 21, Value = 3300 },
        new Experience { Level = 22, Value = 3600 },
        new Experience { Level = 23, Value = 3900 },
        new Experience { Level = 24, Value = 4200 },
        new Experience { Level = 25, Value = 4500 },
        new Experience { Level = 26, Value = 4800 },
        new Experience { Level = 27, Value = 5100 },
        new Experience { Level = 28, Value = 5400 },
        new Experience { Level = 29, Value = 5700 },
        new Experience { Level = 30, Value = 6000 },
    };


}

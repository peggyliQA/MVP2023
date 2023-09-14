using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsSpecFlow20230817.Utilites
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsabilityProject.Model;

namespace UsabilityProject.Services.SamplesManager
{
    public interface ISamplesManager
    {
        void CreateFakeSamples();
        List<SampleToJson> getSamplesList();
    }
}

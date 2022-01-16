using LutTool.Model;

namespace LutTool.Controllers
{
    public abstract class ControllerType
    {
        public abstract LutGroup[] ParseValues(byte[] pLutData);

        public abstract byte[] CompileToLut(LutGroup[] pGroups);

        public abstract int LutLength { get; }

        public abstract bool HasPhaseGroups { get; }

        public abstract bool HasFrameRates { get; }
    }
}

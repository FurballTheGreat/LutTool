using System.Collections.ObjectModel;
using LutTool.Model;

namespace LutTool.View
{
    public class LutPhaseView : BaseView
    {
        private readonly LutPhaseInfo _phaseInfo;
        public LutPhaseType Type { get; }

        public LutPhaseView(LutPhaseType pType, LutPhaseInfo pPhaseInfo)
        {
            _phaseInfo = pPhaseInfo;
            Type = pType;
            int index = 0;
            foreach (var source in pPhaseInfo.Sources)
            {
                var indexCap = index;
                VoltageSources.Add(new VoltageSourceView(index++, () => source, pSource=>pPhaseInfo.Sources[indexCap]=pSource));
            }
        }

        public uint PhaseLength
        {
            get => _phaseInfo.PhaseLength;
            set
            {
                _phaseInfo.PhaseLength = value;
                OnPropertyChanged(nameof(PhaseLength));
            }
        }

        public ObservableCollection<VoltageSourceView> VoltageSources { get; } = new();
    }
}